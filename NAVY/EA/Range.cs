using System;
namespace EA
{
    public class Range
    {
        public float min;
        public float max;

        public Range (float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float getMin () { return min; }
        public float getMax () { return max; }
        public float getRange () { return max - min; }
    }
}
