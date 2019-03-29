using Speedtest.Model;
using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Speedtest.Controller
{
    public class PortController
    {
        private MainFrame mainFrameModel;
        public double tryparseTmp;
        public int deltaTime;
        public Regex regex;
        public int numberOfPanelsDisplayed;
        public int numberOfIncomingData;
        public SerialPort serialPort;
        Stopwatch timer;
        public string[] importantValues;
        public List<string> buffer;
        public int bytesToRead;
        public string[] sendingData;

        public PortController(MainFrame model)
        {
            this.mainFrameModel = model;
            numberOfIncomingData = 1;
            deltaTime = 1000;
            regex = new Regex(@"-?[0-9]*(\s|\\r)");
            timer = new Stopwatch();
            buffer = new List<string>();
        }
        public void CreatePort()
        {
            if (mainFrameModel.serialPort == null) {
                mainFrameModel.serialPort = new SerialPort();
            }
            mainFrameModel.serialPort.PortName = mainFrameModel.selectedPortElementValue;
            mainFrameModel.serialPort.BaudRate = mainFrameModel.baudRateFromElementValue;
            mainFrameModel.serialPort.DataBits = mainFrameModel.dataBitsElementValue;
            mainFrameModel.serialPort.Parity = mainFrameModel.parityElementValue;
            mainFrameModel.serialPort.StopBits = mainFrameModel.stopBitElementValue;
            mainFrameModel.serialPort.RtsEnable = mainFrameModel.rtsEnableElementValue;
            mainFrameModel.serialPort.DtrEnable = mainFrameModel.dtrEnableElementValue;
            mainFrameModel.serialPort.Handshake = mainFrameModel.handShakeElementValue;

            serialPort = mainFrameModel.serialPort;

        }

        /// <summary>
        /// Returns true if the serialport is succesfully connected
        /// </summary>
        /// <returns></returns>
        public bool OpenThePort()
        {
            try
            {
                mainFrameModel.serialPort.Open();
              
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Do The Connection");
            }
            return false;
        }
        /// <summary>
        /// Returns true if the serialport is successfully closed
        /// </summary>
        /// <param name="serialPort"></param>
        /// <returns></returns>
        public static bool CloseSerialOnExit(SerialPort serialPort)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.DtrEnable = false;
                    serialPort.RtsEnable = false;
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("MeasureTabController CloseSerialOnExit");

                }
            }
            return false;
        }

    }

}
