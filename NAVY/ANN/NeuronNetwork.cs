using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ANN
{
    [Serializable]
    public class NeuronNetwork
    {
        public List<Neuron> Neurons { get; private set; }
        public List<Connection> Connections { get; private set; }
        public List<NeuronsLayer> Layers { get; private set; }

        public event EventHandler<EventArgs> OnNeuralNetworkChanged;

        public NeuronNetwork ()
        {
            Neurons = new List<Neuron>();
            Connections = new List<Connection> ();
            Layers = new List<NeuronsLayer> ();
        }

        public void Generate (int inputs, int layers, int numInLayers)
        {
            int neuronId = 1;
            List<Neuron> neuronsInLayer = new List<Neuron> ();
            for (int i = 0; i < inputs; i++) {
                Neuron neuron = new Neuron (neuronId++);
                neuronsInLayer.Add (neuron);
            }
            Layers.Add (new NeuronsLayer (neuronsInLayer));
            Neurons.AddRange (neuronsInLayer);

            for (int i = 0; i < layers; i++) {
                neuronsInLayer = new List<Neuron> ();
                for (int j = 0; j < numInLayers; j++) {
                    Neuron neuron = new Neuron (neuronId++);
                    neuronsInLayer.Add (neuron);
                }
                Layers.Add (new NeuronsLayer (neuronsInLayer));
                Neurons.AddRange (neuronsInLayer);
            }

            neuronsInLayer = new List<Neuron> ();
            neuronsInLayer.Add (new Neuron (neuronId++));
            Layers.Add (new NeuronsLayer (neuronsInLayer));
            Neurons.AddRange (neuronsInLayer);

            for (int i = 1; i < Layers.Count; i++) {
                for (int n1 = 0; n1 < Layers[i].Neurons.Count; n1++) {
                    for (int n2 = 0; n2 < Layers [i-1].Neurons.Count; n2++) {
                        Connections.Add (
                            new Connection (
                                Layers [i-1].Neurons [n2], 
                                Layers [i].Neurons [n1],
                                1
                            )
                        );
                    }
                }
            }

            SendOnNetworkChanged ();
        }

        public void Load (XmlNode data)
        {
            Neurons = new List<Neuron> ();
            Connections = new List<Connection> ();
            Layers = new List<NeuronsLayer> ();

            if (data.Name.Equals ("NeuronNetwork")) {
                foreach (XmlNode node in data.ChildNodes) {
                    if (node.Name.Equals ("Neuron")) {
                        int id = int.Parse (node.Attributes ["id"].Value);
                        Neuron n = new Neuron (id);
                        Neurons.Add (n);
                    } else if (node.Name.Equals ("Layer")) {
                        List<Neuron> neuronsInLayer = new List<Neuron> ();
                        int index = int.Parse (node.Attributes ["index"].Value);
                        foreach (XmlNode node2 in node.ChildNodes) {
                            if (node2.Name.Equals ("Neuron")) {
                                int nId = int.Parse (node2.Attributes ["id"].Value);
                                neuronsInLayer.Add (GetNeuron (nId));
                            }
                        }
                        Layers.Add (new NeuronsLayer(neuronsInLayer));
                    } else if (node.Name.Equals ("Connection")) {
                        int from = int.Parse (node.Attributes ["from"].Value);
                        int to = int.Parse (node.Attributes ["to"].Value);
                        double weight = double.Parse (node.Attributes ["weight"].Value);
                        Connection c = new Connection (GetNeuron(from), GetNeuron(to), weight);
                        Connections.Add (c);
                    }
                }
            }

            SendOnNetworkChanged ();
        }

        public void Save (XmlWriter writer)
        {
            writer.WriteStartElement ("NeuronNetwork");

            //writer.WriteStartElement ("Neurons");
            for (int i = 0; i < Neurons.Count; i++) {
                writer.WriteStartElement ("Neuron");
                writer.WriteAttributeString ("id", Neurons[i].ID.ToString ());
                writer.WriteEndElement ();
            }
            //writer.WriteEndElement ();

            //writer.WriteStartElement ("Layers");
            for (int i = 0; i < Layers.Count; i++) {
                writer.WriteStartElement ("Layer");
                writer.WriteAttributeString ("index", i.ToString());
                for (int j = 0; j < Layers[i].Neurons.Count; j++) {
                    writer.WriteStartElement ("Neuron");
                    writer.WriteAttributeString ("id", Layers[i].Neurons[j].ID.ToString ());
                    writer.WriteEndElement ();
                }
                writer.WriteEndElement ();
            }
            //writer.WriteEndElement ();

            //writer.WriteStartElement ("Connections");
            for (int i = 0; i < Connections.Count; i++) {
                writer.WriteStartElement ("Connection");
                writer.WriteAttributeString ("from", Connections[i].From.ID.ToString ());
                writer.WriteAttributeString ("to", Connections [i].To.ID.ToString ());
                writer.WriteAttributeString ("weight", Connections [i].Weight.ToString ());
                writer.WriteEndElement ();
            }
            //writer.WriteEndElement ();

            writer.WriteEndElement ();
            
        }

        private Neuron GetNeuron (int id)
        {
            return Neurons.Find((obj) => obj.ID == id);
        }

        private void SendOnNetworkChanged ()
        {
            if (OnNeuralNetworkChanged != null) {
                OnNeuralNetworkChanged (this, EventArgs.Empty);
            }
        }
    }
}
