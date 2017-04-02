using System;
using System.Xml;

namespace ANN
{
    public class Connection
    {
        public Neuron From { get; private set; }
        public Neuron To { get; private set; }
        public float Weight { get; set; }

        public Connection (Neuron from, Neuron to, float weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}
