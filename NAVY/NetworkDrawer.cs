﻿using System.Collections.Generic;
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

        Dictionary<int, Vector2> neuronPoints = null;

        public NetworkDrawer (NeuronNetwork network, Gdk.Drawable drawable)
        {
            this.network = network;
            neuronPoints = new Dictionary<int, Vector2> ();
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

            neuronPoints.Clear();
            for (int l = 0; l < network.Layers.Count; l++) {
                NeuronsLayer layer = network.Layers [l];
                for (int n = 0; n < layer.Neurons.Count; n++) {
                    Vector2 nPos = CalcNeuronPosition (l, network.Layers.Count, n, layer.Neurons.Count);
                    neuronPoints [layer.Neurons [n].ID] = nPos;
                }
            }

            using (Context g = Gdk.CairoHelper.Create (drawable)) {
                g.SetSourceRGB (1, 1, 1);
                g.Paint ();

                foreach (var connection in network.Connections) {
                    DrawArrow (g, neuronPoints[connection.From.ID], neuronPoints [connection.To.ID]);
                }
                Color neuronColor = inputColor;
                for (int i = 0; i < network.Layers.Count; i++) {
                    foreach (var neuron in network.Layers [i].Neurons) {
                        DrawCircle (g, neuronPoints [neuron.ID], neuronColor);
                    }
                    neuronColor = i + 2 < network.Layers.Count ? insideColor : outputColor;
                }

                g.GetTarget ().Dispose ();
                g.Dispose ();
            }
        }

        private void DrawCircle (Context g, Vector2 pos, Color color)
        {
            g.Arc (pos.X, pos.Y, nR, 0, 2 * System.Math.PI);
            g.SetSourceRGB (color.R, color.G, color.B);
            g.FillPreserve ();
            g.SetSourceRGB(0,0,0);
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

            g.SetSourceRGB(arrowColor.R, arrowColor.G, arrowColor.B);
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

        public Neuron GetNeuronOnPostion (Vector2 position)
        {
            Neuron found = null;
            double closestDistance = double.MaxValue;
            foreach (var item in neuronPoints) {
                double distance = Vector2.Distance (item.Value, position);
                if (distance <= nR && distance < closestDistance) {
                    closestDistance = distance;
                    found = network.GetNeuron (item.Key);
                }
            }

            return found;
        }
    }
}
