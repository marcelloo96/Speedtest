using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speedtest.View.MeasureWindow
{
    public partial class ChartMonitorUserControl : UserControl
    {
        public ChartMonitorUserControl()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextBox.Visible)
            {
                TextBox.SelectionStart = TextBox.TextLength;
                TextBox.ScrollToCaret();
            }
        }
    }
}
