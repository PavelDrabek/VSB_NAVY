using System.Drawing;
using Cairo;
using Gdk;
using Gtk;

namespace Windows
{
    public partial class ImageWindow : Gtk.Window
    {
        Context cr;
        Bitmap bitmap;
        public int Width { get; private set; }
        public int Height { get; private set; }

        byte [] data;

        public ImageWindow (int width, int height) : base (Gtk.WindowType.Toplevel)
        {
            Width = width;
            Height = height;
            SetSizeRequest (Width, Height);

            this.Build ();



            drawingarea1.ExposeEvent += OnDrawingAreaExposed;

            //Redraw ();
        }

        public void Redraw ()
        {

            //ImageSurface s = new ImageSurface(bitmap.

            using (Context cr = CairoHelper.Create (drawingarea1.GdkWindow)) {
                //cr.Paint ();
                CairoHelper.SetSourcePixbuf (cr, pb, 0.0d, 0.0d);
                cr.Paint ();
                //cr.MoveTo (10, 10);
                //cr.LineTo (20, 20);
                //cr.ClosePath ();
                //cr.SetSourceColor (new Cairo.Color (1, 1, 1));
                //cr.Stroke ();
                

                //cr.GetTarget ().Dispose ();
                //cr.Dispose ();
            }
        }


        protected void OnDrawingAreaExposed (object o, ExposeEventArgs args)
        {
            Redraw ();
        }

    }
}
