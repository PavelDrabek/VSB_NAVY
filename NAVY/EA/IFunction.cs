using System;
namespace EA
{
    public interface IFunction
    {
        float getLimit ();
        float getFitness (int dimension, float [] values);
    }
}
