using System;
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
