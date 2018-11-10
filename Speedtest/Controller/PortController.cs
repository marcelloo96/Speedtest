using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Controller
{
    public static class PortController
    {
        public static SerialPort CreatePort(MainFrame model)
        {
            
            model.serialPort = new SerialPort()
            {


            };
            return null;
        }
    }
}
