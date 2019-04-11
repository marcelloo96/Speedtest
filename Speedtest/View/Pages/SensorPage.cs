using DevExpress.XtraBars;
using System;
using System.Windows.Forms;

namespace Speedtest
{
    public partial class MainFrame
    {
        public static bool useLinearity = false;
        public static double sensitivity = 1;
        public static double zeroValue = 1;

        #region ElementValues

        public double sensitivityElementValue
        {
            get { return Double.Parse(sensitivityElement.EditValue.ToString()); }
            set { sensitivityElement.EditValue = value; }
        }
        public double zeroValueElementValue
        {
            get { return Double.Parse(zeroValueElement.EditValue.ToString()); }
            set { zeroValueElement.EditValue = value; }
        }

        public bool useLinearityEditValue
        {
            get { return (bool)useLinearityElement.EditValue; }
            set { useLinearityElement.EditValue = value; }
        }

        public int adcMaxEditValue
        {
            get
            {
                if (adcMaxValueElement.EditValue != null)
                {
                    return Int32.Parse(adcMaxValueElement.EditValue.ToString());
                }
                else
                {
                    return 0;
                }
            }
            set { adcMaxValueElement.EditValue = value; }
        }

        public int voltageReferenceEditValue
        {
            get
            {
                if (voltageReferenceElement.EditValue != null)
                {
                    return Int32.Parse(voltageReferenceElement.EditValue.ToString());
                }

                else
                {
                    return 0;
                }
            }
            set { voltageReferenceElement.EditValue = value; }
        }

        #endregion
        #region EditValueChanged
        private void sensitivityElement_EditValueChanged(object sender, EventArgs e)
        {
            sensitivity = sensitivityElementValue;
        }

        private void zeroValueElement_EditValueChanged(object sender, EventArgs e)
        {
            zeroValue = zeroValueElementValue;
        }

        private void useLinearityElement_EditValueChanged(object sender, EventArgs e)
        {
            useLinearity = useLinearityEditValue;
        }
        #endregion
        private double[] calculateLinearValue(double[] sendingData, double sensitivity, double zeroValue)
        {
            try
            {
                for (int i = 0; i < sendingData.Length; i++)
                {
                    sendingData[i] = sendingData[i] * sensitivity + zeroValue;
                }
            }
            catch (Exception e)
            {

                //MessageBox.Show("calculateLinearValue" + e.Message);
            }

            return sendingData;
        }

        private void calculateLinearityButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (adcMaxEditValue != 0)
            {
                sensitivityElementValue = (double)((double)voltageReferenceEditValue / (double)adcMaxEditValue);
            }
        }

    }
}
