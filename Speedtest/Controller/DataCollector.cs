using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;


namespace Speedtest.Controller
{
    class DataCollector : IDisposable
    {
        private readonly Action<string> _processMeasurement;
        private SerialPort serialPort;
        private const int SizeOfMeasurement = 4;
        List<byte> Data = new List<byte>();
        private string comingDataBuffer;
        private bool disposed = false;

        public DataCollector(SerialPort port , Action<string> processMeasurement)
        {
            _processMeasurement = processMeasurement;
            serialPort = port;
            serialPort.DataReceived += SerialPortDataReceived;
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialPort.IsOpen && serialPort.BytesToRead > 0)
            {
                var count = serialPort.BytesToRead;
                var bytes = new byte[count];
                serialPort.Read(bytes, 0, count);
                AddBytes(Encoding.UTF8.GetString(bytes));
            }
        }
        
        private void AddBytes(string arrivedString)
        {
            comingDataBuffer += arrivedString;

            var SampleList = comingDataBuffer.Split('\n').Where(p => p != "\r" && p != String.Empty).ToList();

            comingDataBuffer = String.Join("", SampleList);
            for (int i = 0; i < SampleList.Count; i++)
            {
                if (SampleList[i].Contains("\r"))
                {
                    comingDataBuffer = comingDataBuffer.Remove(0, SampleList[i].Length);
                    //Debug.WriteLine(SampleList[i]);
                    //printAll(SampleList[i]);
                    _processMeasurement?.Invoke(SampleList[i]);


                }
                else
                {
                    break;
                }
            }


        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing) {

            //TODO do it in a better way
            if (!disposed) {
                if (disposing) {
                    serialPort.Dispose();
                   
                }
                //to clean up unmanaged objects
                disposed = true;
            }
        }



        ~DataCollector() {
            Dispose(false);
            Debug.WriteLine("DC destructor");
        }
    }
}
