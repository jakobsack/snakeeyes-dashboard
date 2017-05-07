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
            comboBoxType.DataSource = Enum.GetValues(typeof(Probe.SizeTypeEnum));
        }

        public void UpdateData()
        {
            Request request = new Request()
            {
                Type = Request.Types.Probes
            };
            Response response = RequestData(request);

            Probes = response.Probes;
            Probes.Sort(CompareProbes);

            UpdateOverviewPanel();

            if (ActiveProbe != null)
            {
                IEnumerable<Probe> newActive = Probes.Where(x => x.Machine == ActiveProbe.Machine && x.Name == ActiveProbe.Name);
                if (newActive.Count() == 1)
                {
                    ActiveProbe = newActive.First();
                    ShowProbe(ActiveProbe);
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

            ShowProbe(panel.ThisProbe);
        }

        private void ShowProbe(Probe probe)
        {
            Request request = new Request()
            {
                Type = Request.Types.History,
                ProbeId = probe.Id
            };
            Response response = RequestData(request);

            Probe data = response.Probes[0];

            foreach (Control p in flowLayoutPanelOverview.Controls)
            {
                if (p.GetType() != typeof(ProbePanel))
                {
                    continue;
                }

                ProbePanel pp = (ProbePanel)p;
                if (ActiveProbe != null && pp.ThisProbe.Id == ActiveProbe.Id)
                {
                    pp.BackColor = SystemColors.Control;
                }
                if (pp.ThisProbe.Id == data.Id)
                {
                    pp.BackColor = SystemColors.ActiveCaption;
                }
            }
            ActiveProbe = data;

            // Set the data in the details panel
            labelMachine.Text = data.Machine;
            labelProbeName.Text = data.ProbeName;
            labelProbeType.Text = data.ProbeType;
            labelMaxValue.Text = data.MaxValue.ToString();
            labelLastValue.Text = data.LastValue.ToString();
            labelMinValue.Text = data.MinValue.ToString();
            labelLastTimestamp.Text = data.LastTimestamp.ToString();
            labelLastState.Text = data.LastState.ToString();
            labelHistoryItems.Text = data.History.Count.ToString();
            labelLastMessage.Text = "";

            textBoxCommonName.Text = probe.TryCommonName();
            comboBoxType.SelectedItem = probe.SizeType;


            if (data.History.Count == 0)
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

            XmlSerializer ser = new XmlSerializer(typeof(Response));

            // The function we use to determine if a request is for us
            Func<string, bool> tester = (x) =>
            {
                if (x.Contains(request.Id))
                {
                    try
                    {
                        Response tempResponse = (Response)ser.Deserialize(new StringReader(x));
                        return tempResponse.Id == request.Id;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            };

            // Read the message
            Response response = null;
            while (response == null)
            {
                string inMessage = MsmqHelper.Read(MsmqHelper.ResponseQueueName, tester);
                if (inMessage != null)
                {
                    response = (Response)ser.Deserialize(new StringReader(inMessage));
                }
            }
            return response;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void UpdateOverviewPanel()
        {
            ClearOverview();

            string lastMachine = "";
            foreach (Probe probe in Probes.Where(x => (x.Id + x.CommonName).Contains(textBoxFilter.Text)))
            {
                if (probe.LastState >= TraceEventType.Information && probe.Machine != lastMachine)
                {
                    AddHeaderItem(probe.Machine);
                    lastMachine = probe.Machine;
                }
                AddOverviewItem(probe);
            }
        }

        private void ClearOverview()
        {
            flowLayoutPanelOverview.Controls.Clear();
            OverviewPanels.Clear();
        }

        private void AddHeaderItem(string name)
        {
            Panel panel = new Panel()
            {
                Width = 200,
                Height = 20
            };
            panel.Controls.Add(new Label
            {
                Text = name,
                Width = panel.Width - 10,
                Height = 14,
                Top = 5,
                Left = 5,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.TopCenter
            });

            flowLayoutPanelOverview.Controls.Add(panel);
        }

        private void AddOverviewItem(Probe probe)
        {
            ProbePanel panel = new ProbePanel(probe);
            panel.RegisterClick(new System.EventHandler(this.probePanel_Click));

            flowLayoutPanelOverview.Controls.Add(panel);
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

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            int sectionWidth = splitContainer1.Panel1.Width / 6;

            labelTextMachine.Top = 3;
            labelTextMachine.Left = sectionWidth - labelTextMachine.Width;
            labelMachine.Top = 3;
            labelMachine.Left = sectionWidth;

            labelTextProbeName.Top = 16;
            labelTextProbeName.Left = sectionWidth - labelTextProbeName.Width;
            labelProbeName.Top = 16;
            labelProbeName.Left = sectionWidth;

            labelTextProbeType.Top = 29;
            labelTextProbeType.Left = sectionWidth - labelTextProbeType.Width;
            labelProbeType.Top = 29;
            labelProbeType.Left = sectionWidth;

            labelTextLastState.Top = 3;
            labelTextLastState.Left = 4 * sectionWidth - labelTextLastState.Width;
            labelLastState.Top = 3;
            labelLastState.Left = 4 * sectionWidth;

            labelTextMaxValue.Top = 16;
            labelTextMaxValue.Left = 4 * sectionWidth - labelTextMaxValue.Width;
            labelMaxValue.Top = 16;
            labelMaxValue.Left = 4 * sectionWidth;

            labelTextLastValue.Top = 29;
            labelTextLastValue.Left = 4 * sectionWidth - labelTextLastValue.Width;
            labelLastValue.Top = 29;
            labelLastValue.Left = 4 * sectionWidth;

            labelTextMinValue.Top = 42;
            labelTextMinValue.Left = 4 * sectionWidth - labelTextMinValue.Width;
            labelMinValue.Top = 42;
            labelMinValue.Left = 4 * sectionWidth;

            labelTextHistoryItems.Top = 68;
            labelTextHistoryItems.Left = 4 * sectionWidth - labelTextHistoryItems.Width;
            labelHistoryItems.Top = 68;
            labelHistoryItems.Left = 4 * sectionWidth;

            labelTextLastUpdate.Top = 68;
            labelTextLastUpdate.Left = sectionWidth - labelTextLastUpdate.Width;
            labelLastTimestamp.Top = 68;
            labelLastTimestamp.Left = sectionWidth;

            labelTextLastMessage.Left = 3;
            labelTextLastMessage.Top = 94;
            labelLastMessage.Left = 3;
            labelLastMessage.Top = 107;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Enum.TryParse(comboBoxType.SelectedValue.ToString(), out Probe.SizeTypeEnum status);

            Request request = new Request
            {
                Type = Request.Types.Edit,
                ProbeId = ActiveProbe.Id,
                CommonName = textBoxCommonName.Text,
                SizeType = status
            };

            Response response = RequestData(request);
            UpdateData();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            UpdateOverviewPanel();
        }

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            flowLayoutPanelOverview.Height = splitContainer2.Panel1.Height - 20;
        }
    }
}
