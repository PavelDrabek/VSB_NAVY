using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ANN
{
    public class Neuron : SaveableObject
    {
        public List<Connection> Connections { get; set; }

        [XmlAttribute (AttributeName = "id")]
        public int ID { get; private set; }

        public Neuron (int id)
        {
            ID = id;
        }

        public override void Save (XmlWriter writer)
        {
            writer.WriteStartElement ("Neuron");
            writer.WriteAttributeString ("id", ID.ToString());
            writer.WriteEndElement ();
        }
    }
}
