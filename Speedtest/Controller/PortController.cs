using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Speedtest.Controller
{
    public class PortController
    {
        private MainFrame model;
        public double tryparseTmp;
        public PortController(MainFrame model) {
            this.model = model;

        }
        public void CreatePort()
        {

            model.serialPort = new SerialPort()
            {
                PortName = (string)model.SelectedPortElement.EditValue,
                BaudRate=(int)model.BaudRateElement.EditValue,
                DataBits=(int)model.DataBitsElement.EditValue,
                Parity=(Parity)model.ParityElement.EditValue,
                StopBits=(StopBits)model.StopBitElement.EditValue,
                RtsEnable=(bool)model.RtsEnableElement.EditValue,
                DtrEnable=(bool)model.DtrEnableElement.EditValue,
                Handshake=(Handshake)model.HandShakeElement.EditValue

            };
        }
        public void DoTheConnection()
        {
            try
            {
                model.serialPort.Open();
                if (model.serialPort.IsOpen)
                {
                    model.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusConnected;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dataFlow(object sender, EventArgs e)
        {

            model.gearedChart.viewModel.recivedChartValues.Clear();
            var recived = model.serialPort.ReadLine();
            Debug.WriteLine(recived);


            string[] chartValues = recived.Split(' ');

            for (var i = 0; i < chartValues.Length; i++)
            {
                double.TryParse(chartValues[i], out tryparseTmp);
                model.gearedChart.viewModel.recivedChartValues.Add(tryparseTmp);
            }

            ChartController.RefreshChartValues(model.gearedChart.viewModel, model.gearedChart.viewModel.recivedChartValues);

        }

    }
}
