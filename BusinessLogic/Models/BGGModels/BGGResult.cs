using System.Collections.Generic;
using System.Xml.Serialization;

namespace BusinessLogic.Models.BGGModels
{
    [XmlType("items")]
    public class BGGResult
    {
        [XmlAttribute("total")]
        public int total { get; set; }

        [XmlAttribute("termsofuse")]
        public string termsofuse { get; set; }

        [XmlElement("item")]
        public List<Item> item { get; set; }
    }

    [XmlType("item")]
    public class Item
    {
        [XmlAttribute("type")]
        public string type { get; set; }

        [XmlAttribute("id")]
        public int ID { get; set; }

        [XmlElement("name")]
        public Name name { get; set; }

        [XmlElement("yearpublished")]
        public YearPublished yearpublished { get; set; }
    }

    [XmlType("name")]
    public class Name
    {
        [XmlAttribute("type")]
        public string type { get; set; }

        [XmlAttribute("value")]
        public string value { get; set; }
    }

    [XmlType("yearpublished")]
    public class YearPublished
    {
        [XmlAttribute("value")]
        public int value { get; set; }
    }
}