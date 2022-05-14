using System;
using System.Windows.Forms;
using Programming.Model.Enums;

namespace Programming.View.Controls
{
    /// <summary>
    /// Предоставляет реализацию по парсингу дней недели из перечисления.
    /// </summary>
    public partial class WeekdayParsingControl : UserControl
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="WeekdayParsingControl"/>.
        /// </summary>
        public WeekdayParsingControl()
        {
            InitializeComponent();
        }

        private void ParseWeekdayButton_Click(object sender, EventArgs e)
        {
            string textWeekdayTextBox = WeekdayTextBox.Text;

            if (Enum.TryParse(textWeekdayTextBox, out Weekday valueTextBox))
                OutputWeekdayLabel.Text = $"Это день недели ({valueTextBox} - {(int)valueTextBox})";
            else
                OutputWeekdayLabel.Text = "Нет такого дня недели";
        }
    }
}
