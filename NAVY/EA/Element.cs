namespace EA
{
    public class Element
    {
        public int D { get; private set; }
        public float [] values;
        public float Fitness { get; set; }

        public Element (int D)
        {
            this.D = D;
            values = new float [D];
        }

        public Element (float[] values) : this (values.Length)
        {
            for (int i = 0; i < D; i++) {
                this.values [i] = values [i];
            }
        }

        public Element (Element orig) : this(orig.values) { }

        public float GetFitness ()
        {
            return Fitness;
        }

        public void SetFitness (float fitness)
        {
            Fitness = fitness;
        }




        public Element odd (Element other)
        {
            Element result = new Element (this);
            for (int i = 0; i < result.D; i++) {
                result.values[i] = values[i] - other.values[i];
            }
            return result;
        }

        public Element add (Element other)
        {
            Element result = new Element (this);
            for (int i = 0; i < result.D; i++) {
                result.values[i] = values[i] + other.values[i];
            }
            return result;
        }

        public Element mul (float scalar)
        {
            Element result = new Element (this);
            for (int i = 0; i < result.D; i++) {
                result.values[i] = values[i] * scalar;
            }
            return result;
        }

        public Element mul (Element e)
        {
            Element result = new Element (this);
            for (int i = 0; i < result.D; i++) {
                result.values[i] = values[i] * e.values[i];
            }
            return result;
        }
    }
}
