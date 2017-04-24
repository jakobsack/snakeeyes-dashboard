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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelOverview = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tabControlCharts = new System.Windows.Forms.TabControl();
            this.tabPageCurrent = new System.Windows.Forms.TabPage();
            this.tabPageHourly = new System.Windows.Forms.TabPage();
            this.chartCurrent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageDaily = new System.Windows.Forms.TabPage();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.chartHourly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDaily = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.ColumnTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAggregation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlCharts.SuspendLayout();
            this.tabPageCurrent.SuspendLayout();
            this.tabPageHourly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).BeginInit();
            this.tabPageDaily.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHourly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelOverview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlCharts);
            this.splitContainer1.Size = new System.Drawing.Size(579, 517);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 4;
            // 
            // flowLayoutPanelOverview
            // 
            this.flowLayoutPanelOverview.AutoScroll = true;
            this.flowLayoutPanelOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelOverview.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelOverview.Name = "flowLayoutPanelOverview";
            this.flowLayoutPanelOverview.Size = new System.Drawing.Size(579, 193);
            this.flowLayoutPanelOverview.TabIndex = 0;
            // 
            // tabControlCharts
            // 
            this.tabControlCharts.Controls.Add(this.tabPageCurrent);
            this.tabControlCharts.Controls.Add(this.tabPageHourly);
            this.tabControlCharts.Controls.Add(this.tabPageDaily);
            this.tabControlCharts.Controls.Add(this.tabPageTable);
            this.tabControlCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCharts.Location = new System.Drawing.Point(0, 0);
            this.tabControlCharts.Name = "tabControlCharts";
            this.tabControlCharts.SelectedIndex = 0;
            this.tabControlCharts.Size = new System.Drawing.Size(579, 320);
            this.tabControlCharts.TabIndex = 3;
            // 
            // tabPageCurrent
            // 
            this.tabPageCurrent.Controls.Add(this.chartCurrent);
            this.tabPageCurrent.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurrent.Name = "tabPageCurrent";
            this.tabPageCurrent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrent.Size = new System.Drawing.Size(571, 294);
            this.tabPageCurrent.TabIndex = 0;
            this.tabPageCurrent.Text = "Current";
            this.tabPageCurrent.UseVisualStyleBackColor = true;
            // 
            // tabPageHourly
            // 
            this.tabPageHourly.Controls.Add(this.chartHourly);
            this.tabPageHourly.Location = new System.Drawing.Point(4, 22);
            this.tabPageHourly.Name = "tabPageHourly";
            this.tabPageHourly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHourly.Size = new System.Drawing.Size(571, 294);
            this.tabPageHourly.TabIndex = 1;
            this.tabPageHourly.Text = "Hourly";
            this.tabPageHourly.UseVisualStyleBackColor = true;
            // 
            // chartCurrent
            // 
            chartArea10.Name = "ChartArea1";
            this.chartCurrent.ChartAreas.Add(chartArea10);
            this.chartCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            legend10.Name = "Legend1";
            this.chartCurrent.Legends.Add(legend10);
            this.chartCurrent.Location = new System.Drawing.Point(3, 3);
            this.chartCurrent.Name = "chartCurrent";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chartCurrent.Series.Add(series10);
            this.chartCurrent.Size = new System.Drawing.Size(565, 288);
            this.chartCurrent.TabIndex = 3;
            this.chartCurrent.Text = "chart1";
            // 
            // tabPageDaily
            // 
            this.tabPageDaily.Controls.Add(this.chartDaily);
            this.tabPageDaily.Location = new System.Drawing.Point(4, 22);
            this.tabPageDaily.Name = "tabPageDaily";
            this.tabPageDaily.Size = new System.Drawing.Size(571, 294);
            this.tabPageDaily.TabIndex = 2;
            this.tabPageDaily.Text = "Daily";
            this.tabPageDaily.UseVisualStyleBackColor = true;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.dataGridViewHistory);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Size = new System.Drawing.Size(571, 294);
            this.tabPageTable.TabIndex = 3;
            this.tabPageTable.Text = "Table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // chartHourly
            // 
            chartArea11.Name = "ChartArea1";
            this.chartHourly.ChartAreas.Add(chartArea11);
            this.chartHourly.Dock = System.Windows.Forms.DockStyle.Fill;
            legend11.Name = "Legend1";
            this.chartHourly.Legends.Add(legend11);
            this.chartHourly.Location = new System.Drawing.Point(3, 3);
            this.chartHourly.Name = "chartHourly";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chartHourly.Series.Add(series11);
            this.chartHourly.Size = new System.Drawing.Size(565, 288);
            this.chartHourly.TabIndex = 4;
            this.chartHourly.Text = "chart1";
            // 
            // chartDaily
            // 
            chartArea12.Name = "ChartArea1";
            this.chartDaily.ChartAreas.Add(chartArea12);
            this.chartDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            legend12.Name = "Legend1";
            this.chartDaily.Legends.Add(legend12);
            this.chartDaily.Location = new System.Drawing.Point(0, 0);
            this.chartDaily.Name = "chartDaily";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartDaily.Series.Add(series12);
            this.chartDaily.Size = new System.Drawing.Size(571, 294);
            this.chartDaily.TabIndex = 4;
            this.chartDaily.Text = "chart1";
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
            this.dataGridViewHistory.Size = new System.Drawing.Size(571, 294);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 517);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Snakeeyes Dashboard";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlCharts.ResumeLayout(false);
            this.tabPageCurrent.ResumeLayout(false);
            this.tabPageHourly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).EndInit();
            this.tabPageDaily.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHourly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
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
    }
}

