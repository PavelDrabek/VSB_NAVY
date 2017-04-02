using System;
namespace EA
{
    public interface ISearchAlgorithm
    {
        Element [] GetPopulation();
        Element GetBest();
        int GetStep();
        void NextGeneration();
    }
}
