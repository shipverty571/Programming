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

            SeasonHandleControl.ColorSelected += SeasonHandleControl_ColorSelected;
        }

        public void SeasonHandleControl_ColorSelected(object sender, ColorSelectedEventArgs args)
        {
            BackColor = args.Color;
        }
    }
}