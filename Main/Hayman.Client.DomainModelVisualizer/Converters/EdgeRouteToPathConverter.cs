using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace Hayman.Client.DomainModelVisualizerModule.Converters
{
    public class EdgeRouteToPathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PathFigureCollection pfc = new PathFigureCollection();

            #region Get the inputs
            //get the position of the source
            Point sourcePos = new Point()
            {
                X = (values[0] != DependencyProperty.UnsetValue ? (double)values[0] : 0.0),
                Y = (values[1] != DependencyProperty.UnsetValue ? (double)values[1] : 0.0)
            };
            //get the size of the source
            Size sourceSize = new Size()
            {
                Width = (values[2] != DependencyProperty.UnsetValue ? (double)values[2] : 0.0),
                Height = (values[3] != DependencyProperty.UnsetValue ? (double)values[3] : 0.0)
            };
            //get the position of the target
            Point labelPos = new Point()
            {
                X = (values[4] != DependencyProperty.UnsetValue ? (double)values[4] : 0.0),
                Y = (values[5] != DependencyProperty.UnsetValue ? (double)values[5] : 0.0)
            };
            //get the size of the target
            Size labelSize = new Size()
            {
                Width = (values[6] != DependencyProperty.UnsetValue ? (double)values[6] : 0.0),
                Height = (values[7] != DependencyProperty.UnsetValue ? (double)values[7] : 0.0)
            };
            //get the position of the target
            Point targetPos = new Point()
            {
                X = (values[8] != DependencyProperty.UnsetValue ? (double)values[8] : 0.0),
                Y = (values[9] != DependencyProperty.UnsetValue ? (double)values[9] : 0.0)
            };
            //get the size of the target
            Size targetSize = new Size()
            {
                Width = (values[10] != DependencyProperty.UnsetValue ? (double)values[10] : 0.0),
                Height = (values[11] != DependencyProperty.UnsetValue ? (double)values[11] : 0.0)
            };

            #endregion

            Point p1 = sourcePos; //CalculateAttachPoint(sourcePos, sourceSize, targetPos);
            Point p2 = CalculateCenterPoint(labelPos, labelSize);
            Point p3 = CalculateAttachPoint(targetPos, targetSize, sourcePos);

            Vector v = p2 - p3;
            v = v / v.Length * 6;
            Vector n = new Vector(-v.Y, v.X) * 0.5;

            pfc.Add(new PathFigure(p1, new PathSegment[] { new LineSegment(p2, true) }, false));
            pfc.Add(new PathFigure(p2, new PathSegment[] { new LineSegment(p3 + v, true) }, false));
            pfc.Add(new PathFigure(p3, new PathSegment[] { new LineSegment(p3 + v - n, true), new LineSegment(p3 + v + n, true) }, true));
            
            return pfc;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static Point CalculateAttachPoint(Point s, Size sourceSize, Point t)
        {
            double[] sides = new double[4];
            sides[0] = (s.X - sourceSize.Width / 2.0 - t.X) / (s.X - t.X);
            sides[1] = (s.Y - sourceSize.Height / 2.0 - t.Y) / (s.Y - t.Y);
            sides[2] = (s.X + sourceSize.Width / 2.0 - t.X) / (s.X - t.X);
            sides[3] = (s.Y + sourceSize.Height / 2.0 - t.Y) / (s.Y - t.Y);

            double fi = 0;
            for (int i = 0; i < 4; i++)
            {
                if (sides[i] <= 1)
                    fi = Math.Max(fi, sides[i]);
            }

            return t + fi * (s - t);
        }

        public static Point CalculateCenterPoint(Point s, Size sourceSize)
        {
            return new Point()
            {
                X = s.X + (sourceSize.Width / 2),
                Y = s.Y + (sourceSize.Height / 2)
            };
        }
    }
}
