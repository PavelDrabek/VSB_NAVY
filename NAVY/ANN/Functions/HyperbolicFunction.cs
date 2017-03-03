using System;
using System.Collections.Generic;

namespace ANN.Functions
{
    public class HyperbolicFunction : ITransferFunction
    {
        public double K { get; private set; }
       
        public HyperbolicFunction (double k)
        {
            K = k;
        }

        public double Evaluate (double x)
        {
            double result = Math.Pow(Math.E, x) - Math.Pow(Math.E, -x * K);
            result /= Math.Pow (Math.E, x) + Math.Pow (Math.E, -x * K);
            
            return result;
        }
    }
}
