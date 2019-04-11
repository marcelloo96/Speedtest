using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Model
{
    public class CSVModel
    {
        public List<List<double>> listOfChart;
        private static string csv;

        public CSVModel()
        {
            listOfChart = new List<List<double>>();
        }

        public static List<List<double>> getListOfCharts(string filePath)
        {
            List<List<double>> listOfChart = new List<List<double>>();

            using (var reader = new StreamReader(filePath))
            {
                csv = reader.ReadToEnd();
            }
            List<string> lines = CsvReader.ParseLines(csv);

            int channelsDetected = lines == null ? 0 : lines.First().Split(',').Count();

            if (channelsDetected > 0)
            {  
                //Each channel get its own List
                for (int i = 0; i < channelsDetected; i++)
                {
                    listOfChart.Add(new List<double>());
                }
                foreach (var line in lines)
                {
                    var columns = Array.ConvertAll(line.Split(',').Select(p=>p.Replace('.',',')).ToArray(), Double.Parse);

                    for (int i = 0; i < columns.Count(); i++)
                    {
                        listOfChart[i].Add(columns[i]);
                    }

                }
            }

            return listOfChart;
        }
    }


}
