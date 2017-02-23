using System;
using System.Collections.Generic;

namespace ANN
{
    public class Perceptron
    {
        public Perceptron ()
        {
            
        }

        public double evaluate (List<Connection> connections)
        {
            double result = 0;
            for (int i = 0; i < connections.Count; i++) {
                result += /*value[i] * */ connections [i].Weight;
            }
            return result;
        }
    }
}
