using Cairo;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

    protected void OnDrawingAreaExposed (object o, ExposeEventArgs args)
    {
        DrawingArea area = (DrawingArea)o;
        RefreshDrawing (area.GdkWindow);
    }

    protected void RefreshDrawing (Gdk.Drawable drawable)
    {
        using (Cairo.Context g = Gdk.CairoHelper.Create (drawable)) {

            PointD p1, p2, p3, p4;
            p1 = new PointD (80, 10);
            p2 = new PointD (100, 10);
            p3 = new PointD (100, 100);
            p4 = new PointD (10, 100);

            g.Arc (p4.X, p4.Y, 30, 0, 2 * System.Math.PI);
            g.FillPreserve ();

            g.MoveTo (p1);
            g.LineTo (p2);
            g.LineTo (p3);
            g.LineTo (p4);
            g.LineTo (p1);
            g.ClosePath ();

            g.SetSourceColor(new Color (0, 0, 0));
            //g.FillPreserve ();
            g.SetSourceColor (new Color (1, 0, 0));
            g.Stroke ();

            g.GetTarget ().Dispose ();
            g.Dispose ();
        }
    }
}
