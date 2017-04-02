using System;
namespace EA
{
    public class SOMA
    {
        IFunction f;
        Generation generation;
        Random random;

        float pathLength;   // rychle 3
        float pathStep;     // rychle 0.3 | pomalu 0.11
        float PRT;          // rychle 0.3 | pomalu 0.2
        Element best;

        public SOMA (IFunction f, Generation generation, float pathLength, float pathStep, float PT)
        {
            random = new Random ();
            
            this.f = f;
            this.generation = generation;
            this.pathLength = pathLength;
            this.pathStep = pathStep;
            this.PRT = PT;

            if (GetPopulation ().Length < 4) {
                Console.WriteLine ("ERROR: NP (population size) must be 4 or more!");
            }

            for (int i = 0; i < generation.GetPopSize (); i++) {
                generation.population [i].SetFitness (f.getFitness (generation.D, generation.population [i].values));
                if (best == null || generation.population [i].GetFitness () < best.GetFitness ()) {
                    best = generation.population [i];
                }
            }
        }

        public Element [] GetPopulation ()
        {
            return generation.population;
        }

        public Element GetBest ()
        {
            return best;
        }

        public void NextGeneration ()
        {
            Generation nGen = new Generation (generation.D, generation.GetPopSize (), generation.limits);
            for (int i = 0; i < nGen.GetPopSize (); i++) {
                nGen.population [i] = GetNewElement (generation.population [i]);
                if (best == null || nGen.population [i].GetFitness () < best.GetFitness ()) {
                    best = nGen.population [i];
                }
            }
            generation = nGen;
        }

        private Element GetNewElement (Element e)
        {
            Element PTRVector = new Element (e.D);
            for (int i = 0; i < PTRVector.D; i++) {
                PTRVector.values[i] = (random.NextDouble() < PRT) ? 1 : 0;
            }

            Element lBest = null;
            for (int i = 0; i<pathLength / pathStep; i++) {
                Element l = e.add (best.odd (e).mul (pathStep * i).mul (PTRVector));
                l = generation.FixElement(l);
                l.SetFitness(f.getFitness(l.D, l.values));
                if(lBest == null || l.GetFitness() < lBest.GetFitness()) {
                    lBest = l;
                }
            }

            return lBest;
        }
    }
}
