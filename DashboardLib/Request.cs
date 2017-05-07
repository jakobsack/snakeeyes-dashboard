using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DashboardLib
{
    [Serializable, XmlRoot("Request")]
    public class Request
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Type")]
        public Types Type;

        [XmlElement("Probe")]
        public string ProbeId { get; set; }

        [XmlElement("CommonName")]
        public string CommonName { get; set; }

        [XmlElement("SizeType")]
        public Probe.SizeTypeEnum SizeType { get; set; }

        public Request()
        {
            Id = Guid.NewGuid().ToString();
            Type = Types.Probes;
            ProbeId = "";
            CommonName = "";
            SizeType = Probe.SizeTypeEnum.None;
        }

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Request));
            using (StringWriter outputStream = new StringWriter())
            {
                serializer.Serialize(outputStream, this);
                return outputStream.ToString();
            }
        }

        public enum Types { Probes, History, Edit };
    }
}
