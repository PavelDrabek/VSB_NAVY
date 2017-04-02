using System;
using System.Collections.Generic;

namespace ANN.Trainer
{
    public class NeuronTrainer
    {
        public int Epochs { get; set; }
        public float TrainCoef { get; set; } // <0,1>
        public float LearningCoef { get; set; }

        protected NeuronNetwork network, trainingNetwork;
        protected TrainingData [] data;

        public NeuronTrainer (NeuronNetwork network, TrainingData[] data)
        {
            this.network = network;
            this.data = data;

            trainingNetwork = new NeuronNetwork (network);
        }

        public int Start ()
        {
            for (int i = 0; i < Epochs; i++) {
                if (!TrainCycle ()) {
                    network.SetWeights (trainingNetwork.GetWeights ());
                    return i + 1;
                }
            }

            network.SetWeights (trainingNetwork.GetWeights ());

            return Epochs;
        }

        virtual protected bool TrainCycle ()
        {
            bool needTrainer = false;
            for (int i = 0; i < data.Length; i++) {
                needTrainer |= TrainData (data [i]);
            }
            return needTrainer;
        }

        private bool TrainData (TrainingData entry)
        {
            trainingNetwork.SetInputs (entry.input);
            int [] realOutput = trainingNetwork.Evaluate ();
            float delta = entry.output [0] - realOutput [0];

            if (Math.Abs (delta) <= 0) {
                return false;
            }

            List<Connection> connections = trainingNetwork.Layers [trainingNetwork.Layers.Count - 1].Neurons [0].InputConnections;
            for (int i = 0; i < connections.Count; i++) {
                float weightDelta = LearningCoef * delta * entry.input[i];
                connections [i].Weight += weightDelta;
            }
            return true;
        }
    }
}
