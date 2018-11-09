using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Speedtest.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speedtest
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RepositoryItemComboBox BaudRateRepositoryItemComboBox { get { return baudRateRepositoryItemComboBox; } }
        public RepositoryItemComboBox SelectedPortRepositoryItemComboBox { get { return selectedPortRepositoryItemComboBox; } }
        public RepositoryItemComboBox NumberOfChannelsRepositoryItemComboBox {get { return numberOfChannelsRepositoryItemComboBox; } }
        public RepositoryItemComboBox DisplayModeRepositoryItemComboBox { get { return displayModeRepositoryItemComboBox; } }
        public BarEditItem DisplayModeElement { get { return displayModeElement; } }

        public Form1()
        {
            InitializeComponent();
           
            MeasureTabController.FillEditors(this);
            MeasureTabController.SetInitialState(this);
            

        }
    }
}
