using System;
using System.Windows.Forms;
using Programming.Model;
using Programming.Model.Enums;

namespace Programming.View.Controls
{
    /// <summary>
    /// Предоставляет реализацию по представлению перечислений.
    /// </summary>
    public partial class EnumerationControl : UserControl
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="EnumerationControl"/>.
        /// </summary>
        public EnumerationControl()
        {
            InitializeComponent();

            var allEnums = Enum.GetValues(typeof(Enums));
            foreach (Enums value in allEnums)
            {
                EnumListBox.Items.Add(value);
            }
            EnumListBox.SelectedIndex = 0;
        }

        private void EnumListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueListBox.Items.Clear();
            Array enumValues;
            switch (EnumListBox.SelectedItem)
            {
                case Enums.Colors:
                    enumValues = Enum.GetValues(typeof(Colors));
                    break;
                case Enums.Weekday:
                    enumValues = Enum.GetValues(typeof(Weekday));
                    break;
                case Enums.Season:
                    enumValues = Enum.GetValues(typeof(Season));
                    break;
                case Enums.Manufacture:
                    enumValues = Enum.GetValues(typeof(Manufacture));
                    break;
                case Enums.Genre:
                    enumValues = Enum.GetValues(typeof(Genre));
                    break;
                case Enums.EducationForm:
                    enumValues = Enum.GetValues(typeof(EducationForm));
                    break;
                default:
                    throw new NotImplementedException();
            }
            foreach (var value in enumValues)
            {
                ValueListBox.Items.Add(value);
            }
        }

        private void ValueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValueListBox.SelectedItem == null) return;

            IntValueTextBox.Text = ((int)ValueListBox.SelectedItem).ToString();
        }
    }
}
