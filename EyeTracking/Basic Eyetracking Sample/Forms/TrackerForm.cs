using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Tobii.EyeTracking.IO;

namespace BasicEyetrackingSample
{
    public partial class TrackerForm : Form
    {
        private readonly EyeTrackerBrowser _trackerBrowser;
        private readonly Clock _clock;

        private IEyeTracker _connectedTracker;
        private ISyncManager _syncManager; 
        private string _connectionName;
        private bool _isTracking;
        private EyeTrackerInfo _info;
        private CreateImageForm createImageForm;
        private BitmapList bitmapList;

        private Bitmap _Image;
        private Bitmap _resultImage;
        private Bitmap _blurredImage;
        //private String imageFolder = "images/nature/";

        public TrackerForm()
        {
            InitializeComponent();
            _clock = new Clock();
            bitmapList = new BitmapList();
            _trackerBrowser = new EyeTrackerBrowser();
            _trackerBrowser.EyeTrackerFound += EyetrackerFound;
            _trackerBrowser.EyeTrackerUpdated += EyetrackerUpdated;
            _trackerBrowser.EyeTrackerRemoved += EyetrackerRemoved;
            
            this._trackStatus = new TrackStatusControl(1, 5, 400, bitmapList.GetBitmaps());
            _box2.Controls.Add(_trackStatus);
            _trackStatus.BackColor = System.Drawing.Color.Black;
            _trackStatus.Location = new System.Drawing.Point(49, 33);
            _trackStatus.Name = "_trackStatus";
            _trackStatus.Size = new System.Drawing.Size(1520, 1000);
            _trackStatus.TabIndex = 1;
        }


        private void EyetrackerFound(object sender, EyeTrackerInfoEventArgs e)
        {
            // When an eyetracker is found on the network we add it to the listview
            var trackerItem = CreateTrackerListViewItem(e.EyeTrackerInfo);
            _trackerList.Items.Add(trackerItem);
            UpdateUIElements();
        }

        private void EyetrackerRemoved(object sender, EyeTrackerInfoEventArgs e)
        {
            // When an eyetracker disappears from the network we remove it from the listview
            _trackerList.Items.RemoveByKey(e.EyeTrackerInfo.ProductId);
            UpdateUIElements();
        }

        private void EyetrackerUpdated(object sender, EyeTrackerInfoEventArgs e)
        {
            // When an eyetracker is updated we simply create a new 
            // listviewitem and replace the old one
            int index = _trackerList.Items.IndexOfKey(e.EyeTrackerInfo.ProductId);
            if(index >= 0)
            {
                _trackerList.Items[index] = CreateTrackerListViewItem(e.EyeTrackerInfo);
            }
        }


        private static ListViewItem CreateTrackerListViewItem(EyeTrackerInfo info)
        {
            var trackerItem = new ListViewItem(info.ProductId);
            trackerItem.Name = info.ProductId;

            var sb = new StringBuilder();
            sb.AppendLine("Model: " + info.Model);
            sb.AppendLine("Status: " + info.Status);
            sb.AppendLine("Generation: " + info.Generation);
            sb.AppendLine("Product Id: " + info.ProductId);
            sb.AppendLine("Given Name: " + info.GivenName);
            sb.AppendLine("Firmware Version: " + info.Version);

            trackerItem.ToolTipText = sb.ToString();
            trackerItem.Tag = info;

            return trackerItem;
        }

        private ListViewItem GetSelectedItem()
        {
            if (_trackerList.SelectedItems.Count == 1)
            {
                return _trackerList.SelectedItems[0];
            }
            return null;
        }

