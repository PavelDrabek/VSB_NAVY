using System;
namespace EA
{
    public class Generation
    {
        public Range [] limits { get; private set; }
        public Element [] population;

        public bool IsDiscrete { get { return false; } }
        
        public int GetPopSize () { return population.Length; }
        public int D { get; private set; }

        private Generation (Range [] limits)
        {
            this.limits = limits;
        }

        public Generation (int dimension, int popSize, Range [] limits) : this(limits)
        {
            this.D = dimension;
            SetPopSize (popSize);
        }

        public Generation (Element element, int popSize, Range [] limits) : this (element.D, popSize, limits)
        {
            population [0] = new Element(element);
        }

        public void SetPopSize (int popSize)
        {
            population = new Element [popSize];
            for (int i = 0; i < popSize; i++) {
                population [i] = GenerateElementInRange ();
            }
        }

        private Element GenerateElementInRange ()
        {
            Random random = new Random ();
            float [] values = new float [D];
            for (int i = 0; i < D; i++) {
                values [i] = (float)(limits [i].min + random.NextDouble () * limits [i].getRange());
            }

            return new Element(values);
        }

        public Element FixElement (Element el)
        {
            for (int i = 0; i < el.D; i++) {
                el.values [i] = FixToRangeLoop (el.values [i], limits [i]);
                if (IsDiscrete) {
                    el.values [i] = FixToDiscrete (el.values [i]);
                }
            }
            return el;
        }

        private int FixToDiscrete (float x)
        {
            return (int)Math.Round (x);
        }

        private float FixToRangeLoop (float x, Range limit)
        {
            while (x < limit.getMin ()) {
                x += limit.getRange ();
            }
            while (x > limit.getMax ()) {
                x -= limit.getRange ();
            }
            return x;
        }

        private float FixToRangeClamp (float x, Range limit)
        {
            if (x < limit.getMin ()) {
                x = limit.getMin ();
            }
            if (x > limit.getMax ()) {
                x = limit.getMax ();
            }
            return x;
        }

    }
}
