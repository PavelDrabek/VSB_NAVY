using System;
using System.Collections.Generic;

namespace ANN
{
    public class NeuronNetwork
    {
        public List<Neuron> Neurons { get; private set; }
        public List<Connection> Connections { get; private set; }
        public List<NeuronsLayer> Layers { get; private set; }

        public NeuronNetwork ()
        {
            Neurons = new List<Neuron>();
            Connections = new List<Connection> ();
            Layers = new List<NeuronsLayer> ();
        }

        public void Generate (int inputs, int layers, int numInLayers)
        {
            List<Neuron> neurons = new List<Neuron> ();
            for (int i = 0; i < inputs; i++) {
                Neuron neuron = new Neuron ();
                neurons.Add (neuron);
            }
            Layers.Add (new NeuronsLayer (neurons));

            for (int i = 0; i < layers; i++) {
                neurons = new List<Neuron> ();
                for (int j = 0; j < numInLayers; j++) {
                    Neuron neuron = new Neuron ();
                    neurons.Add (neuron);
                }
                Layers.Add (new NeuronsLayer (neurons));
            }

            neurons = new List<Neuron> ();
            neurons.Add (new Neuron ());
            Layers.Add (new NeuronsLayer (neurons));
            
        }
    }
}
