using System;
namespace ANN.Functions
{
    public class BinaryFunction : ITransferFunction
    {
        public double K { get; private set; }
        
        public BinaryFunction (double k)
        {
            K = k;
        }

        public double Evaluate (double x)
        {
            return x * K < 0 ? 0 : 1;
        }
    }
}
