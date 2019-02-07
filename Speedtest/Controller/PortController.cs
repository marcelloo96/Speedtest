using Speedtest.Model;
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
        private MainFrame mainFrameModel;
        public double tryparseTmp;
        public PortController(MainFrame model) {
            this.mainFrameModel = model;

        }
        public void CreatePort()
        {
            mainFrameModel.serialPort = new PortModel(mainFrameModel);
        }
        public void DoTheConnection()
        {
            try
            {
                mainFrameModel.serialPort.Open();
                if (mainFrameModel.serialPort.IsOpen)
                {
                    mainFrameModel.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusConnected;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dataFlow(object sender, EventArgs e)
        {

            mainFrameModel.gearedChart.viewModel.recivedChartValues.Clear();
            var recived = mainFrameModel.serialPort.ReadLine();
            Debug.WriteLine(recived);


            string[] chartValues = recived.Split(' ');

            for (var i = 0; i < chartValues.Length; i++)
            {
                double.TryParse(chartValues[i], out tryparseTmp);
                mainFrameModel.gearedChart.viewModel.recivedChartValues.Add(tryparseTmp);
            }

            ChartController.RefreshChartValues(mainFrameModel.gearedChart.viewModel, mainFrameModel.gearedChart.viewModel.recivedChartValues);

        }

    }
}
