using AForge.Math;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using MathNet.Numerics;
using Speedtest.Controller.TabControllers;
using Speedtest.Model;
using Speedtest.View.StatisticWindow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Speedtest.View.StatisticWindow.ScrollableChartUserControl;

namespace Speedtest
{
    public partial class MainFrame
    {
        public string importingFilePath;
        public List<List<double>> listOfImportedSeries;
        private List<string> availableFileFilters;
        private readonly bool alreadyExisting = true;
        private Complex[] complexArray;
        GearedValues<ObservablePoint> fftPrintList;

        #region ElementValues
        public int SelectRecordedChannelElementValue
        {
            get { return Int32.Parse(selectRecordedChannelElement.EditValue.ToString())-1; }
            set { selectRecordedChannelElement.EditValue = value; }
        }

        public string importDisplayModeElementValue
        {
            get { return importDisplayModeElement.EditValue.ToString(); }
            set { importDisplayModeElement.EditValue = value; }
        }
        #endregion
        #region ComboBoxes
        public RepositoryItemComboBox SelectRecordedChannelRepositoryItemComboBox { get { return selectRecordedChannelRepositoryItemComboBox; } }
        public RepositoryItemComboBox ImportDisplayModeElementRepositoryItemComboBox { get { return importDisplayModeElementRepositoryItemComboBox; } }
        #endregion
        private void statisticImportButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = String.Join("|", availableFileFilters);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                importingFilePath = dialog.FileName;

