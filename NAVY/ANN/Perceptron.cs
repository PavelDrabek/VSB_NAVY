using System;
using System.Collections.Generic;

namespace ANN
{
    public class Perceptron
    {
        public Perceptron ()
        {
            
        }

        public double evaluate (List<Input> inputs)
        {
            double result = 0;
            for (int i = 0; i < inputs.Count; i++) {
                result += inputs [i].value * inputs [i].weight;
            }
            return result;
        }
    }
}
