using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF
{
    public class TestControl : Control
    {
        //OnRender i use this LineWeight as
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Pen Pen1 = new Pen(new SolidColorBrush(Colors.Black), 2);
            //Pen1.DashStyle = _LineDashStyle;
            Rect rect = new Rect(0, 0, Width, Height);
            drawingContext.DrawRectangle(null, Pen1, rect);
        }
    }
}
