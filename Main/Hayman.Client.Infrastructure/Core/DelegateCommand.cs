using System;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace Hayman.Client.Infrastructure.Core
{
   /// <summary>
    /// An <see cref="ICommand"/> whose delegates can be attached for <see cref="Execute"/> and <see cref="CanExecute"/>.
    /// </summary>
    public class DelegateCommand : DelegateCommand<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">Delegate to execute when execute is called on the command.</param>
        public DelegateCommand(Action executeMethod)
            : base(parameter => executeMethod())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">Delegate to execute when execute is called on the command.</param>
        /// <param name="canExecuteMethod">Delegate to execute when CanExecute is called on the command.</param>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : base(parameter => executeMethod(), parameter => canExecuteMethod())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">Delegate to execute when execute is called on the command.</param>
        public DelegateCommand(Action<object> executeMethod)
            : base(executeMethod)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">Delegate to execute when execute is called on the command.</param>
        /// <param name="canExecuteMethod">Delegate to execute when CanExecute is called on the command.</param>
        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
            : base(executeMethod, canExecuteMethod)
        {
        }
    }
}
