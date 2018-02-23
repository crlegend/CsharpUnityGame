using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class GestureXml {


    [XmlAttribute("Name")]
    public string name;

    [XmlElement("Positions")]
    public Vector2[] pos;


}
