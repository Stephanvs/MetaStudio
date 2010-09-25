using System;
using System.Windows;
using System.Collections.ObjectModel;
using Hayman.Client.Infrastructure.ViewModels;

namespace Hayman.Client.Infrastructure.Core
{
    public interface IDesktopManager
	{
        void RegisterModalContainer(DependencyObject d);
        Guid Id { get; }

		ReadOnlyObservableCollection<ITrackableWindow> ActiveWindows { get; }
		IDesktop ActiveDesktop { get; }

		void CreateShortcut(string displayName, string target);
		void CreateShortcut(string displayName, Action action);
		
		void Show(IShortcutViewModel shortcut);
		void Show(IShortcutViewModel shortcut, Point position);

        void Show(IWidgetViewModel shortcut);
        void Show(IWidgetViewModel shortcut, Point position);

		void Close(Guid id);
		void Close(IClosableViewModel element);
		void CloseAll();

		void Show(UIElement element);
        void Show(UIElement element, Point position);
		void Restore(Guid id);

		void RegisterDesktop(DependencyObject d);
	}
}
