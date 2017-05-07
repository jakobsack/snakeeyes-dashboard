using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DashboardLib;
using System.Diagnostics;

namespace DashboardClient
{
    public partial class ProbePanel : UserControl
    {
        public Probe ThisProbe { get; set; }

        public ProbePanel(Probe probe)
        {
            InitializeComponent();
            ThisProbe = probe;

            Width = 200;
            Height = 20;

            Controls.Add(new Label
            {
                Text = probe.TryCommonName(),
                Width = Width - 9,
                Height = 14,
                Top = 3,
                Left = 6
            });

            Controls.Add(new Panel
            {
                Dock = DockStyle.Left,
                BackColor = GetPanelColor(probe),
                Width = 3
            });
        }

        public void RegisterClick(EventHandler eventhandler)
        {
            Click += eventhandler;
            foreach (Control control in Controls)
            {
                control.Click += eventhandler;
            }
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
    }
}
