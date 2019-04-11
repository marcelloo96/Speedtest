using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Speedtest.Controller;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Speedtest
{
    public partial class MainFrame
    {
        public static bool edgeDetecting = false;
        public static bool meanValueIsOn = false;
        public static string edgeType = Strings.Measure_EdgeType_Rising;
        public static double Treshold = 0;
        public Stopwatch timer;

        #region ElementValues

        public string edgeTypeElementValue {
            get { return edgeTypeElement.EditValue.ToString(); }
            set { edgeTypeElement.EditValue = value; }
        }
        
        public double tresholdElementValue {
            get { return Double.Parse(tresholdValueElement.EditValue.ToString());}
            set { tresholdValueElement.EditValue = value; }
        }
         public string meanValueLabelCaption {
            set { meanValueLabel.Caption = value; }
        }
        #endregion
        #region ComboBoxes
        public RepositoryItemComboBox EdgeTypeRepositoryItemComboBox
        {
            get { return edgeTypeRepositoryItemComboBox; }
        }
        #endregion
        #region Labels
        public string periodTimeCaption
        {
            get { return periodTimeLabel.ToString(); }
            set { periodTimeLabel.Caption = value; }
        }
        #endregion

        
        private void detectingEdgeElement_EditValueChanged(object sender, EventArgs e)
        {
            edgeDetecting = (bool)detectingEdgeElement.EditValue;
        }
        private void chartMeanValueElement_EditValueChanged(object sender, EventArgs e)
        {
            meanValueIsOn = (bool)chartMeanValueElement.EditValue;
            if (meanValueIsOn == false) {
                meanValueLabelCaption = Strings.Global_MeanValue;
            }
        }

        private void tresholdValueElement_EditValueChanged(object sender, EventArgs e)
        {
            Treshold = tresholdElementValue;
        }
    }
}
