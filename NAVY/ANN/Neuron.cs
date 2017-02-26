using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ANN
{
    public class Neuron
    {
        public List<Connection> InputConnections { get; set; }
        public List<Connection> OutputConnections { get; set; }

        public int ID { get; private set; }
        public double Value { get; private set; }
        public bool IsEvaluated { get; private set; }

        public Neuron (int id)
        {
            ID = id;
            InputConnections = new List<Connection> ();
            OutputConnections = new List<Connection> ();
        }

        public void SetValue (int value)
        {
            Value = value;
            IsEvaluated = true;
        }

        public void Evaluate ()
        {
            double result = 0;
            for (int i = 0; i < InputConnections.Count; i++) {
                if (!InputConnections [i].From.IsEvaluated) {
                    InputConnections [i].From.Evaluate ();
                }
                result += InputConnections [i].From.Value * InputConnections [i].Weight;
            }


            Value = result;
            IsEvaluated = true;
        }

        public void Clear ()
        {
            Value = 0;
            IsEvaluated = false;
        }
    }
}