        private void UpdateUIElements()
        {
            var selectedItemInfo = GetSelectedItem();

            if(selectedItemInfo != null)
            {
                _trackerInfoLabel.Text = selectedItemInfo.ToolTipText;
                _connectButton.Enabled = true;
            }
            else
            {
                _trackerInfoLabel.ResetText();
                _connectButton.Enabled = false;
            }

            if(_connectedTracker !=  null)
            {
                _connectionStatusLabel.Text = "Connected to " + _connectionName;
                _trackButton.Enabled = true;
                _calibrateButton.Enabled = true;
                _loadCalibrationMenuItem.Enabled = true;
                _saveCalibrationMenuItem.Enabled = true;
                _viewCalibrationMenuItem.Enabled = true;
                _framerateMenuItem.Enabled = true;
            }
            else
            {
                _connectionStatusLabel.Text = "Disconnected";
                _trackButton.Enabled = false;
                _calibrateButton.Enabled = false;
                _loadCalibrationMenuItem.Enabled = false;
                _saveCalibrationMenuItem.Enabled = false;
                _viewCalibrationMenuItem.Enabled = false;
                _framerateMenuItem.Enabled = false;
            }

            if(_isTracking)
            {
                _trackButton.Text = "Stop Tracking";
                _trackStatus.Enabled = true;
            }
            else
            {
                _trackButton.Text = "Start Tracking";
                _trackStatus.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Start browsing for eyetrackers on the network
            _trackerBrowser.StartBrowsing();
            UpdateUIElements();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Shutdown browser service
            _trackerBrowser.StopBrowsing();

            // Cleanup connections
            DisconnectTracker();
        }

        private void _trackerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIElements();
        }

        private void _connectButton_Click(object sender, EventArgs e)
        {
            // Disconnect existing connection
            DisconnectTracker();

            // Create new connection
            var selectedItem = GetSelectedItem();
            if(selectedItem != null)
            {
                _info = (EyeTrackerInfo) selectedItem.Tag;
                ConnectToTracker(_info);    
            }
            UpdateUIElements();
        }

