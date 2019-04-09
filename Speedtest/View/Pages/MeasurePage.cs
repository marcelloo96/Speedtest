using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using System;
using System.Windows.Forms;

namespace Speedtest
{
    public partial class MainFrame
    {
        public static bool edgeDetecting = false;
        public static bool meanValue = false;

        #region ElementValues

        public string edgeTypeElementValue {
            get { return edgeTypeElement.EditValue.ToString(); }
            set { edgeTypeElement.EditValue = value; }
        }
        
        public double tresholdElementValue {
            get { return Double.Parse(tresholdValueElement.EditValue.ToString());}
            set { tresholdValueElement.EditValue = value; }
        }

        #endregion
        #region ComboBoxes
        public RepositoryItemComboBox EdgeTypeElement
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
            meanValue = (bool)chartMeanValueElement.EditValue;
        }
    }
}
