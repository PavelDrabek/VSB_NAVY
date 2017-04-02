using System;
using EA;

namespace ANN.Trainer
{
    public class NeuronTrainerEA : NeuronTrainer, IFunction
    {
        SOMA soma;

        public int popSize;
        public float maxError;

        public NeuronTrainerEA (NeuronNetwork network, TrainingData [] data) : base (network, data)
        {
            popSize = 20;
            maxError = 0.2f;

            trainingNetwork = new NeuronNetwork (network);

            Element element = new Element(network.GetWeights ());
            Range [] limits = new Range [element.D];
            for (int i = 0; i < limits.Length; i++) {
                limits [i] = new Range(-1, 1);
            }

            Generation generation = new Generation (element, popSize, limits);

            soma = new SOMA (this, generation, 3f, 0.3f, 0.2f);
        }

        override protected bool TrainCycle ()
        {
            soma.NextGeneration ();
            float error = soma.GetBest ().GetFitness ();
            return error > maxError;
        }

        #region IFunction

        public float getLimit ()
        {
            return 5;
        }

        public float getFitness (int dimension, float [] values)
        {
            trainingNetwork.SetWeights (values);

            float error = 0;
            for (int i = 0; i < data.Length; i++) {
                trainingNetwork.SetInputs (data [i].input);
                int [] realOutput = trainingNetwork.Evaluate ();
                error += GetError (data [i].output, realOutput);
            }
            return error;
        }

        public static float GetError (int [] wanted, int [] real)
        {
            float delta = 0;
            for (int i = 0; i < wanted.Length; i++) {
                delta += Math.Abs (wanted [i] - real [i]);
            }
            return delta;
        }

        #endregion

    }
}
