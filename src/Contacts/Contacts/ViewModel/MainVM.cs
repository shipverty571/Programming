using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contacts.ViewModel
{
    /// <summary>
    ///     ViewModel для окна MainWindow.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        ///     Событие изменения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     При вызове зажигает событие <see cref="PropertyChanged" />.
        /// </summary>
        /// <param name="propertyName">Имя свойства, вызвавшего метод.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}