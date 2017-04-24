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

namespace DashboardClient
{
    public partial class ProbePanel : UserControl
    {
        public Probe ThisProbe { get; set; }

        public ProbePanel(Probe probe)
        {
            InitializeComponent();
            ThisProbe = probe;

            Controls.Add(new Label
            {
                Text = String.Format("M: {0}", probe.Machine),
                Width = Width - 10,
                Height = 14,
                Top = 5,
                Left = 5
            });
            Controls.Add(new Label
            {
                Text = String.Format("N: {0}", probe.ProbeName),
                Width = Width - 10,
                Height = 14,
                Top = 20,
                Left = 5
            });
            Controls.Add(new Label
            {
                Text = String.Format("T: {0}", probe.ProbeType),
                Width = Width - 10,
                Height = 14,
                Top = 35,
                Left = 5
            });
            Controls.Add(new Label
            {
                Text = String.Format("S: {0}", probe.LastState),
                Width = Width - 10,
                Height = 14,
                Top = 50,
                Left = 5
            });

            Controls.Add(new Label
            {
                Text = String.Format("D: {0}", probe.LastTimestamp),
                Width = Width - 10,
                Height = 14,
                Top = 70,
                Left = 5
            });

            if (probe.MaxValue.HasValue)
            {
                Controls.Add(new Label
                {
                    Text = String.Format("< {0}", probe.MaxValue.Value),
                    Width = Width - 10,
                    Height = 14,
                    Top = 100,
                    Left = 5,
                    
                });
            }
            Controls.Add(new Label
            {
                Text = String.Format("= {0}", probe.LastValue.Value),
                Width = Width - 10,
                Height = 14,
                Top = 115,
                Left = 5
            });
            if (probe.MinValue.HasValue)
            {
                Controls.Add(new Label
                {
                    Text = String.Format("> {0}", probe.MinValue.Value),
                    Width = Width - 10,
                    Height = 14,
                    Top = 130,
                    Left = 5
                });
            }
        }

        public void RegisterClick(EventHandler eventhandler)
        {
            Click += eventhandler;
            foreach(Control control in Controls)
            {
                control.Click += eventhandler;
            }
        }
    }
}
