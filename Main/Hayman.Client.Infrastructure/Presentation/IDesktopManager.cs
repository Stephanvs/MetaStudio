using System;
using System.Windows;
using System.Collections.ObjectModel;
using Hayman.Client.Infrastructure.Presentation.ViewModels;
using Hayman.Client.Infrastructure.Presentation.Core;
using Hayman.Client.Infrastructure.Presentation.Windows.Controls;

namespace Hayman.Client.Infrastructure.Presentation
{
	public interface IDesktopManager
	{
		Guid Id { get; }

		ReadOnlyObservableCollection<ITrackableWindow> ActiveWindows { get; }
		Desktop ActiveDesktop { get; }

		void CreateShortcut(string displayName, string target);
		void CreateShortcut(string displayName, Action action);
		
		void Show(ShortcutViewModelBase shortcut);
		void Show(ShortcutViewModelBase shortcut, Point position);

		void Close(Guid id);
		void Close(ClosableViewModel element);
		void CloseAll();

		void Show(UIElement element);
		void Restore(Guid id);

		void RegisterDesktop(DependencyObject d);
	}
}
