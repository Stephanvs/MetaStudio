using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace Hayman.Client.Presentation.Windows.Controls
{
	public abstract class NotificationWindow : WindowElement
	{
		private class Const
		{
			public const double PaddingRight = 5;
			public const double PaddingBottom = 5;
		}

		private DoubleAnimation fadeInAnimation;
		private DoubleAnimation fadeOutAnimation;
		private DispatcherTimer activeTimer;

		static NotificationWindow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(NotificationWindow), 
				new FrameworkPropertyMetadata(typeof(NotificationWindow)));
		}

        public NotificationWindow()
        {
            Visibility = Visibility.Visible;

            Width = 350;
            Height = 75;

            // Set some default properties for the alerts.
            // These can be changed by the derived alerts.
            //ShowInTaskbar = false;
            //WindowStyle = WindowStyle.None;
            //ResizeMode = ResizeMode.NoResize;
            //Topmost = true;
            //AllowsTransparency = true;
            Opacity = 0.8;

            // Set up the fade in and fade out animations
            fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 0.8;
            fadeInAnimation.Duration = new Duration(TimeSpan.Parse("0:0:1.5"));

            // For the fade out we omit the from, so that it can be smoothly initiated
            // from a fade in that gets interrupted when the user wants to close the window
            fadeOutAnimation = new DoubleAnimation();
            fadeOutAnimation.To = 0;
            fadeOutAnimation.Duration = new Duration(TimeSpan.Parse("0:0:0.5"));

            Loaded += (sender, e) =>
            {
                fadeInAnimation.Completed += _fadeInAnimation_Completed;
                // Start the fade in animation
                BeginAnimation(NotificationWindow.OpacityProperty, fadeInAnimation);
            };
        }

		private void _fadeInAnimation_Completed(object sender, EventArgs e)
		{
			activeTimer = new DispatcherTimer();
			activeTimer.Interval = TimeSpan.Parse("0:0:10");

			// Attach an anonymous method to the timer so that we can start fading out the alert
			// when the timer is done.
			activeTimer.Tick += (obj, ea) => FadeOut();
			activeTimer.Start();
		}

		private void FadeOut()
		{
			// Attach an anonymous method to the Completed-event of the fade out animation
			// so that we can close the alert window when the animation is done.
			fadeOutAnimation.Completed += (sender, e) => Close();

			BeginAnimation(NotificationWindow.OpacityProperty, fadeOutAnimation, HandoffBehavior.SnapshotAndReplace);
		}

		private void closeButton_Click(object sender, RoutedEventArgs e)
		{
			activeTimer.Stop();
			FadeOut();
		}

		/// <summary>
		/// When the template is applied to the control, look for a button called "PART_CloseButton".
		/// If such a button exists, hook up an event handler so that the alert can be closed when
		/// the user clicks the button.
		/// </summary>
		public override void OnApplyTemplate()
		{
			ButtonBase closeButton = Template.FindName("PART_CloseButton", this) as ButtonBase;
			if (closeButton != null)
				closeButton.Click += closeButton_Click;
		}
	}
}
