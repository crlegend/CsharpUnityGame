using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("GestureCollection")]
public class GestureContainer {
    [XmlArray("Gestures")]
    [XmlArrayItem("Gesture")]
    public List<GestureXml> gestures = new List<GestureXml>();


    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(GestureContainer));
        using(var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static GestureContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(GestureContainer));
        using(var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as GestureContainer;
        }
    }



}
