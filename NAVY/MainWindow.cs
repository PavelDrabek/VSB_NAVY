using Cairo;
using Gtk;

public partial class MainWindow : Gtk.Window
{

    private NAVY.NetworkDrawer networkDrawer;
    private ANN.NeuronNetwork network;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
        network = new ANN.NeuronNetwork ();
        networkDrawer = new NAVY.NetworkDrawer (network, drawingarea.GdkWindow);
        network.Generate (2, 2, 3);
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
        networkDrawer.Draw ();
    }

    protected void OnDrawingareaScreenChanged (object o, ScreenChangedArgs args)
    {
        networkDrawer.Draw ();
    }
}
