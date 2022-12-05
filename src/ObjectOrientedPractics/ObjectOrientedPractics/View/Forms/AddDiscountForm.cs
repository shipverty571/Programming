using ObjectOrientedPractics.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectOrientedPractics.View.Tabs;
using ObjectOrientedPractics.Model.Discounts;

namespace ObjectOrientedPractics.View.Forms
{
    public partial class AddDiscountForm : Form
    {
        public AddDiscountForm()
        {
            InitializeComponent();
            var categoryValues = Enum.GetValues(typeof(Category));
            foreach (var value in categoryValues)
            {
                CategoryComboBox.Items.Add(value);
            }
        }

        public PercentDiscount PercentDiscount {get; set; }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            PercentDiscount percentDiscount = new PercentDiscount((Category) CategoryComboBox.SelectedItem);
            PercentDiscount = percentDiscount;
            Close();
        }
    }
}
