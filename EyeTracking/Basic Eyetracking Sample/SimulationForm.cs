using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tobii.EyeTracking.IO;

namespace BasicEyetrackingSample
{
    public partial class SimulationForm : Form
    {
        private readonly Clock _clock;
        private IEyeTracker _connectedTracker;
        private ISyncManager _syncManager;

        public SimulationForm()
        {
            InitializeComponent();
        }

        private void _connectedTracker_GazeDataReceived(object sender, GazeDataEventArgs e)
        {
            int trigSignal;
            if (e.GazeDataItem.TryGetExtensionValue(IntegerExtensionValue.TrigSignal, out trigSignal))
            {
                Console.WriteLine(string.Format("Trig signal: {0}", trigSignal));
            }

            // Send the gaze data to the simulation status control.
            var gd = e.GazeDataItem;
            Debug.WriteLine("dette er gd:" + gd);
            _simulationStatus.OnGazeData(gd);

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
    }
}
