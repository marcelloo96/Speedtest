using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Model
{
    public class CSVModel
    {
        public List<string> values;

        public CSVModel()
        {
            values = new List<string>();
        }

        public void convertToCSV() {
            var scv = CsvSerializer.SerializeToCsv(values);
        }
    }
}
