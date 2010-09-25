using System;
using System.Windows.Input;

namespace Hayman.Client.Infrastructure.ViewModels
{
    public interface IShortcutViewModel : IClosableViewModel
    {
        ICommand OpenCommand { get; }
    }
}
