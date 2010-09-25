using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Controls;

namespace Hayman.Client.Presentation.Windows.Controls
{
    /// <summary>
    /// Provides the ability to display widgets in a <see cref="Desktop"/> control.
    /// </summary>
    [TemplatePart(Name = WidgetElement.PART_MinimizeButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = WidgetElement.PART_CloseButton, Type = typeof(ButtonBase))]
    public sealed class WidgetElement : DesktopElement
    {
        private const string PART_MinimizeButton = "PART_MinimizeButton";
        private const string PART_CloseButton = "PART_CloseButton";
   
        /// <summary>
        /// Identifies the WindowState dependency property.
        /// </summary>
        public static readonly DependencyProperty WidgetStateProperty =
            DependencyProperty.Register("WidgetState", typeof(WindowState), typeof(WidgetElement),
                new FrameworkPropertyMetadata(WindowState.Normal));

        /// <summary>
        /// Identifies the ShowMinimizeButton dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowMinimizeButtonProperty =
            DependencyProperty.Register("ShowMinimizeButton", typeof(bool), typeof(WidgetElement),
                new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Minimize window command
        /// </summary>
        public static RoutedCommand MinimizeCommand;    

        /// <summary>
        /// Initializes the <see cref="WidgetElement"/> class.
        /// </summary>
        static WidgetElement()
        {
            WindowElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WidgetElement),
                new FrameworkPropertyMetadata(typeof(WidgetElement)));

            WidgetElement.MinimizeCommand = new RoutedCommand("Minimize", typeof(WindowElement));

            Control.IsTabStopProperty.OverrideMetadata(typeof(WidgetElement),
                new FrameworkPropertyMetadata(false));

            FocusManager.IsFocusScopeProperty.OverrideMetadata(
                typeof(WidgetElement), new FrameworkPropertyMetadata(true));

            KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(
                typeof(WidgetElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.Cycle));

            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(
                typeof(WidgetElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.Cycle));

            KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(
                typeof(WidgetElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.Once));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetElement"/> class.
        /// </summary>
        public WidgetElement()
        {
            CommandBinding bindingMinimize = new CommandBinding(WidgetElement.MinimizeCommand, OnMinimizeWindow);
            CommandBindings.Add(bindingMinimize);
        }
     
        /// <summary>
        /// Gets the Widget real Height based on the <see cref="WidgetState"/>.
        /// </summary>
        /// <remarks>Used for Widget serialization on <see cref="DesktopSerializer"/> class</remarks>
        public double RealHeight
        {
            get
            {
                if (WidgetState == WindowState.Minimized)
                {
                    return OldHeight;
                }

                return Height;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether a window is restored or minimized. 
        /// This is a dependency property.
        /// </summary>
        /// <value>A <see cref="WindowState"/> that determines whether a window is restored, minimized, or maximized. The default is Normal (restored).</value>
        public WindowState WidgetState
        {
            get { return (WindowState)base.GetValue(WidgetStateProperty); }
            set
            {
                if ((WindowState)GetValue(WidgetStateProperty) != value)
                {
                    base.SetValue(WidgetStateProperty, value);
                }

                AdjustLayout();
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the minimize button is visible. 
        /// This is a dependency property. 
        /// </summary>
        public bool ShowMinimizeButton
        {
            get { return (bool)base.GetValue(ShowMinimizeButtonProperty); }
            set { base.SetValue(ShowMinimizeButtonProperty, value); }
        }

        /// <summary>
        /// Closes the desktop element
        /// </summary>
        public override void Close()
        {
            CommandBindings.Clear();
            base.Close();
        }

        /// <summary>
        /// Occurs when the widget is going to be minimized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            if (WidgetState != WindowState.Minimized)
            {
                WidgetState = WindowState.Minimized;
            }
            else
            {
                WidgetState = WindowState.Normal;
            }
        }

        private void AdjustLayout()
        {
            if (WidgetState == WindowState.Minimized)
            {
                CanResize = false;
                OldHeight = Height;
                Height = 35;
            }
            else
            {
                CanResize = true;
                Height = OldHeight;
                OldHeight = Height;
            }
        }
    }
}
