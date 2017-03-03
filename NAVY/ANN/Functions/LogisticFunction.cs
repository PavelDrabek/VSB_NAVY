using System;
namespace ANN.Functions
{
    public class LogisticFunction : ITransferFunction
    {
        public double K { get; private set; }

        public LogisticFunction (double k)
        {
            K = k;
        }

        public double Evaluate (double x)
        {
            return 1 / (1 + Math.Pow (Math.E, -x * K));
        }
    }
}
