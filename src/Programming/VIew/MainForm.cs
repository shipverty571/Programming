using Programming.View.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Programming.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            seasonHandleControl1.ColorSelected += SeasonHandleControl_ColorSelected;
        }

        public void SeasonHandleControl_ColorSelected(object sender, ColorSelectedEventArgs args)
        {
            BackColor = seasonHandleControl1.CurrentColor;
            BackColor = args.Color;
        }
    }
}