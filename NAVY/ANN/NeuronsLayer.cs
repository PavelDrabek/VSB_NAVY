using System;
using System.Collections.Generic;

namespace ANN
{
    public class NeuronsLayer
    {
        public List<Neuron> Neurons { get; set; }

        public NeuronsLayer (List<Neuron> neurons)
        {
            Neurons = neurons;
        }
    }
}
