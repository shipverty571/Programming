using System;
using System.Drawing;
using System.Windows.Forms;
using Programming.Model;

namespace Programming.View.Controls
{
    public class ColorSelectedEventArgs : EventArgs
    {
        public Color Color { get; set; }

        public ColorSelectedEventArgs(Color color)
        {
            Color = color;
        }
    }

    public partial class SeasonHandleControl : UserControl
    {
        public event EventHandler<ColorSelectedEventArgs> ColorSelected;

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
                    ColorSelected?.Invoke(this, new ColorSelectedEventArgs(AppColors.Winter));
                    break;
                case Season.Summer:
                    ColorSelected?.Invoke(this, new ColorSelectedEventArgs(AppColors.Summer));
                    break;
                case Season.Spring:
                    ColorSelected?.Invoke(this, new ColorSelectedEventArgs(AppColors.Spring));
                    break;
                case Season.Autumn:
                    ColorSelected?.Invoke(this, new ColorSelectedEventArgs(AppColors.Autumn));
                    break;
            }
        }

        private void ClearColorButton_Click(object sender, EventArgs e)
        {
            ColorSelected?.Invoke(this, new ColorSelectedEventArgs(DefaultBackColor));
        }
    }
}
