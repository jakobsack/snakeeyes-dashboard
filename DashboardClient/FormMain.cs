using DashboardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace DashboardClient
{
    public partial class FormMain : Form
    {
        private Probe ActiveProbe;
        private List<Probe> Probes;
        private List<Panel> OverviewPanels;

        public FormMain()
        {
            OverviewPanels = new List<Panel>();
            Probes = new List<Probe>();
            InitializeComponent();
            UpdateData();
        }

        public void UpdateData()
        {
            Request request = new Request()
            {
                Type = Request.Types.Probes
            };
            Response response = RequestData(request);

            ClearOverview();

            Probes = response.Probes;
            Probes.Sort(CompareProbes);
            foreach (Probe probe in Probes)
            {
                AddOverviewItem(probe);
            }

            if(ActiveProbe != null)
            {
                IEnumerable<Probe> newActive = Probes.Where(x => x.Machine == ActiveProbe.Machine && x.Name == ActiveProbe.Name);
                if (newActive.Count() == 1)
                {
                    ActiveProbe = newActive.First();
                    UpdateHistory(ActiveProbe);
                }
                else
                {
                    ClearChart(chartCurrent);
                    ClearChart(chartHourly);
                    ClearChart(chartDaily);
                    dataGridViewHistory.Rows.Clear();
                    ActiveProbe = null;
                }
            }
            else
            {
                ClearChart(chartCurrent);
                ClearChart(chartHourly);
                ClearChart(chartDaily);
                dataGridViewHistory.Rows.Clear();
            }
        }

        private void probePanel_Click(object sender, EventArgs e)
        {
            ProbePanel panel = null;
            if (sender.GetType() == typeof(Label))
            {
                panel = (ProbePanel)((Label)sender).Parent;
            }
            else if (sender.GetType() == typeof(ProbePanel))
            {
                panel = (ProbePanel)sender;
            }
            else
            {
                throw new Exception(String.Format("Don't nkow how to handle sender type {0}", sender.GetType()));
            }

            UpdateHistory(panel.ThisProbe);
        }

        private void UpdateHistory(Probe probe)
        {
            Request request = new Request()
            {
                Type = Request.Types.History,
                ProbeName = probe.Id
            };
            Response response = RequestData(request);

            if (response.Probes[0].History.Count == 0)
            {
                ClearChart(chartCurrent);
                ClearChart(chartHourly);
                ClearChart(chartDaily);
                dataGridViewHistory.Rows.Clear();
                return;
            }

            //---------------------
            // Current chart
            //---------------------
            ClearChart(chartCurrent);
            CreateChartLegend(chartCurrent);
            AddChart(chartCurrent, response.Probes[0].History.Where(x => x.Aggregation == HistoryItem.Aggregations.None), "recently");
            DrawChart(chartCurrent);

            //---------------------
            // Hourly chart
            //---------------------
            ClearChart(chartHourly);
            CreateChartLegend(chartHourly);
            AddChart(chartHourly, response.Probes[0].History.Where(x => x.Aggregation == HistoryItem.Aggregations.Hourly), "hourly");
            DrawChart(chartHourly);

            //---------------------
            // Hourly chart
            //---------------------
            ClearChart(chartDaily);
            CreateChartLegend(chartDaily);
            AddChart(chartDaily, response.Probes[0].History.Where(x => x.Aggregation == HistoryItem.Aggregations.Daily), "daily");
            DrawChart(chartDaily);

            //---------------------
            // Hourly chart
            //---------------------
            dataGridViewHistory.Rows.Clear();
            foreach (HistoryItem history in response.Probes[0].History)
            {
                DataGridViewRow row = dataGridViewHistory.Rows[dataGridViewHistory.Rows.Add()];
                row.Cells[0].Value = history.Timestamp.ToString();
                row.Cells[1].Value = history.Min.ToString();
                row.Cells[2].Value = history.Avg.ToString();
                row.Cells[3].Value = history.Max.ToString();
                row.Cells[4].Value = history.Aggregation;
            }
        }

        private void CreateChartLegend(Chart chart)
        {
            Legend legend = new Legend
            {
                Name = "legend",
                Title = "Legend",
                LegendStyle = LegendStyle.Column
            };
            chart.Legends.Add(legend);
        }

        private void ClearChart(Chart chart)
        {
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
        }

        private void AddChart(Chart chart, IEnumerable<HistoryItem> items, string name)
        {
            // Step 1: ChartArea
            Axis axisX = new Axis
            {
                Interval = 1
            };
            Axis axisY = new Axis
            {
                Minimum = 0
            };

            ChartArea chartArea = new ChartArea
            {
                AxisX = axisX,
                AxisY = axisY,
                Name = name,
                AlignmentOrientation = AreaAlignmentOrientations.Horizontal
            };
            chart.ChartAreas.Add(chartArea);

            List<String> graphs = new List<string> { "Min", "Avg", "Max" };
            if (name == "recently")
            {
                graphs = new List<string> { "Avg" };
            }

            foreach (string i in graphs)
            {
                Series series = new Series
                {
                    Name = name + i,
                    Color = i == "Min" ? Color.LightBlue : (i == "Max" ? Color.DarkBlue : Color.Blue),
                    BorderWidth = 1,
                    IsVisibleInLegend = true,
                    XValueType = ChartValueType.DateTime,
                    ChartType = SeriesChartType.Line,
                    Legend = "legend",
                    ChartArea = name,
                    LegendText = i
                };

                foreach (HistoryItem item in items)
                {
                    double value = i == "Min" ? item.Min : (i == "Max" ? item.Max : item.Avg);
                    series.Points.AddXY(item.Timestamp.ToOADate(), value);
                }
                chart.Series.Add(series);
            }
        }

        private void DrawChart(Chart chart)
        {
            chart.Invalidate();
        }

        private Response RequestData(Request request)
        {
            MsmqHelper.Write(MsmqHelper.RequestQueueName, request.ToXml());

            Response response = null;
            while (response == null)
            {
                string inMessage = MsmqHelper.Read(MsmqHelper.ResponseQueueName);
                if (inMessage != null)
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Response));
                    response = (Response)ser.Deserialize(new StringReader(inMessage));
                }
            }
            return response;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void ClearOverview()
        {
            flowLayoutPanelOverview.Controls.Clear();
            OverviewPanels.Clear();
        }

        private void AddOverviewItem(Probe probe)
        {
            ProbePanel panel = new ProbePanel(probe);
            panel.Width = 150;
            panel.Height = 150;
            panel.BackColor = GetPanelColor(probe);
            panel.RegisterClick(new System.EventHandler(this.probePanel_Click));

            flowLayoutPanelOverview.Controls.Add(panel);
        }

        private Color GetPanelColor(Probe probe)
        {
            if (probe.LastState == TraceEventType.Critical || probe.LastState == TraceEventType.Error)
            {
                return Color.PaleVioletRed;
            }
            else if (probe.LastState == TraceEventType.Warning)
            {
                return Color.LightYellow;
            }
            else
            {
                return Color.LightBlue;
            }
        }

        private int CompareProbes(Probe a, Probe b)
        {
            if (a.LastState != b.LastState)
            {
                return a.LastState.CompareTo(b.LastState);
            }
            else if (a.Machine != b.Machine)
            {
                return a.Machine.CompareTo(b.Machine);
            }
            else if (a.ProbeType != b.ProbeType)
            {
                return a.ProbeType.CompareTo(b.ProbeType);
            }
            else
            {
                return a.ProbeName.CompareTo(b.ProbeName);
            }
        }
    }
}
