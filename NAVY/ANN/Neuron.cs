using System;
using System.Collections.Generic;

namespace ANN
{
    public class Neuron
    {
        public List<Connection> Connections { get; set; }
        public int ID { get; private set; }

        public Neuron (int id)
        {
            ID = id;
        }

    }
}
