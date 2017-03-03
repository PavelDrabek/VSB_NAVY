using System;
using System.Collections.Generic;

namespace ANN.Functions
{
    public class HyptanFunction : ITransferFunction
    {
        public double K { get; private set; }
       
        public HyptanFunction (double k)
        {
            K = k;
        }

        public double Evaluate (double x)
        {
            double result = Math.Pow(Math.E, x) - Math.Pow(Math.E, (-1) * x);
            result /= Math.Pow (Math.E, x) + Math.Pow (Math.E, (-1) * x);
            
            return result;
        }
    }
}
