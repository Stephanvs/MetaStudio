using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using GraphSharp.Controls;
using System.Windows.Shapes;
using Hayman.Client.DomainModelVisualizerModule.ViewModels;

namespace Hayman.Client.DomainModelVisualizerModule.Controls
{
    public class EdgeLabel : ContentControl
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(double), typeof(EdgeLabel), null);
        public static readonly DependencyProperty YProperty = DependencyProperty.Register("Y", typeof(double), typeof(EdgeLabel), null);

        public EdgeLabel()
        {
            LayoutUpdated += EdgeLabel_LayoutUpdated;
        }

        private static EdgeControl GetEdgeControl(DependencyObject parent)
        {
            while (parent != null)
                if (parent is EdgeControl)
                    return (EdgeControl)parent;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            return null;
        }

        private static GraphLayout GetGraphLayout(DependencyObject parent)
        {
            while (parent != null)
                if (parent is GraphLayout)
                    return (GraphLayout)parent;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            return null;
        }

        private static double GetAngleBetweenPoints(Point point1, Point point2)
        {
            return Math.Atan2(point1.Y - point2.Y, point2.X - point1.X);
        }

        private static double GetDistanceBetweenPoints(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        private static double GetLabelDistance(double edgeLength)
        {
            return edgeLength / 2;  // set the label halfway the length of the edge
        }

        private void EdgeLabel_LayoutUpdated(object sender, EventArgs e)
        {
            if (!IsLoaded)
                return;
            
            var edgeControl = GetEdgeControl(VisualParent);

            if (edgeControl == null)
                return;

            var polygon = new Polygon();
            var source = edgeControl.Source;
            var p1 = new Point(GraphCanvas.GetX(source), GraphCanvas.GetY(source));
            polygon.Points.Add(p1);

            bool grouped = true;
            if (grouped)
            {
                var graphLayout = GetGraphLayout(VisualParent);
                foreach (Edge edge in graphLayout.Graph.OutEdges((Vertex)source.Vertex))
                {
                    var vertexControl = graphLayout.GetVertexControl(edge.Target);
                    var p = new Point(GraphCanvas.GetX(vertexControl), GraphCanvas.GetY(vertexControl));
                    polygon.Points.Add(p);
                }
            }
            else
            {
                var target = edgeControl.Target;
                var p2 = new Point(GraphCanvas.GetX(target), GraphCanvas.GetY(target));
                polygon.Points.Add(p2);
            }
            
            var centroid = GetCentroidV2(polygon);
            var desiredSize = DesiredSize;
            centroid.Offset(-desiredSize.Width / 2, -desiredSize.Height / 2);

            SetValue(XProperty, centroid.X);
            SetValue(YProperty, centroid.Y);

            Arrange(new Rect(centroid, DesiredSize));
        }

         public static Point GetCentroid(Polygon polygon)
        {
            if (polygon.Points.Count == 0)
            {
                return new Point(0, 0);
            }
            else if (polygon.Points.Count == 1)
            {
                return polygon.Points[0];
            }
            else if (polygon.Points.Count == 2)
            {
                var p1 = polygon.Points[0];
                var p2 = polygon.Points[1];
                var distance = GetLabelDistance(GetDistanceBetweenPoints(p1, p2));
                var angleBetweenPoints = GetAngleBetweenPoints(p1, p2);

                p1.Offset(distance * Math.Cos(angleBetweenPoints), -distance * Math.Sin(angleBetweenPoints));
                return p1;
            }
            else
            {
                var area = 0d;
                var centroidX = 0d;
                var centroidY = 0d;

                for (int i = 0; i < polygon.Points.Count; i++)
                {
                    var point = polygon.Points[i];
                    var nextPoint = (i + 1 < polygon.Points.Count) ? polygon.Points[i + 1] : polygon.Points[0];
                    var temp = point.X * nextPoint.Y - nextPoint.X * point.Y;
                    centroidX += (nextPoint.X + point.X) * temp;
                    centroidY += (nextPoint.Y + point.Y) * temp;
                    area += temp;
                }

                return new Point
                {
                    X = centroidX / (area * 3.0),
                    Y = centroidY / (area * 3.0)
                };
            }
        }

         public static Point GetCentroidV2(Polygon polygon)
         {
             if (polygon.Points.Count == 0)
             {
                 return new Point(0, 0);
             }
             else if (polygon.Points.Count == 1)
             {
                 return polygon.Points[0];
             }
             else if (polygon.Points.Count == 2)
             {
                 var p1 = polygon.Points[0];
                 var p2 = polygon.Points[1];
                 var distance = GetLabelDistance(GetDistanceBetweenPoints(p1, p2));
                 var angleBetweenPoints = GetAngleBetweenPoints(p1, p2);

                 p1.Offset(distance * Math.Cos(angleBetweenPoints), -distance * Math.Sin(angleBetweenPoints));
                 return p1;
             }
             else
             {
                 var y1 = polygon.Points[0].Y;
                 var y2 = double.MaxValue;

                 for (int i = 1; i < polygon.Points.Count; i++)
                 {
                     y2 = Math.Min(y2, polygon.Points[i].Y);
                 }

                 return new Point
                 {
                     X = polygon.Points[0].X,
                     Y = y1 + ((y2 - y1) / 2)
                 };
             }
         }


    }

}
