using System;
using System.Windows.Input;

namespace Hayman.Client.Infrastructure.ViewModels
{
    public interface IClosableViewModel
    {
        Guid Id { get; }
        ICommand CloseCommand { get; }
    }
}
