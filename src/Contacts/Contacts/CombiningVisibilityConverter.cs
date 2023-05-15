using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Contacts
{
    /// <summary>
    /// Представляет реализацию по вызову двух конвертеров: <see cref="InverseBooleanConverter" /> и
    /// <see cref="VisibilityConverter" />.
    /// </summary>
    public class CombiningVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Возвращает и задаёт конвертер для инверсии <see cref="bool" /> значения.
        /// </summary>
        public IValueConverter InverseBooleanConverter { get; set; }

        /// <summary>
        /// Возвращает и задаёт конвертер <see cref="bool" /> в <see cref="Visibility" />.
        /// </summary>
        public IValueConverter VisibilityConverter { get; set; }

        /// <summary>
        /// Вызывает два конвертера.
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
            var convertedValue = InverseBooleanConverter.Convert(
                value,
                targetType,
                parameter,
                culture);
            return VisibilityConverter.Convert(
                convertedValue,
                targetType,
                parameter,
                culture);
        }

        /// <summary>
        /// Конвертирует <see cref="object"/> значение в <see cref="bool" />.
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