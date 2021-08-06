using System.Collections.Generic;
using System.Xml.Serialization;

namespace DynamicsFscmPackageApiSamples.Common.Models
{
    [XmlRoot(ElementName = "Document")]
    public class EntityDocument<T>
    {
        public List<T> Entity { get; set; }
    }
}
