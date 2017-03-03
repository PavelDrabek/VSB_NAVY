using System.Collections.Generic;

namespace ANN.Functions
{
    public interface ITransferFunction
    {
        double Evaluate (double x);
    }
}
