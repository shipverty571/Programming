using System;
using System.Windows.Input;

namespace Contacts.ViewModel
{
    /// <summary>
    ///     Представляет реализацию интерфейса <see cref="ICommand" />.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        ///     Делегат для вызова команды.
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        ///     Создаёт экземпляр класса <see cref="RelayCommand" />.
        /// </summary>
        /// <param name="execute">Делегат для вызова команды.</param>
        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        /// <summary>
        ///     Событие изменения возможности вызова команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        ///     Определяет, может ли команда выполняться
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает всегда истину.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        ///     Выполняет логику команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}