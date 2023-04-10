using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Contacts.Model.Services
{
    /// <summary>
    ///  Представляет реализацию для конвертирования bool значений.
    /// </summary>
    public class VisibilityConverter : IValueConverter
    {
        /// <summary>
        ///  Конвертирует bool значение в object
        /// </summary>
        /// <param name="value">Значение, которое необходимо преобразовать.</param>
        /// <param name="targetType">Тип, в который необходимо преобразовать.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает значение видимости элемента.</returns>
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        ///  Конвертирует object значение bool.
        /// </summary>
        /// <param name="value">Значение, которое необходимо преобразовать.</param>
        /// <param name="targetType">Тип, в который необходимо преобразовать.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает пустое значение.</returns>
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}