                listOfImportedSeries = CSVModel.getListOfCharts(importingFilePath);
                var channelsCount = listOfImportedSeries.Count();
                statisticChannelsFoundLabel.Caption = Strings.Statistic_ChannelsFound + ": " + channelsCount;
                var fileName = importingFilePath.Split('\\').Last().Split('.').First();
                if (fileName.Length > 25)
                {
                    fileName = fileName.Remove(25, fileName.Length - 25) + "...";
                }
                importedFileName.Caption = fileName;
                ImportTabController.ResetDetectedChannels(this, channelsCount);

            }

        }

        private void showSelectedChannelElement_ItemClick(object sender, ItemClickEventArgs e)
        {
            isRunning = false;
            if (listOfImportedSeries != null)
            {
                var selectedChart = listOfImportedSeries[SelectRecordedChannelElementValue];

                if (importDisplayModeElementValue == Strings.Import_DisplayMode_Scroll)
                {
                    bringScrollableToFront(selectedChart.ToList(), activePanels.OfType<ScrollableChartUserControl>().ToList());
                }
                else if (importDisplayModeElementValue == Strings.Import_DisplayMode_Histogram)
                {
                    bringHistogramToFront(getHistogramFromChart(selectedChart), activePanels.OfType<SimpleObservablePointedChartUserControl>().ToList());
                }
                else if (importDisplayModeElementValue == Strings.Import_DisplayMode_FFT)
                {
                    printFFT(selectedChart);
                    
                }
                //else if (importDisplayModeElementValue == Strings.Import_DisplayMode_FFT_PhaseSpectrum)
                //{
                //    Complex[] complexArray = new Complex[selectedChart.Count];
                //    for (int i = 0; i < selectedChart.Count; i++)
                //    {
                //        complexArray[i] = new Complex(selectedChart[i], 0);
                //    }

                //    FourierTransform.DFT(complexArray, FourierTransform.Direction.Forward);
                //    double[] abs = new double[complexArray.Count()];
                //    for (int i = 0; i < complexArray.Count(); i++)
                //    {
                //        abs[i] = complexArray[i].Phase;
                //    }
                //    bringScrollableToFront(abs.ToList(), activePanels.OfType<ScrollableChartUserControl>().ToList());
                //}

            }
            else
            {
                MessageBox.Show(Strings.Import_NoFilesImported);
            }
            

        }

        private void printFFT(List<double> selectedChart)
        {
            int originalLenght = selectedChart.Count;
            int fftLenght = originalLenght / 2 + (originalLenght%2==1 ? 1:0);
            complexArray = new Complex[originalLenght];

            for (int i = 0; i < selectedChart.Count; i++)
            {
                complexArray[i] = new Complex(selectedChart[i], 0);
            }

            FourierTransform.DFT(complexArray, FourierTransform.Direction.Backward);

            double[] fftValues = new double[originalLenght];
            for (int i = 0; i < complexArray.Count(); i++)
            {
                fftValues[i] = complexArray[i].Magnitude;
            }
           

            var Y = new double[fftLenght];
            int k = 0;
            for (int i = originalLenght-1; k<fftLenght; i--) {
                Y[k] = fftValues[i];
                k++;
            }


            //in case of Testing the result
            //var csvbuffer = new StringBuilder();
            //csvbuffer.AppendLine(String.Join("\n", Y.Select(p => p.ToString("G", culture))));
            //string csvpath = savingFileDestinationPath + @"\" + exportFileNameElementValue + exportingFileFormatEditValue;
            //File.AppendAllText(csvpath, csvbuffer.ToString());

            var tmpremovable = fftValues.ToList();
            tmpremovable.RemoveRange(0, fftLenght);
            fftValues = tmpremovable.ToArray();
            double[] X = new double[originalLenght];

            double axisDT = 1 / (originalLenght * deltaTime);
            for (int i = 0; i < fftLenght; i++)
            {
                X[i] = i * axisDT;

            }
            
            fftPrintList = new GearedValues<ObservablePoint>();
            for (int i = 0; i < fftLenght; i++)
            {
                fftPrintList.Add(new ObservablePoint(X[i], Y[i]));
                
            }
            
            
            bringFFTToFront(fftPrintList, activePanels.OfType<ScrollableChartUserControl>().ToList(), ScrollableType.FFT);
        }

        private void bringScrollableToFront(List<double> selectedChart, List<ScrollableChartUserControl> onPanelWithThisType, ScrollableType type = ScrollableType.Basic)
        {
            if (onPanelWithThisType != null && selectedChart != null)
            {
                foreach (var panel in onPanelWithThisType)
                {
                    if (panel.doubleValues!=null && panel.doubleValues.Equals(selectedChart))
                    {

                        bringContentToFront(panel, alreadyExisting);
                        return;
                    }
                }
            }

            bringContentToFront(new ScrollableChartUserControl(selectedChart, deltaTime, type));
        }
        private void bringFFTToFront(GearedValues<ObservablePoint> selectedChart, List<ScrollableChartUserControl> onPanelWithThisType, ScrollableType type = ScrollableType.Basic)
        {
            if (onPanelWithThisType != null && selectedChart != null)
            {
                foreach (var panel in onPanelWithThisType)
                {
                    if (panel.observableValues != null && panel.observableValues.Equals(selectedChart))
                    {

                        bringContentToFront(panel, alreadyExisting);
                        return;
                    }
                }
            }

            bringContentToFront(new ScrollableChartUserControl(selectedChart, deltaTime, type));
        }
        private void bringHistogramToFront(GearedValues<ObservablePoint> generated, List<SimpleObservablePointedChartUserControl> onPanelWithThisType)
        {
            if (onPanelWithThisType != null && generated != null)
            {
                foreach (var panel in onPanelWithThisType)
                {
                    if (isObservablePointedChartsEqual(panel.Values, generated))
                    {

                        bringContentToFront(panel, alreadyExisting);
                        return;
                    }
                }

            }

            bringContentToFront(new SimpleObservablePointedChartUserControl(generated));
        }
        private bool isObservablePointedChartsEqual(GearedValues<ObservablePoint> a, GearedValues<ObservablePoint> b)
        {
            if (a == null || b == null)
            {
                return false;
            }
            if (a.Count() != b.Count())
            {
                return false;
            }
            else if (a.Count() == b.Count())
            {
                for (int i = 0; i < a.Count(); i++)
                {
                    if (a[i].X != b[i].X || a[i].Y != b[i].Y)
                    {
                        return false;
                    }

                }

            }

            return true;
        }
        private GearedValues<ObservablePoint> getHistogramFromChart(List<double> chart)
        {
            SortedDictionary<double, double> histogram = new SortedDictionary<double, double>();
            GearedValues<ObservablePoint> histogramChartModel = new GearedValues<ObservablePoint>();

            foreach (var point in chart)
            {
                if (histogram.ContainsKey(point))
                {
                    histogram[point]++;
                }
                else
                {
                    histogram[point] = 1;
                }
            }
            foreach (var item in histogram)
            {
                histogramChartModel.Add(new ObservablePoint(item.Key, item.Value));
            }

            return histogramChartModel;
        }
        private List<string> getFileFilters()
        {
            availableFileFilters = new List<string>();
            availableFileFilters.Add(Strings.Import_FileFilter_CSV);
            availableFileFilters.Add(Strings.Import_FileFilter_TXT);

            return availableFileFilters;
        }
    }
}
