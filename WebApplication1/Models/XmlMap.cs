using System;
using System.IO;
using System.Web.Script.Serialization; 
using System.Xml;
using System.Xml.Serialization;


namespace WebApplication1.Models
{
    
    [XmlElement]
    public class XmlElem
    {

    }

    [XmlRoot("Items")]
    public class XmlMap
    {
        [XmlElement]
        public List<XmlElem> 
    }
}