using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DashboardLib
{
    [Serializable, XmlRoot("Response")]
    public class Response
    {
        [XmlElement("Probe")]
        public List<Probe> Probes { get; set; }

        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Type")]
        public Request.Types Type;
        
        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Response));
            using (StringWriter outputStream = new StringWriter())
            {
                serializer.Serialize(outputStream, this);
                return outputStream.ToString();
            }
        }
    }
}
