using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using GraphSharp.Controls;
using Hayman.Client.DomainModelVisualizerModule.ViewModels;

namespace Hayman.Client.DomainModelVisualizerModule.Controls
{
    /// <summary>
    /// Interaction logic for VertexExpander.xaml
    /// </summary>
    public class VertexExpander : UserControl
    {
        public static readonly DependencyProperty ExpandedProperty = DependencyProperty.Register("Expanded", typeof(bool), typeof(VertexExpander), new UIPropertyMetadata(true));

        public bool Expanded
        {
            get { return (bool)GetValue(ExpandedProperty); }
            set { SetValue(ExpandedProperty, value); }
        }

        public VertexExpander()
        {
            MouseLeftButtonDown += VertexExpander_MouseLeftButtonDown;
        }

        private static VertexControl GetVertexControl(DependencyObject parent)
        {
            while (parent != null)
                if (parent is VertexControl)
                    return (VertexControl)parent;
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

        void VertexExpander_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Expanded = !Expanded;
            VertexControl vertexControl = GetVertexControl(this);
            Vertex vertex = (Vertex)vertexControl.Vertex;
            GraphLayout graphLayout = GetGraphLayout(this);

            SetVertexVisibility(graphLayout, vertex, Expanded ? Visibility.Visible : Visibility.Hidden);
        }

        private static void SetVertexVisibility(GraphLayout graphLayout, Vertex vertex, Visibility visibility)
        {
            foreach (Edge edge in graphLayout.Graph.OutEdges(vertex))
            {
                EdgeControl edgeControl = graphLayout.GetEdgeControl(edge);
                edgeControl.Visibility = visibility;

                VertexControl vertexControl = graphLayout.GetVertexControl(edge.Target);
                vertexControl.Visibility = visibility;

                SetVertexVisibility(graphLayout, edge.Target, visibility);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            VertexControl vertexControl = GetVertexControl(this);
            Vertex vertex = (Vertex)vertexControl.Vertex;
            GraphLayout graphLayout = GetGraphLayout(this);

            Visibility = graphLayout.Graph.IsOutEdgesEmpty(vertex) ? Visibility.Hidden : Visibility.Visible;
        }   

    }
}
