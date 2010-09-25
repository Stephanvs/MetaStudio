using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Shapes;

namespace Hayman.Shell.Controls
{
    /// <summary>
    /// Implemetation of a Split Button
    /// </summary>
    [TemplatePart(Name = "PART_Icon", Type = typeof(Path))]
    [ContentProperty("Items")]
    [DefaultProperty("Items")]
    public class SplitButton : Button
    {
        #region Dependency Properties

        // AddOwner Dependency properties
        public static readonly DependencyProperty HorizontalOffsetProperty;
        public static readonly DependencyProperty IsContextMenuOpenProperty;
        public static readonly DependencyProperty ModeProperty;
        public static readonly DependencyProperty PlacementProperty;
        public static readonly DependencyProperty PlacementRectangleProperty;
        public static readonly DependencyProperty VerticalOffsetProperty;

        public static readonly DependencyProperty IconStyleProperty =
            DependencyProperty.Register("IconStyle", typeof(Style), typeof(SplitButton));

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register("ShowIcon", typeof(bool), typeof(SplitButton),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region Dependency Properties Callbacks

        private static void OnIsContextMenuOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SplitButton s = (SplitButton)d;
            s.EnsureContextMenuIsValid();

            if (!s.ContextMenu.HasItems)
            {
                return;
            }

            bool value = (bool)e.NewValue;

            if (value && !s.ContextMenu.IsOpen)
            {
                s.ContextMenu.IsOpen = true;
            }
            else if (!value && s.ContextMenu.IsOpen)
            {
                s.ContextMenu.IsOpen = false;
            }
        }

        /// <summary>
        /// Placement Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SplitButton s = d as SplitButton;

            if (s == null)
            {
                return;
            }

            s.EnsureContextMenuIsValid();
            s.ContextMenu.Placement = (PlacementMode)e.NewValue;
        }

        /// <summary>
        /// PlacementRectangle Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnPlacementRectangleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SplitButton s = d as SplitButton;

            if (s == null)
            {
                return;
            }

