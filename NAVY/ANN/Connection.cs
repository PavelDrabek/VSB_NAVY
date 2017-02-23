using System;
using System.Xml;

namespace ANN
{
    public class Connection : SaveableObject
    {
        public Neuron From { get; private set; }
        public Neuron To { get; private set; }
        public double Weight { get; private set; }

        public Connection (Neuron from, Neuron to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }



        public override void Save (XmlWriter writer)
        {
            writer.WriteStartElement ("Connection");
            writer.WriteAttributeString ("from", From.ID.ToString ());
            writer.WriteAttributeString ("to", To.ID.ToString ());
            writer.WriteAttributeString ("weight", Weight.ToString ());
            writer.WriteEndElement ();
        }
    }
}
