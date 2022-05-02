using System;
using System.Drawing;
using System.Windows.Forms;
using Programming.Model;

namespace Programming.View.Controls
{
    public partial class SeasonHandleControl : UserControl
    {
        public delegate void ChangeColor(Color color);

        public event ChangeColor SelectColor;

        public SeasonHandleControl()
        {
            InitializeComponent();

            Array seasonValues = Enum.GetValues(typeof(Season));
            foreach (Season value in seasonValues)
            {
                SeasonNamesComboBox.Items.Add(value);
            }
            SeasonNamesComboBox.SelectedIndex = 0;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            switch (SeasonNamesComboBox.SelectedItem)
            {
                case Season.Winter:
                    SelectColor?.Invoke(AppColors.Winter);
                    break;
                case Season.Summer:
                    SelectColor?.Invoke(AppColors.Summer);
                    break;
                case Season.Spring:
                    SelectColor?.Invoke(AppColors.Spring);
                    break;
                case Season.Autumn:
                    SelectColor?.Invoke(AppColors.Autumn);
                    break;
            }
        }

        private void ClearColorButton_Click(object sender, EventArgs e)
        {
            SelectColor?.Invoke(DefaultBackColor);
        }
    }
}
