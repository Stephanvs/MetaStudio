using System;
using Hayman.Client.DomainModelVisualizerModule.ViewModels;
using System.Windows;
using Hayman.Client.Presentation.Windows.Controls;

namespace Hayman.Client.DomainModelVisualizerModule.Views
{
	/// <summary>
	/// Interaction logic for DomainVisualizerView.xaml
	/// </summary>
    public partial class DomainVisualizerView : WindowElement
	{
        public DomainVisualizerView(DomainModuleVisualizerViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        static DomainVisualizerView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DomainVisualizerView), new FrameworkPropertyMetadata(typeof(DomainVisualizerView)));
        }
	}
}
