using System;
using System.Windows.Forms;
using Programming.Model;
using Programming.Model.Enums;

namespace Programming.View.Controls
{
    public partial class WeekdayParsingControl : UserControl
    {
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