            s.EnsureContextMenuIsValid();
            s.ContextMenu.PlacementRectangle = (Rect)e.NewValue;
        }

        /// <summary>
        /// HorizontalOffset Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SplitButton s = d as SplitButton;

            if (s == null)
            {
                return;
            }

            s.EnsureContextMenuIsValid();
            s.ContextMenu.HorizontalOffset = (double)e.NewValue;
        }

        /// <summary>
        /// VerticalOffset Property changed callback, pass the value through to the buttons context menu
        /// </summary>
        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SplitButton s = d as SplitButton;
            if (s == null)
            {
                return;
            }

            s.EnsureContextMenuIsValid();
            s.ContextMenu.VerticalOffset = (double)e.NewValue;
        }

        #endregion

        #region Static Constructor

        /// <summary>
        /// Static Constructor
        /// </summary>
        static SplitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SplitButton),
                    new FrameworkPropertyMetadata(typeof(SplitButton)));

            IsContextMenuOpenProperty =
                DependencyProperty.Register(
                    "IsContextMenuOpen",
                    typeof(bool),
                    typeof(SplitButton),
                    new FrameworkPropertyMetadata(false,
                            new PropertyChangedCallback(OnIsContextMenuOpenChanged)));

            ModeProperty =
                DependencyProperty.Register(
                    "Mode",
                    typeof(SplitButtonMode),
                    typeof(SplitButton),
                    new FrameworkPropertyMetadata(SplitButtonMode.Dropdown));

            // AddOwner properties from the ContextMenuService class, we need callbacks from these properties
            // to update the Buttons ContextMenu properties
            PlacementProperty =
                ContextMenuService.PlacementProperty.AddOwner(
                    typeof(SplitButton),
                    new FrameworkPropertyMetadata(PlacementMode.Bottom,
                        new PropertyChangedCallback(OnPlacementChanged)));

            PlacementRectangleProperty =
                ContextMenuService.PlacementRectangleProperty.AddOwner(
                    typeof(SplitButton),
                    new FrameworkPropertyMetadata(Rect.Empty,
                        new PropertyChangedCallback(OnPlacementRectangleChanged)));

            HorizontalOffsetProperty =
                ContextMenuService.HorizontalOffsetProperty.AddOwner(
                    typeof(SplitButton),
                    new FrameworkPropertyMetadata(0.0,
                        new PropertyChangedCallback(OnHorizontalOffsetChanged)));

            VerticalOffsetProperty =
                ContextMenuService.VerticalOffsetProperty.AddOwner(
                    typeof(SplitButton),
                    new FrameworkPropertyMetadata(0.0,
                        new PropertyChangedCallback(OnVerticalOffsetChanged)));
        }

        #endregion

        #region Properties

        /// <summary>
        /// The Split Button's Items property maps to the base classes ContextMenu.Items property
        /// </summary>
        public ItemCollection Items
        {
            get
            {
                this.EnsureContextMenuIsValid();

                return this.ContextMenu.Items;
            }
        }

        /// <summary>
        /// Gets or sets the IsContextMenuOpen property. 
        /// </summary>
        public bool IsContextMenuOpen
        {
            get { return (bool)GetValue(IsContextMenuOpenProperty); }
            set { SetValue(IsContextMenuOpenProperty, value); }
        }

        /// <summary>
        /// Placement of the Context menu
        /// </summary>
        public PlacementMode Placement
        {
            get { return (PlacementMode)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        /// <summary>
        /// PlacementRectangle of the Context menu
        /// </summary>
        public Rect PlacementRectangle
        {
            get { return (Rect)GetValue(PlacementRectangleProperty); }
            set { SetValue(PlacementRectangleProperty, value); }
        }

        /// <summary>
        /// HorizontalOffset of the Context menu
        /// </summary>
        public double HorizontalOffset
        {
            get { return (double)GetValue(HorizontalOffsetProperty); }
            set { SetValue(HorizontalOffsetProperty, value); }
        }

        /// <summary>
        /// VerticalOffset of the Context menu
        /// </summary>
        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        /// <summary>
        /// Defines the Mode of operation of the Button
        /// </summary>
        /// <remarks>
        ///     The SplitButton two Modes are
        ///     Split (default),    - the button has two parts, a normal button and a dropdown which exposes the ContextMenu
        ///     Dropdown            - the button acts like a combobox, clicking anywhere on the button opens the Context Menu
        /// </remarks>
        public SplitButtonMode Mode
        {
            get { return (SplitButtonMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public Style IconStyle
        {
            get { return (Style)base.GetValue(IconStyleProperty); }
            set { base.SetValue(IconStyleProperty, value); }
        }

        public bool ShowIcon
        {
            get { return (bool)base.GetValue(ShowIconProperty); }
            set { base.SetValue(ShowIconProperty, value); }
        }

        #endregion

        #region Overriden Methods

        /// <summary>
        ///     Handles the Base Buttons OnClick event
        /// </summary>
        protected override void OnClick()
        {
            switch (Mode)
            {
                case SplitButtonMode.Dropdown:
                    OnDropdown();
                    break;

                default:
                    base.OnClick(); // forward on the Click event to the user
                    break;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Make sure the Context menu is not null
        /// </summary>
        private void EnsureContextMenuIsValid()
        {
            if (this.ContextMenu == null)
            {
                this.ContextMenu = new ContextMenu();
                this.ContextMenu.PlacementTarget = this;
                this.ContextMenu.Placement = this.Placement;

                this.ContextMenu.Opened += ((sender, routedEventArgs) => IsContextMenuOpen = true);
                this.ContextMenu.Closed += ((sender, routedEventArgs) => IsContextMenuOpen = false);
            }
        }

        private void OnDropdown()
        {
            this.EnsureContextMenuIsValid();

            if (!this.ContextMenu.HasItems)
            {
                return;
            }

            this.ContextMenu.IsOpen = !IsContextMenuOpen; // open it if closed, close it if open
        }

        #endregion
    }
}