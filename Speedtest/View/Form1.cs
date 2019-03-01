using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speedtest.View
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void speedTest1_Click(object sender, EventArgs e)
        {
            
        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELÓ from dockpanel");
        }

        private void dockPanel2_Container_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELÓ from dockpanelcontainer");
        }

        private void dockPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("HELÓ from panelmouseclick");
        }

        private void speedTest1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("HELÓ from speedtestmouseclick");
        }

        private void speedTest1_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("HELÓ from speedtestenter");
        }

        private void speedTest1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("HELÓ from speedtestclick");
        }
    }
}
