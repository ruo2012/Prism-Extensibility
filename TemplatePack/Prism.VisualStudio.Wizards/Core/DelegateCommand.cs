using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Prism.VisualStudio.Wizards.Core
{
    /// <summary>
    /// Represents RelayCommand that uses the WPF CommandManager
    /// </summary>
    public sealed class DelegateCommand : ICommand
    {

        readonly Func<Boolean> _canExecuteMethod;
        readonly Action _executeMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="Infragistics.VisualStudio.Wizards.Xamarin.AppMap.Infrastructure.RelayCommand" /> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <exception cref="System.ArgumentNullException">The executeMethod was null.</exception>
        public DelegateCommand(Action executeMethod)
            : this(executeMethod, null)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException(nameof(executeMethod));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Infragistics.VisualStudio.Wizards.Xamarin.AppMap.Infrastructure.RelayCommand" /> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <param name="canExecuteMethod">The can execute method.</param>
        /// <exception cref="System.ArgumentNullException">The executeMethod was null.</exception>
        public DelegateCommand(Action executeMethod, Func<Boolean> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException(nameof(executeMethod));
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        [DebuggerStepThrough]
        public Boolean CanExecute(Object parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod();
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecuteMethod != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (_canExecuteMethod != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        /// <summary>
        /// Handles the RaiseEvent event of the CanExecuteChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void CanExecuteChanged_RaiseEvent(Object sender, EventArgs e)
        {
            if (_canExecuteMethod != null)
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        [DebuggerStepThrough]
        public void Execute(Object parameter)
        {
            _executeMethod?.Invoke();
        }

    }

    //
    //=====================================================================================================
    //=====================================================================================================
    //=====================================================================================================
    //

    /// <summary>
    /// Represents RelayCommand that uses the WPF CommandManager
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public sealed class DelegateCommand<T> : ICommand
    {

        readonly Predicate<T> _canExecuteMethod;
        readonly Action<T> _executeMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="Infragistics.VisualStudio.Wizards.Xamarin.AppMap.Infrastructure.RelayCommand&lt;T&gt;" /> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <exception cref="System.ArgumentNullException">The executeMethod was null.</exception>
        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException(nameof(executeMethod));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Infragistics.VisualStudio.Wizards.Xamarin.AppMap.Infrastructure.RelayCommand&lt;T&gt;" /> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <param name="canExecuteMethod">The can execute method.</param>
        /// <exception cref="System.ArgumentNullException">The executeMethod was null.</exception>
        public DelegateCommand(Action<T> executeMethod, Predicate<T> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException(nameof(executeMethod));
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        [DebuggerStepThrough]
        public Boolean CanExecute(Object parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod((T)parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecuteMethod != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (_canExecuteMethod != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        /// <summary>
        /// Handles the RaiseEvent event of the CanExecuteChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void CanExecuteChanged_RaiseEvent(Object sender, EventArgs e)
        {
            if (_canExecuteMethod != null)
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        [DebuggerStepThrough]
        public void Execute(Object parameter)
        {
            _executeMethod((T)parameter);
        }

    }
}
