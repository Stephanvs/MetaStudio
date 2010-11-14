using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;

namespace Hayman.Client.DomainModelVisualizerModule.Controls
{
    public class PanAndZoomViewer : ContentControl
    {
        private Point ScreenStartPoint = new Point(0, 0);
        private FrameworkElement source;
        private Point startOffset;
        private TransformGroup transformGroup;
        private TranslateTransform translateTransform;
        private ScaleTransform zoomTransform;

        public PanAndZoomViewer()
        {
            DefaultZoomFactor = 1.4;
            MaximumZoom = 5;
            MinimumZoom = 0.5;
        }

        public double DefaultZoomFactor { get; set; }
        public double MaximumZoom { get; set; }
        public double MinimumZoom { get; set; }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Setup();
        }

        private void Setup()
        {
            // Set alignment so that Location = (0, 0) is topleft
            FrameworkElement contentPresenter = VisualTreeHelper.GetChild(this, 0) as FrameworkElement;
            contentPresenter.HorizontalAlignment = HorizontalAlignment.Left;
            contentPresenter.VerticalAlignment = VerticalAlignment.Top;

            source = Content as FrameworkElement;

            transformGroup = new TransformGroup();
            source.RenderTransform = transformGroup;

            translateTransform = new TranslateTransform();
            zoomTransform = new ScaleTransform();
            transformGroup.Children.Add(zoomTransform);
            transformGroup.Children.Add(translateTransform);

            Focusable = true;
            KeyDown += source_KeyDown;
            MouseMove += control_MouseMove;
            MouseDown += source_MouseDown;
            MouseUp += source_MouseUp;
            MouseWheel += source_MouseWheel;
        }

        private void source_KeyDown(object sender, KeyEventArgs e)
        {
            // hit escape to reset everything
            if (e.Key == Key.Escape)
            {
                Reset();
            }
        }

        private void source_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // zoom into the content.  Calculate the zoom factor based on the direction of the mouse wheel.
            double zoomFactor = DefaultZoomFactor;
            if (e.Delta <= 0)
            {
                zoomFactor = 1.0 / DefaultZoomFactor;
            }
            // DoZoom requires both the logical and physical location of the mouse pointer
            Point physicalPoint = e.GetPosition(this);
            DoZoom(zoomFactor, transformGroup.Inverse.Transform(physicalPoint), physicalPoint);
        }

        private void source_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                // we're done.  reset the cursor and release the mouse pointer
                Cursor = Cursors.Arrow;
                ReleaseMouseCapture();
            }
        }

        private void source_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Save starting point, used later when determining how much to scroll.
            ScreenStartPoint = e.GetPosition(this);
            startOffset = new Point(translateTransform.X, translateTransform.Y);
            CaptureMouse();
            Cursor = Cursors.ScrollAll;
        }


        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseCaptured)
            {
                return; // don't care.
            }
            

            // if the mouse is captured then move the content by changing the translate transform.  
            // use the Pan Animation to animate to the new location based on the delta between the 
            // starting point of the mouse and the current point.
            Point physicalPoint = e.GetPosition(this);

            // where you'd like to move the top left corner of the view to
            double toX = physicalPoint.X -ScreenStartPoint.X + startOffset.X;
            double toY = physicalPoint.Y -ScreenStartPoint.Y + startOffset.Y;
            Console.WriteLine("You're attempting to move to " + toX + "," + toY);

            double scaleValue = zoomTransform.ScaleX;
            var content = (FrameworkElement)Content;

            double minToX = -(content.ActualWidth * scaleValue) + (20 * scaleValue);
            double minToY = -(content.ActualHeight * scaleValue) + (20 * scaleValue);
            double maxToX = ActualWidth - (20 * scaleValue); 
            double maxToY = ActualHeight - (20 * scaleValue); 

            // correct any invalid amounts:
            if (toX < minToX)
            {
                toX = minToX;
            }
            else if (toX > maxToX)
            {
                toX = maxToX;
            }

            if (toY < minToY)
            {
                toY = minToY;
            }
            else if (toY > maxToY)
            {
                toY = maxToY;
            }

            translateTransform.BeginAnimation(TranslateTransform.XProperty, CreatePanAnimation(toX), HandoffBehavior.Compose);
            translateTransform.BeginAnimation(TranslateTransform.YProperty, CreatePanAnimation(toY), HandoffBehavior.Compose);
        }

        /// <summary>Helper to create the panning animation for x,y coordinates.</summary>
        /// <param name="toValue">New value of the coordinate.</param>
        /// <returns>Double animation</returns>
        private static DoubleAnimation CreatePanAnimation(double toValue)
        {
            var da = new DoubleAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(300)))
            {
                AccelerationRatio = 0.1,
                DecelerationRatio = 0.9,
                FillBehavior = FillBehavior.HoldEnd
            };
            da.Freeze();
            return da;
        }


        /// <summary>Helper to create the zoom double animation for scaling.</summary>
        /// <param name="toValue">Value to animate to.</param>
        /// <returns>Double animation.</returns>
        private static DoubleAnimation CreateZoomAnimation(double toValue)
        {
            var da = new DoubleAnimation(toValue, new Duration(TimeSpan.FromMilliseconds(500)))
            {
                AccelerationRatio = 0.1,
                DecelerationRatio = 0.9,
                FillBehavior = FillBehavior.HoldEnd
            };
            da.Freeze();
            return da;
        }

        /// <summary>Zoom into or out of the content.</summary>
        /// <param name="deltaZoom">Factor to mutliply the zoom level by. </param>
        /// <param name="mousePosition">Logical mouse position relative to the original content.</param>
        /// <param name="physicalPosition">Actual mouse position on the screen (relative to the parent window)</param>
        public void DoZoom(double deltaZoom, Point mousePosition, Point physicalPosition)
        {
            // Keep Zoom within bounds declared by Minimum/MaximumZoom
            double currentZoom = zoomTransform.ScaleX;
            currentZoom *= deltaZoom;
            if (currentZoom < MinimumZoom)
            {
                currentZoom = MinimumZoom;
            }
            else if (currentZoom > MaximumZoom)
            {
                currentZoom = MaximumZoom;
            }

            translateTransform.BeginAnimation(TranslateTransform.XProperty, CreateZoomAnimation(-1 * (mousePosition.X * currentZoom - physicalPosition.X)));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, CreateZoomAnimation(-1 * (mousePosition.Y * currentZoom - physicalPosition.Y)));
            zoomTransform.BeginAnimation(ScaleTransform.ScaleXProperty, CreateZoomAnimation(currentZoom));
            zoomTransform.BeginAnimation(ScaleTransform.ScaleYProperty, CreateZoomAnimation(currentZoom));
        }

        /// <summary>Reset to default zoom level and centered content.</summary>
        public void Reset()
        {
            translateTransform.BeginAnimation(TranslateTransform.XProperty, CreateZoomAnimation(0));
            translateTransform.BeginAnimation(TranslateTransform.YProperty, CreateZoomAnimation(0));
            zoomTransform.BeginAnimation(ScaleTransform.ScaleXProperty, CreateZoomAnimation(1));
            zoomTransform.BeginAnimation(ScaleTransform.ScaleYProperty, CreateZoomAnimation(1));
        }
    }
}