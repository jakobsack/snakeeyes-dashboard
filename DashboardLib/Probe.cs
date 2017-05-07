using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DashboardLib
{
    [Serializable, XmlRoot("Probe")]
    public class Probe
    {
        [XmlElement("Machine")]
        public string Machine { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("LastState")]
        public TraceEventType LastState { get; set; }

        [XmlElement("LastTimestamp")]
        public DateTime LastTimestamp { get; set; }

        [XmlElement("LastMessage")]
        public string LastMessage { get; set; }

        [XmlElement("MinValue")]
        public double? MinValue { get; set; }

        [XmlElement("MaxValue")]
        public double? MaxValue { get; set; }

        [XmlElement("LastValue")]
        public double? LastValue { get; set; }

        [XmlElement("History")]
        public List<HistoryItem> History { get; set; }

        [XmlElement("CommonName")]
        public string CommonName { get; set; }

        [XmlElement("SizeType")]
        public SizeTypeEnum SizeType;

        public string ProbeName
        {
            get
            {
                return Name.Substring(0, Name.LastIndexOf('.'));
            }
        }

        public string ProbeType
        {
            get
            {
                return Name.Substring(Name.LastIndexOf('.') + 1);
            }
        }

        public string Id
        {
            get
            {
                return String.Join("_", (Machine + "__" + Name).Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
            }
        }

        Probe()
        {
            Machine = "";
            Name = "";
            LastState = TraceEventType.Critical;
            History = new List<DashboardLib.HistoryItem>();
            LastMessage = "";
        }

        public static Probe FromTraceEvent(XmlDocument xml)
        {
            XmlNode traceNode = xml.SelectSingleNode("TraceEvent");
            Enum.TryParse<TraceEventType>(traceNode.SelectSingleNode("EventType").InnerText, out TraceEventType type);

            Probe probe = new Probe
            {
                Machine = traceNode.SelectSingleNode("MachineName").InnerText,
                Name = traceNode.SelectSingleNode("Source").InnerText,
                LastState = type,
                LastTimestamp = DateTime.Parse(traceNode.SelectSingleNode("Timestamp").InnerText),
                LastMessage = traceNode.SelectSingleNode("Message").InnerText,
            };

            if (traceNode.SelectSingleNode("Value") != null && traceNode.SelectSingleNode("Value").InnerText.Trim() != "")
            {
                probe.LastValue = Double.Parse(traceNode.SelectSingleNode("Value").InnerText);
            }
            if (traceNode.SelectSingleNode("MaxValue") != null && traceNode.SelectSingleNode("MaxValue").InnerText.Trim() != "")
            {
                probe.MaxValue = Double.Parse(traceNode.SelectSingleNode("MaxValue").InnerText);
            }
            if (traceNode.SelectSingleNode("MinValue") != null && traceNode.SelectSingleNode("MinValue").InnerText.Trim() != "")
            {
                probe.MinValue = Double.Parse(traceNode.SelectSingleNode("MinValue").InnerText);
            }

            return probe;
        }

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Probe));
            using (StringWriter outputStream = new StringWriter())
            {
                serializer.Serialize(outputStream, this);
                return outputStream.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public Probe StripHistory()
        {
            return new Probe
            {
                History = new List<HistoryItem>(),
                LastState = LastState,
                Name = Name,
                Machine = Machine,
                LastMessage = LastMessage,
                LastTimestamp = LastTimestamp,
                LastValue = LastValue,
                MaxValue = MaxValue,
                MinValue = MinValue,
                CommonName = CommonName,
                SizeType = SizeType
            };
        }

        public string TryCommonName()
        {
            return String.IsNullOrWhiteSpace(CommonName) ? ProbeName : CommonName;
        }

        public void CompressHistory()
        {
            DateTime now = DateTime.Now;
            DateTime upToHourly = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            DateTime upToDaily = new DateTime(now.Year, now.Month, now.Day);

            // First compress data to hourly
            List<HistoryItem> toCompress = History.Where(x => x.Timestamp < upToHourly && x.Aggregation == HistoryItem.Aggregations.None).ToList();
            List<string> dates = toCompress.Select(x => x.Timestamp.ToString("yyyyMMddHH")).Distinct().ToList();
            foreach (string date in dates)
            {
                Compress(HistoryItem.Aggregations.Hourly, toCompress.Where(x => x.Timestamp.ToString("yyyyMMddHH") == date));
            }

            // Then compress to daily
            toCompress = History.Where(x => x.Timestamp < upToDaily && x.Aggregation == HistoryItem.Aggregations.Hourly).ToList();
            dates = toCompress.Select(x => x.Timestamp.ToString("yyyyMMdd")).Distinct().ToList();
            foreach (string date in dates)
            {
                Compress(HistoryItem.Aggregations.Daily, toCompress.Where(x => x.Timestamp.ToString("yyyyMMdd") == date));
            }

            // Then we delete old data
            DateTime deleteCurrent = now.AddDays(-1);
            History.RemoveAll(x => x.Aggregation == HistoryItem.Aggregations.None && x.Timestamp < deleteCurrent);
            DateTime deleteHourly = now.AddMonths(-1);
            History.RemoveAll(x => x.Aggregation == HistoryItem.Aggregations.Hourly && x.Timestamp < deleteHourly);
            DateTime deleteDaily = now.AddYears(-2);
            History.RemoveAll(x => x.Aggregation == HistoryItem.Aggregations.Daily && x.Timestamp < deleteDaily);

            History.Sort((x, y) => x.Timestamp.CompareTo(y.Timestamp));
        }

        private void Compress(HistoryItem.Aggregations mode, IEnumerable<HistoryItem> items)
        {
            if (items.Count() == 0)
            {
                return;
            }

            HistoryItem first = items.First();
            DateTime newTimeStamp = first.Timestamp;
            newTimeStamp = newTimeStamp.AddMilliseconds(-newTimeStamp.Millisecond).AddSeconds(-newTimeStamp.Second).AddMinutes(-newTimeStamp.Minute);
            if (mode == HistoryItem.Aggregations.Daily) newTimeStamp = newTimeStamp.AddHours(-newTimeStamp.Hour);

            // Skip the rest if this aggregation already exists
            if (History.Exists(x => x.Aggregation == mode && x.Timestamp == newTimeStamp))
            {
                return;
            }

            double min = first.Min;
            double max = first.Max;

            double sum = 0.0;
            int counter = 0;

            foreach (HistoryItem item in items)
            {
                if (item.Min < min) min = item.Min;
                if (item.Max > max) max = item.Max;

                sum += item.Avg;
                counter++;
            }


            // Create and add new HistoryItem
            HistoryItem compressedSet = new HistoryItem()
            {
                Min = min,
                Max = max,
                Avg = sum / counter,
                Timestamp = newTimeStamp,
                Aggregation = mode
            };
            History.Add(compressedSet);
        }

        public enum SizeTypeEnum { None, Bytes, Percent }
    }
}
