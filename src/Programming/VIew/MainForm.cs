using System.Drawing;
using System.Windows.Forms;

namespace Programming.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            seasonHandleControl1.SelectColor += SeasonHandleControl_SelectColor;
        }

        public void SeasonHandleControl_SelectColor(Color color)
        {
            BackColor = color;
        }
    }
}