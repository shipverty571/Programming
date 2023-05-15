using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Contacts
{
    /// <summary>
    /// Представляет реализацию для конвертирования <see cref="bool" /> значений.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует <see cref="bool" /> значение в <see cref="object" />.
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
        /// Конвертирует <see cref="object" /> значение в <see cref="bool" />.
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