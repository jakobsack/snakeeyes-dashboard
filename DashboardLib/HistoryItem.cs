using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DashboardLib
{
    [Serializable, XmlRoot("HistoryItem")]
    public class HistoryItem
    {
        [XmlElement("Min")]
        public double Min { get; set; }

        [XmlElement("Avg")]
        public double Avg { get; set; }

        [XmlElement("Max")]
        public double Max { get; set; }

        [XmlElement("Aggregation")]
        public Aggregations Aggregation { get; set; }

        [XmlElement("Timestamp")]
        public DateTime Timestamp { get; set; }

        public HistoryItem()
        {
            Min = 0.0;
            Avg = 0.0;
            Max = 0.0;
            Aggregation = Aggregations.None;
            Timestamp = DateTime.MinValue;
        }

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HistoryItem));
            using (StringWriter outputStream = new StringWriter())
            {
                serializer.Serialize(outputStream, this);
                return outputStream.ToString();
            }
        }

        public static HistoryItem FromProbe(Probe probe)
        {
            if (!probe.LastValue.HasValue)
            {
                return null;
            }
            return new HistoryItem()
            {
                Min = probe.LastValue.Value,
                Max = probe.LastValue.Value,
                Avg = probe.LastValue.Value,
                Aggregation = Aggregations.None,
                Timestamp = probe.LastTimestamp
            };
        }

        public enum Aggregations { None, Hourly, Daily };
    }
}
