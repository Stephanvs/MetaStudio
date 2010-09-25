using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Hayman.Client.Presentation.Windows.ExtensionMethods
{
    /// <summary>
    /// Visual Extension Methods
    /// </summary>
    public static class VisualExtensions
    {
        #region · Static Members ·

        static readonly Point DefaultPoint = new Point(0, 0);
        static readonly double DpiX = 96.0;
        static readonly double DpiY = 96.0;

        #endregion

        #region · Extension Methods ·

        /// <summary>
        /// Captures an screenshot of the given Visual
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static BitmapSource CaptureScreen(this Visual target)
        {
            return CaptureScreen(target, DpiX, DpiY);
        }

        /// <summary>
        /// Captures an screenshot of the given Visual
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="dpiX">The dpi X.</param>
        /// <param name="dpiY">The dpi Y.</param>
        /// <returns></returns>
        public static BitmapSource CaptureScreen(this Visual target, double dpiX, double dpiY)
        {
            if (target == null)
            {
                return null;
            }

            DrawingVisual dv = new DrawingVisual();
            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)(bounds.Width * dpiX / DpiX),
                                                                 (int)(bounds.Height * dpiY / DpiY),
                                                                 dpiX,
                                                                 dpiY,
                                                                 PixelFormats.Pbgra32);

            using (DrawingContext ctx = dv.RenderOpen())
            {
                ctx.DrawRectangle(new VisualBrush(target), null, new Rect(DefaultPoint, bounds.Size));
            }

            rtb.Render(dv);

            return rtb;
        }

        #endregion
    }
}
