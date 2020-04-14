using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace LMCC_System
{
    public partial class ucHome : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucHome ucHome_Instance;
        public static ucHome _ucHome
        {
            get
            {
                ucHome_Instance = null;
                if (ucHome_Instance == null)
                    ucHome_Instance = new ucHome();
                return ucHome_Instance;
            }
        }
        public ucHome()
        {
            InitializeComponent();

            PieChart();
            DoughnutChart();
        }

        public void PieChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = " Land Mark",
                    Values = new ChartValues<double> {76},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Bench Mark",
                    Values = new ChartValues<double> {157},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "GPS",
                    Values = new ChartValues<double> {47},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        public void DoughnutChart()
        {
            pieChart2.InnerRadius = 50;
            pieChart2.LegendLocation = LegendLocation.Bottom;

            pieChart2.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Settle",
                    Values = new ChartValues<double> {250},
                    PushOut = 15,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Non Settle",
                    Values = new ChartValues<double> {481},
                    DataLabels = true
                }
            };
        }
    }
}
