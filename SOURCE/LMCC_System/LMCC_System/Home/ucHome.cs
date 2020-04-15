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
using System.Windows.Media;

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
            LineChart();
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

        public void LineChart()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {5, 2, 8, 3},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                LineSmoothness = 0, //straight lines, 1 really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = System.Windows.Media.Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            cartesianChart1.Series[2].Values.Add(5d);

            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

    
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void ucHome_Load(object sender, EventArgs e)
        {

        }
    }
}
