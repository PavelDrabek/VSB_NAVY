using System;
namespace ANN.Functions
{
    public class PerceptronFunction : ITransferFunction
    {
        public double Evaluate (double x)
        {
            return x < 0 ? 0 : x;
        }
    }
}
