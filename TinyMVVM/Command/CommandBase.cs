using System;
using System.Windows.Input;

namespace TinyMVVM.Command
{
    public abstract class CommandBase : ICommand
    {
        /// <inheritdoc/>
        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);

        /// <inheritdoc/>
        void ICommand.Execute(object parameter) => Execute(parameter);

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raises <see cref="ICommand.CanExecuteChanged"/>
        /// </summary>
        protected virtual void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// internal handling of <see cref="ICommand.Execute"/>
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void Execute(object parameter);

        /// <summary>
        /// internal handling of <see cref="ICommand.CanExecute"/>
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract bool CanExecute(object parameter);
    }
}