        private void ConnectToTracker(EyeTrackerInfo info)
        {
            try
            {
                _connectedTracker = info.Factory.CreateEyeTracker();
                _connectedTracker.ConnectionError += HandleConnectionError;
                _connectionName = info.ProductId;

                _syncManager = info.Factory.CreateSyncManager(_clock);

                _connectedTracker.GazeDataReceived += _connectedTracker_GazeDataReceived;
                _connectedTracker.FrameRateChanged += _connectedTracker_FrameRateChanged;
            }
            catch (EyeTrackerException ee)
            {
                if(ee.ErrorCode == 0x20000402)
                {
                    MessageBox.Show("Failed to upgrade protocol. " + 
                        "This probably means that the firmware needs" +
                        " to be upgraded to a version that supports the new sdk.","Upgrade Failed",MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Eyetracker responded with error " + ee, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }

                DisconnectTracker();
            }
            catch(Exception)
            {
                MessageBox.Show("Could not connect to eyetracker.","Connection Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                DisconnectTracker();
            }
            UpdateUIElements();
        }

        private void _connectedTracker_GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            int trigSignal;
            if (e.GazeDataItem.TryGetExtensionValue(IntegerExtensionValue.TrigSignal, out trigSignal))
            {
                Console.WriteLine(string.Format("Trig signal: {0}", trigSignal));
            }

            // Send the gaze data to the track status control.
            var gd = e.GazeDataItem;
            _trackStatus.OnGazeData(gd.LeftGazePoint2D, gd.RightGazePoint2D);
            if (_syncManager.CurrentSyncState.Status == SyncStatus.Synchronized)
            {
                Int64 convertedTime = _syncManager.RemoteToLocal(gd.Timestamp);
                Int64 localTime = _clock.Time;
            }
            else
            {
                Console.WriteLine("Warning. Sync state is " + _syncManager.CurrentSyncState.Status);
            }
        }

        private static void _connectedTracker_FrameRateChanged(object sender, FrameRateChangedEventArgs e)
        {
            Console.WriteLine("FrameRate changed " + e.FrameRate);
        }

        private void HandleConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            // If the connection goes down we dispose 
            // the IAsyncEyetracker instance. This will release 
            // all resources held by the connection
            DisconnectTracker();
            UpdateUIElements();
        }

        private void DisconnectTracker()
        {
            if(_connectedTracker != null)
            {
                _connectedTracker.GazeDataReceived -= _connectedTracker_GazeDataReceived;
                _connectedTracker.Dispose();
                _connectedTracker = null;
                _connectionName = string.Empty;
                _isTracking = false;

                _syncManager.Dispose();
            }
        }

        private void _trackButton_Click(object sender, EventArgs e)
        {
            if(_isTracking)
            {
                // Unsubscribe from gaze data stream
                _connectedTracker.StopTracking();
                _isTracking = false;
            }
            else
            {
                // Start subscribing to gaze data stream
                _connectedTracker.StartTracking();
                _isTracking = true;
            }
            UpdateUIElements();
        }

        private void _calibrateButton_Click(object sender, EventArgs e)
        {
            var runner = new CalibrationRunner();
            
            try
            {
                // Start a new calibration procedure
                var result = runner.RunCalibration(_connectedTracker);

                // Show a calibration plot if everything went OK
                if (result != null)
                {
                    var resultForm = new CalibrationResultForm();
                    resultForm.SetPlotData(result);
                    resultForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Not enough data to create a calibration (or calibration aborted).");
                }                
            }
            catch(EyeTrackerException ee)
            {
                MessageBox.Show("Failed to calibrate. Got exception " + ee, 
                    "Calibration Failed", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }            
        }

        private void _saveCalibrationMenuItem_Click(object sender, EventArgs e)
        {
            if(_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var calibration = _connectedTracker.GetCalibration();
                    
                    using(var stream = _saveFileDialog.OpenFile())
                    using(var writer = new BinaryWriter(stream))
                    {
                        writer.Write(calibration.RawData);
                    }
                }
                catch (EyeTrackerException ee)
                {
                    MessageBox.Show("Failed to get calibration data. Got exception " + ee,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }    
            }
        }

        private void _viewCalibrationMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var calibration =_connectedTracker.GetCalibration();
                var resultForm = new CalibrationResultForm();
                resultForm.SetPlotData(calibration);
                resultForm.ShowDialog();
            }
            catch(EyeTrackerException ee)
            {
                MessageBox.Show("Failed to get calibration data. Got exception " + ee,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void _loadCalibrationMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = _openFileDialog.OpenFile())
                    using (var reader = new BinaryReader(stream))
                    {
                        byte[] data = reader.ReadBytes((int)stream.Length);
                        Calibration calibration = new Calibration(data);
                        _connectedTracker.SetCalibration(calibration);
                    }
                }
            }
            catch (EyeTrackerException ee)
            {
                MessageBox.Show("Failed to load calibration data. Got exception " + ee,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void _framerateMenuItem_Click(object sender, EventArgs e)
        {
            var framerate = _connectedTracker.GetFrameRate();
            var availableFrameRates = _connectedTracker.EnumerateFrameRates();

            int fpsIndex = availableFrameRates.IndexOf(framerate);

            FrameRateDialog fpsDialog = new FrameRateDialog(availableFrameRates,fpsIndex);

            if(fpsDialog.ShowDialog() == DialogResult.OK)
            {
                _connectedTracker.SetFrameRate(fpsDialog.CurrentFrameRate);
            }
        }

        private void _goBackButton_Click(object sender, EventArgs e)
        {
            Form mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void importImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "JPG files|*.jpg|BMP files|*.bmp|GIF files|*.gif";
            fDialog.InitialDirectory = Environment.CurrentDirectory;
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _Image = (Bitmap)Image.FromFile(fDialog.FileName);
                if (_Image.Width > _trackStatus.Width && _Image.Height > _trackStatus.Height)
                {
                    _resultImage = new Bitmap(_Image, _Image.Size);
                    Console.WriteLine(Path.GetDirectoryName(fDialog.FileName));
                    //imageFolder = Path.GetDirectoryName(fDialog.FileName);
                    //ChangeTrackerControl();
                    //_resultImage = new Bitmap(_Image, _HighestBlurLevel.Size);
                }
            }
        }
        public int GetNumberOfCircles()
        {
            return Int32.Parse(_numberOfImages.Text);
        }

        public int GetRadius()
        {
            return Int32.Parse(radiusBox.Text);
        }


        private void _changeButton_Click(object sender, EventArgs e)
        {
            ChangeTrackerControl();
        }

        private void ChangeTrackerControl()
        {
            TrackStatusControl newStatusControl = new TrackStatusControl(Int32.Parse(_blurLevel.Text),
                Int32.Parse(_numberOfImages.Text), Int32.Parse(radiusBox.Text), bitmapList.GetBitmaps());
            _box2.Controls.Clear();
            _box2.Controls.Add(newStatusControl);
            newStatusControl.BackColor = System.Drawing.Color.Black;
            newStatusControl.Location = new System.Drawing.Point(49, 33);
            newStatusControl.Size = new System.Drawing.Size(1520, 1000);
            newStatusControl.TabIndex = 1;
            this._trackStatus = newStatusControl;
        }

        private void createImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createImageForm = new CreateImageForm();
            createImageForm.Show();
        }
        public void NewImageListConfirmed()
        {
            ChangeTrackerControl();
        }
    }
}