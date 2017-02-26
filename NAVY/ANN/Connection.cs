using System;
using System.Xml;

namespace ANN
{
    public class Connection
    {
        public Neuron From { get; private set; }
        public Neuron To { get; private set; }
        public double Weight { get; set; }

        public Connection (Neuron from, Neuron to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}
