using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    [XmlRoot("Items")]
    public class Items
    {
        [XmlElement("Item")]
        public List<Item> itemList = new List<Item>();
    }

    public class ID
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
    }

    public class ID_Column
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlAttribute("index")]
        public int index { get; set; }
    }

    public class Size
    {
        [XmlAttribute("width")]
        public int width { get; set; }
        [XmlAttribute("height")]
        public int height { get; set; }
    }

    public class Location
    {
        [XmlAttribute("x")]
        public int x { get; set; }
        [XmlAttribute("y")]
        public int y { get; set; }
    }

    public class Column
    {
        [XmlElement("ID")]
        public ID_Column id { get; set; }
        [XmlElement("Size")]
        public Size size { get; set; }
    }

    public class Columns
    {
        [XmlElement("Column")]
        public List<Column> columnList = new List<Column>();
    }

    public class Item
    {

        [XmlElement("ID")]
        public ID id { get; set; }
        [XmlElement("Size")]
        public Size size { get; set; }
        [XmlElement("Location")]
        public Location location { get; set; }

        [XmlElement("Columns")]
        public Columns columns { get; set; }
    }

    public class XMLModel
    {

    }
}