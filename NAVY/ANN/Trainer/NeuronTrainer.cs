using System;
using System.Collections.Generic;

namespace ANN.Trainer
{
    public class NeuronTrainer
    {
        public int Epochs { get; set; }
        public double TrainCoef { get; set; } // <0,1>
        public double LearningCoef { get; set; }

        private NeuronNetwork network;
        private TrainingData [] data;

        public NeuronTrainer (NeuronNetwork network, TrainingData[] data)
        {
            this.network = network;
            this.data = data;
        }

        public int Start ()
        {
            for (int i = 0; i < Epochs; i++) {
                if (!TrainCycle ()) {
                    return i + 1;
                }
            }

            return Epochs;
        }

        private bool TrainCycle ()
        {
            bool needTrainer = false;
            for (int i = 0; i < data.Length; i++) {
                needTrainer |= TrainData (data [i]);
            }
            return needTrainer;
        }

        private bool TrainData (TrainingData entry)
        {
            network.SetInputs (entry.input);
            int [] realOutput = network.Evaluate ();
            double delta = entry.output [0] - realOutput [0];

            if (Math.Abs (delta) <= 0) {
                return false;
            }

            List<Connection> connections = network.Layers [network.Layers.Count - 1].Neurons [0].InputConnections;
            for (int i = 0; i < connections.Count; i++) {
                double weightDelta = LearningCoef * delta * entry.input[i];
                connections [i].Weight += weightDelta;
            }
            return true;
        }
    }
}
