using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Contacts.Model.Services
{
    public class CombiningVisibilityConverter : IValueConverter
    {
        public IValueConverter InverseBooleanConverter { get; set; }
        
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
            object convertedValue = InverseBooleanConverter.Convert(
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
        /// Конвертирует object значение bool.
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