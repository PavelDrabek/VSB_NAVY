using System.Collections.Generic;
using ANN;
using Cairo;
using XnaGeometry;

namespace NAVY
{
    public class NetworkDrawer
    {
        private NeuronNetwork network;
        private Gdk.Drawable drawable;

        public Color inputColor = new Color (0, 0, 1);
        public Color outputColor = new Color (0, 1, 0);
        public Color insideColor = new Color (0.5, 0.5, 0.5);
        public Color arrowColor = new Color (0, 0, 0);
        public float arrowSize = 3;

        public int nR = 10;
        public int border = 10;
        public int gapX = 10;
        public int gapY = 50;
        public int width, height;
        private Vector2 center; 

        public NetworkDrawer (NeuronNetwork network, Gdk.Drawable drawable)
        {
            this.network = network;
            SetDrawable (drawable);
        }

        public void SetDrawable (Gdk.Drawable drawable)
        {
            this.drawable = drawable;
        }

        public void Draw ()
        {
            drawable.GetSize (out width, out height);
            center = new Vector2 (width / 2, height / 2);

            List<List<Vector2>> points = new List<List<Vector2>> ();
            for (int l = 0; l < network.Layers.Count; l++) {
                List<Vector2> layerPoints = new List<Vector2> ();
                NeuronsLayer layer = network.Layers [l];
                for (int n = 0; n < layer.Neurons.Count; n++) {
                    Vector2 nPos = CalcNeuronPosition (l, network.Layers.Count, n, layer.Neurons.Count);
                    layerPoints.Add (nPos);
                }
                points.Add (layerPoints);
            }


            using (Context g = Gdk.CairoHelper.Create (drawable)) {
                Color neuronColor = inputColor;
                for (int l = 0; l < points.Count; l++) {
                    for (int n = 0; n < points[l].Count; n++) {
                        Vector2 nPos = points[l][n];
                        if (l > 0) {
                            for (int n2 = 0; n2 < points [l-1].Count; n2++) {
                                DrawArrow (g, points [l - 1] [n2], nPos);
                            }
                        }
                        DrawCircle (g, nPos, neuronColor);
                    }
                    neuronColor = l + 2 < points.Count ? insideColor : outputColor;
                }

                //PointD p1, p2, p3, p4;
                //p1 = new PointD (0, 0);
                //p2 = new PointD (width, 0);
                //p3 = new PointD (width, height);
                //p4 = new PointD (0, height);

                ////g.Arc (150, 50, 30, 0, 2 * System.Math.PI);
                //////g.FillPreserve ();

                //g.MoveTo (p1);
                //g.LineTo (p2);
                //g.LineTo (p3);
                //g.LineTo (p4);
                //g.LineTo (p1);
                //g.ClosePath ();

                ////g.SetSourceColor (new Color (0, 1, 0));
                //////g.FillPreserve ();
                //g.SetSourceColor (new Color (1, 0, 0));
                //g.Stroke ();

                g.GetTarget ().Dispose ();
                g.Dispose ();
            }
        }

        private void DrawCircle (Context g, Vector2 pos, Color color)
        {
            g.Arc (pos.X, pos.Y, nR, 0, 2 * System.Math.PI);
            g.SetSourceColor (color);
            g.FillPreserve ();
            g.SetSourceColor (new Color(0,0,0));
            g.Stroke ();
        }

        private void DrawArrow (Context g, Vector2 from, Vector2 to)
        {
            Vector2 dir = Vector2.Normalize(to - from);
            Vector2 start = from + dir * nR;
            Vector2 end = to - dir * nR;

            Vector2 arr1 = end - dir * 2*arrowSize + dir.Left () * arrowSize;
            Vector2 arr2 = end - dir * 2*arrowSize + dir.Right() * arrowSize;

            g.MoveTo (ToPoint(start));
            g.LineTo (ToPoint (end));
            g.LineTo (ToPoint (arr1));
            g.LineTo (ToPoint (arr2));
            g.LineTo (ToPoint(end));
            g.ClosePath ();

            g.SetSourceColor (arrowColor);
            g.Stroke ();
        }

        private Vector2 CalcNeuronPosition (int lIndex, int lCount, int nIndex, int nCount)
        {
            float x = (float)center.X + (((nIndex + 0.5f) / nCount) - 0.5f) * (nCount * (gapX + 2 * nR));
            float y = (float)center.Y - (((lIndex + 0.5f) / lCount) - 0.5f) * (lCount * (gapY + 2 * nR));
            //float y = nR + lIndex * (2 * nR + gapY);

            return new Vector2 (x, y);
        }

        private PointD ToPoint (Vector2 v)
        {
            return new PointD (v.X, v.Y);
        }
    }
}
