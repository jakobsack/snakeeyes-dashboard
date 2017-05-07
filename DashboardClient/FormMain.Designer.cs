namespace DashboardClient
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelTextLastUpdate = new System.Windows.Forms.Label();
            this.labelTextLastState = new System.Windows.Forms.Label();
            this.labelTextHistoryItems = new System.Windows.Forms.Label();
            this.labelTextLastMessage = new System.Windows.Forms.Label();
            this.labelTextMinValue = new System.Windows.Forms.Label();
            this.labelTextLastValue = new System.Windows.Forms.Label();
            this.labelTextMaxValue = new System.Windows.Forms.Label();
            this.labelTextProbeType = new System.Windows.Forms.Label();
            this.labelTextProbeName = new System.Windows.Forms.Label();
            this.labelTextMachine = new System.Windows.Forms.Label();
            this.labelLastMessage = new System.Windows.Forms.Label();
            this.labelHistoryItems = new System.Windows.Forms.Label();
            this.labelLastState = new System.Windows.Forms.Label();
            this.labelLastTimestamp = new System.Windows.Forms.Label();
            this.labelMinValue = new System.Windows.Forms.Label();
            this.labelLastValue = new System.Windows.Forms.Label();
            this.labelMaxValue = new System.Windows.Forms.Label();
            this.labelProbeType = new System.Windows.Forms.Label();
            this.labelProbeName = new System.Windows.Forms.Label();
            this.labelMachine = new System.Windows.Forms.Label();
            this.tabControlCharts = new System.Windows.Forms.TabControl();
            this.tabPageCurrent = new System.Windows.Forms.TabPage();
            this.chartCurrent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageHourly = new System.Windows.Forms.TabPage();
            this.chartHourly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageDaily = new System.Windows.Forms.TabPage();
            this.chartDaily = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.ColumnTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAggregation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxCommonName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelOverview = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlCharts.SuspendLayout();
            this.tabPageCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).BeginInit();
            this.tabPageHourly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHourly)).BeginInit();
            this.tabPageDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDaily)).BeginInit();
            this.tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.tabPageEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelTextLastUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextLastState);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextHistoryItems);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextLastMessage);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextMinValue);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextLastValue);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextMaxValue);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextProbeType);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextProbeName);
            this.splitContainer1.Panel1.Controls.Add(this.labelTextMachine);
            this.splitContainer1.Panel1.Controls.Add(this.labelLastMessage);
            this.splitContainer1.Panel1.Controls.Add(this.labelHistoryItems);
            this.splitContainer1.Panel1.Controls.Add(this.labelLastState);
            this.splitContainer1.Panel1.Controls.Add(this.labelLastTimestamp);
            this.splitContainer1.Panel1.Controls.Add(this.labelMinValue);
            this.splitContainer1.Panel1.Controls.Add(this.labelLastValue);
            this.splitContainer1.Panel1.Controls.Add(this.labelMaxValue);
            this.splitContainer1.Panel1.Controls.Add(this.labelProbeType);
            this.splitContainer1.Panel1.Controls.Add(this.labelProbeName);
            this.splitContainer1.Panel1.Controls.Add(this.labelMachine);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlCharts);
            this.splitContainer1.Size = new System.Drawing.Size(516, 517);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 4;
            // 
            // labelTextLastUpdate
            // 
            this.labelTextLastUpdate.AutoSize = true;
            this.labelTextLastUpdate.Location = new System.Drawing.Point(18, 68);
            this.labelTextLastUpdate.Name = "labelTextLastUpdate";
            this.labelTextLastUpdate.Size = new System.Drawing.Size(68, 13);
            this.labelTextLastUpdate.TabIndex = 19;
            this.labelTextLastUpdate.Text = "Last Update:";
            // 
            // labelTextLastState
            // 
            this.labelTextLastState.AutoSize = true;
            this.labelTextLastState.Location = new System.Drawing.Point(286, 3);
            this.labelTextLastState.Name = "labelTextLastState";
            this.labelTextLastState.Size = new System.Drawing.Size(58, 13);
            this.labelTextLastState.TabIndex = 18;
            this.labelTextLastState.Text = "Last State:";
            // 
            // labelTextHistoryItems
            // 
            this.labelTextHistoryItems.AutoSize = true;
            this.labelTextHistoryItems.Location = new System.Drawing.Point(274, 68);
            this.labelTextHistoryItems.Name = "labelTextHistoryItems";
            this.labelTextHistoryItems.Size = new System.Drawing.Size(70, 13);
            this.labelTextHistoryItems.TabIndex = 17;
            this.labelTextHistoryItems.Text = "History Items:";
            // 
            // labelTextLastMessage
            // 
            this.labelTextLastMessage.AutoSize = true;
            this.labelTextLastMessage.Location = new System.Drawing.Point(3, 94);
            this.labelTextLastMessage.Name = "labelTextLastMessage";
            this.labelTextLastMessage.Size = new System.Drawing.Size(76, 13);
            this.labelTextLastMessage.TabIndex = 16;
            this.labelTextLastMessage.Text = "Last Message:";
            // 
            // labelTextMinValue
            // 
            this.labelTextMinValue.AutoSize = true;
            this.labelTextMinValue.Location = new System.Drawing.Point(287, 42);
            this.labelTextMinValue.Name = "labelTextMinValue";
            this.labelTextMinValue.Size = new System.Drawing.Size(57, 13);
            this.labelTextMinValue.TabIndex = 15;
            this.labelTextMinValue.Text = "Min Value:";
            // 
            // labelTextLastValue
            // 
            this.labelTextLastValue.AutoSize = true;
            this.labelTextLastValue.Location = new System.Drawing.Point(284, 29);
            this.labelTextLastValue.Name = "labelTextLastValue";
            this.labelTextLastValue.Size = new System.Drawing.Size(60, 13);
            this.labelTextLastValue.TabIndex = 14;
            this.labelTextLastValue.Text = "Last Value:";
            // 
            // labelTextMaxValue
            // 
            this.labelTextMaxValue.AutoSize = true;
            this.labelTextMaxValue.Location = new System.Drawing.Point(284, 16);
            this.labelTextMaxValue.Name = "labelTextMaxValue";
            this.labelTextMaxValue.Size = new System.Drawing.Size(60, 13);
            this.labelTextMaxValue.TabIndex = 13;
            this.labelTextMaxValue.Text = "Max Value:";
            // 
            // labelTextProbeType
            // 
            this.labelTextProbeType.AutoSize = true;
            this.labelTextProbeType.Location = new System.Drawing.Point(21, 29);
            this.labelTextProbeType.Name = "labelTextProbeType";
            this.labelTextProbeType.Size = new System.Drawing.Size(65, 13);
            this.labelTextProbeType.TabIndex = 12;
            this.labelTextProbeType.Text = "Probe Type:";
            // 
            // labelTextProbeName
            // 
            this.labelTextProbeName.AutoSize = true;
            this.labelTextProbeName.Location = new System.Drawing.Point(17, 16);
            this.labelTextProbeName.Name = "labelTextProbeName";
            this.labelTextProbeName.Size = new System.Drawing.Size(69, 13);
            this.labelTextProbeName.TabIndex = 11;
            this.labelTextProbeName.Text = "Probe Name:";
            // 
            // labelTextMachine
            // 
            this.labelTextMachine.AutoSize = true;
            this.labelTextMachine.Location = new System.Drawing.Point(35, 3);
            this.labelTextMachine.Name = "labelTextMachine";
            this.labelTextMachine.Size = new System.Drawing.Size(51, 13);
            this.labelTextMachine.TabIndex = 10;
            this.labelTextMachine.Text = "Machine:";
            // 
            // labelLastMessage
            // 
            this.labelLastMessage.AutoSize = true;
            this.labelLastMessage.Location = new System.Drawing.Point(3, 107);
            this.labelLastMessage.Name = "labelLastMessage";
            this.labelLastMessage.Size = new System.Drawing.Size(10, 13);
            this.labelLastMessage.TabIndex = 9;
            this.labelLastMessage.Text = "-";
            // 
            // labelHistoryItems
            // 
            this.labelHistoryItems.AutoSize = true;
            this.labelHistoryItems.Location = new System.Drawing.Point(344, 68);
            this.labelHistoryItems.Name = "labelHistoryItems";
            this.labelHistoryItems.Size = new System.Drawing.Size(10, 13);
            this.labelHistoryItems.TabIndex = 8;
            this.labelHistoryItems.Text = "-";
            // 
            // labelLastState
            // 
            this.labelLastState.AutoSize = true;
            this.labelLastState.Location = new System.Drawing.Point(344, 3);
            this.labelLastState.Name = "labelLastState";
            this.labelLastState.Size = new System.Drawing.Size(10, 13);
            this.labelLastState.TabIndex = 7;
            this.labelLastState.Text = "-";
            // 
            // labelLastTimestamp
            // 
            this.labelLastTimestamp.AutoSize = true;
            this.labelLastTimestamp.Location = new System.Drawing.Point(86, 68);
            this.labelLastTimestamp.Name = "labelLastTimestamp";
            this.labelLastTimestamp.Size = new System.Drawing.Size(10, 13);
            this.labelLastTimestamp.TabIndex = 6;
            this.labelLastTimestamp.Text = "-";
            // 
            // labelMinValue
            // 
            this.labelMinValue.AutoSize = true;
            this.labelMinValue.Location = new System.Drawing.Point(344, 42);
            this.labelMinValue.Name = "labelMinValue";
            this.labelMinValue.Size = new System.Drawing.Size(10, 13);
            this.labelMinValue.TabIndex = 5;
            this.labelMinValue.Text = "-";
            // 
            // labelLastValue
            // 
            this.labelLastValue.AutoSize = true;
            this.labelLastValue.Location = new System.Drawing.Point(344, 29);
            this.labelLastValue.Name = "labelLastValue";
            this.labelLastValue.Size = new System.Drawing.Size(10, 13);
            this.labelLastValue.TabIndex = 4;
            this.labelLastValue.Text = "-";
            // 
            // labelMaxValue
            // 
            this.labelMaxValue.AutoSize = true;
            this.labelMaxValue.Location = new System.Drawing.Point(344, 16);
            this.labelMaxValue.Name = "labelMaxValue";
            this.labelMaxValue.Size = new System.Drawing.Size(10, 13);
            this.labelMaxValue.TabIndex = 3;
            this.labelMaxValue.Text = "-";
            // 
            // labelProbeType
            // 
            this.labelProbeType.AutoSize = true;
            this.labelProbeType.Location = new System.Drawing.Point(86, 29);
            this.labelProbeType.Name = "labelProbeType";
            this.labelProbeType.Size = new System.Drawing.Size(10, 13);
            this.labelProbeType.TabIndex = 2;
            this.labelProbeType.Text = "-";
            // 
            // labelProbeName
            // 
            this.labelProbeName.AutoSize = true;
            this.labelProbeName.Location = new System.Drawing.Point(86, 16);
            this.labelProbeName.Name = "labelProbeName";
            this.labelProbeName.Size = new System.Drawing.Size(10, 13);
            this.labelProbeName.TabIndex = 1;
            this.labelProbeName.Text = "-";
            // 
            // labelMachine
            // 
            this.labelMachine.AutoSize = true;
            this.labelMachine.Location = new System.Drawing.Point(86, 3);
            this.labelMachine.Name = "labelMachine";
            this.labelMachine.Size = new System.Drawing.Size(10, 13);
            this.labelMachine.TabIndex = 0;
            this.labelMachine.Text = "-";
            // 
            // tabControlCharts
            // 
            this.tabControlCharts.Controls.Add(this.tabPageCurrent);
            this.tabControlCharts.Controls.Add(this.tabPageHourly);
            this.tabControlCharts.Controls.Add(this.tabPageDaily);
            this.tabControlCharts.Controls.Add(this.tabPageTable);
            this.tabControlCharts.Controls.Add(this.tabPageEdit);
            this.tabControlCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCharts.Location = new System.Drawing.Point(0, 0);
            this.tabControlCharts.Name = "tabControlCharts";
            this.tabControlCharts.SelectedIndex = 0;
            this.tabControlCharts.Size = new System.Drawing.Size(516, 363);
            this.tabControlCharts.TabIndex = 3;
            // 
            // tabPageCurrent
            // 
            this.tabPageCurrent.Controls.Add(this.chartCurrent);
            this.tabPageCurrent.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurrent.Name = "tabPageCurrent";
            this.tabPageCurrent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrent.Size = new System.Drawing.Size(508, 337);
            this.tabPageCurrent.TabIndex = 0;
            this.tabPageCurrent.Text = "Current";
            this.tabPageCurrent.UseVisualStyleBackColor = true;
            // 
            // chartCurrent
            // 
            chartArea4.Name = "ChartArea1";
            this.chartCurrent.ChartAreas.Add(chartArea4);
            this.chartCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartCurrent.Legends.Add(legend4);
            this.chartCurrent.Location = new System.Drawing.Point(3, 3);
            this.chartCurrent.Name = "chartCurrent";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartCurrent.Series.Add(series4);
            this.chartCurrent.Size = new System.Drawing.Size(502, 331);
            this.chartCurrent.TabIndex = 3;
            this.chartCurrent.Text = "chart1";
            // 
            // tabPageHourly
            // 
            this.tabPageHourly.Controls.Add(this.chartHourly);
            this.tabPageHourly.Location = new System.Drawing.Point(4, 22);
            this.tabPageHourly.Name = "tabPageHourly";
            this.tabPageHourly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHourly.Size = new System.Drawing.Size(508, 337);
            this.tabPageHourly.TabIndex = 1;
            this.tabPageHourly.Text = "Hourly";
            this.tabPageHourly.UseVisualStyleBackColor = true;
            // 
            // chartHourly
            // 
            chartArea5.Name = "ChartArea1";
            this.chartHourly.ChartAreas.Add(chartArea5);
            this.chartHourly.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chartHourly.Legends.Add(legend5);
            this.chartHourly.Location = new System.Drawing.Point(3, 3);
            this.chartHourly.Name = "chartHourly";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartHourly.Series.Add(series5);
            this.chartHourly.Size = new System.Drawing.Size(502, 331);
            this.chartHourly.TabIndex = 4;
            this.chartHourly.Text = "chart1";
            // 
            // tabPageDaily
            // 
            this.tabPageDaily.Controls.Add(this.chartDaily);
            this.tabPageDaily.Location = new System.Drawing.Point(4, 22);
            this.tabPageDaily.Name = "tabPageDaily";
            this.tabPageDaily.Size = new System.Drawing.Size(508, 337);
            this.tabPageDaily.TabIndex = 2;
            this.tabPageDaily.Text = "Daily";
            this.tabPageDaily.UseVisualStyleBackColor = true;
            // 
            // chartDaily
            // 
            chartArea6.Name = "ChartArea1";
            this.chartDaily.ChartAreas.Add(chartArea6);
            this.chartDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartDaily.Legends.Add(legend6);
            this.chartDaily.Location = new System.Drawing.Point(0, 0);
            this.chartDaily.Name = "chartDaily";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartDaily.Series.Add(series6);
            this.chartDaily.Size = new System.Drawing.Size(508, 337);
            this.chartDaily.TabIndex = 4;
            this.chartDaily.Text = "chart1";
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.dataGridViewHistory);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Size = new System.Drawing.Size(508, 337);
            this.tabPageTable.TabIndex = 3;
            this.tabPageTable.Text = "Table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTimestamp,
            this.ColumnMin,
            this.ColumnAvg,
            this.ColumnMax,
            this.ColumnAggregation});
            this.dataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.Size = new System.Drawing.Size(508, 337);
            this.dataGridViewHistory.TabIndex = 0;
            // 
            // ColumnTimestamp
            // 
            this.ColumnTimestamp.HeaderText = "Timestamp";
            this.ColumnTimestamp.Name = "ColumnTimestamp";
            this.ColumnTimestamp.ReadOnly = true;
            this.ColumnTimestamp.Width = 120;
            // 
            // ColumnMin
            // 
            this.ColumnMin.HeaderText = "Min";
            this.ColumnMin.Name = "ColumnMin";
            this.ColumnMin.ReadOnly = true;
            this.ColumnMin.Width = 120;
            // 
            // ColumnAvg
            // 
            this.ColumnAvg.HeaderText = "Avg";
            this.ColumnAvg.Name = "ColumnAvg";
            this.ColumnAvg.ReadOnly = true;
            this.ColumnAvg.Width = 120;
            // 
            // ColumnMax
            // 
            this.ColumnMax.HeaderText = "Max";
            this.ColumnMax.Name = "ColumnMax";
            this.ColumnMax.ReadOnly = true;
            this.ColumnMax.Width = 120;
            // 
            // ColumnAggregation
            // 
            this.ColumnAggregation.HeaderText = "Aggregation";
            this.ColumnAggregation.Name = "ColumnAggregation";
            this.ColumnAggregation.ReadOnly = true;
            this.ColumnAggregation.Width = 80;
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Controls.Add(this.buttonSave);
            this.tabPageEdit.Controls.Add(this.comboBoxType);
            this.tabPageEdit.Controls.Add(this.textBoxCommonName);
            this.tabPageEdit.Controls.Add(this.label2);
            this.tabPageEdit.Controls.Add(this.label1);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(508, 337);
            this.tabPageEdit.TabIndex = 4;
            this.tabPageEdit.Text = "Edit";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 62);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(203, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(89, 34);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 3;
            // 
            // textBoxCommonName
            // 
            this.textBoxCommonName.Location = new System.Drawing.Point(89, 7);
            this.textBoxCommonName.Name = "textBoxCommonName";
            this.textBoxCommonName.Size = new System.Drawing.Size(122, 20);
            this.textBoxCommonName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Common name";
            // 
            // flowLayoutPanelOverview
            // 
            this.flowLayoutPanelOverview.AutoScroll = true;
            this.flowLayoutPanelOverview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelOverview.Location = new System.Drawing.Point(0, 20);
            this.flowLayoutPanelOverview.Name = "flowLayoutPanelOverview";
            this.flowLayoutPanelOverview.Size = new System.Drawing.Size(225, 497);
            this.flowLayoutPanelOverview.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBoxFilter);
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanelOverview);
            this.splitContainer2.Panel1.Resize += new System.EventHandler(this.splitContainer2_Panel1_Resize);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(745, 517);
            this.splitContainer2.SplitterDistance = 225;
            this.splitContainer2.TabIndex = 5;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(225, 20);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 517);
            this.Controls.Add(this.splitContainer2);
            this.Name = "FormMain";
            this.Text = "Snakeeyes Dashboard";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlCharts.ResumeLayout(false);
            this.tabPageCurrent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).EndInit();
            this.tabPageHourly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHourly)).EndInit();
            this.tabPageDaily.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDaily)).EndInit();
            this.tabPageTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageEdit.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOverview;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TabControl tabControlCharts;
        private System.Windows.Forms.TabPage tabPageCurrent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrent;
        private System.Windows.Forms.TabPage tabPageHourly;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHourly;
        private System.Windows.Forms.TabPage tabPageDaily;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDaily;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAggregation;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelMinValue;
        private System.Windows.Forms.Label labelLastValue;
        private System.Windows.Forms.Label labelMaxValue;
        private System.Windows.Forms.Label labelProbeType;
        private System.Windows.Forms.Label labelProbeName;
        private System.Windows.Forms.Label labelMachine;
        private System.Windows.Forms.Label labelLastMessage;
        private System.Windows.Forms.Label labelHistoryItems;
        private System.Windows.Forms.Label labelLastState;
        private System.Windows.Forms.Label labelLastTimestamp;
        private System.Windows.Forms.Label labelTextLastUpdate;
        private System.Windows.Forms.Label labelTextLastState;
        private System.Windows.Forms.Label labelTextHistoryItems;
        private System.Windows.Forms.Label labelTextLastMessage;
        private System.Windows.Forms.Label labelTextMinValue;
        private System.Windows.Forms.Label labelTextLastValue;
        private System.Windows.Forms.Label labelTextMaxValue;
        private System.Windows.Forms.Label labelTextProbeType;
        private System.Windows.Forms.Label labelTextProbeName;
        private System.Windows.Forms.Label labelTextMachine;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxCommonName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilter;
    }
}

