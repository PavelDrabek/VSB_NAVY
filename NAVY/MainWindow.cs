using System;
using System.Xml;
using Gtk;

public partial class MainWindow : Gtk.Window
{

    private NAVY.NetworkDrawer networkDrawer;
    private ANN.NeuronNetwork network;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
        network = new ANN.NeuronNetwork ();
        network.OnNeuralNetworkChanged += OnNeuronNetworkChanged;
        networkDrawer = new NAVY.NetworkDrawer (network, drawingarea.GdkWindow);
        network.Generate (2, 2, 3);
        RefreshDrawing ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

    protected void OnDrawingAreaExposed (object o, ExposeEventArgs args)
    {
        RefreshDrawing ();
    }

    protected void RefreshDrawing ()
    {
        networkDrawer.Draw ();
    }

    protected void OnDrawingareaScreenChanged (object o, ScreenChangedArgs args)
    {
        RefreshDrawing ();
    }

    protected void OnNeuronNetworkChanged (object sender, System.EventArgs e)
    {
        RefreshDrawing ();
    }

    protected void OnBtnSaveClicked (object sender, System.EventArgs e)
    {
        using (var writer = XmlWriter.Create ("test.xml")) {
            network.Save (writer);
        }
    }

    protected void OnBtnLoadClicked (object sender, System.EventArgs e)
    {
        XmlDocument doc = new XmlDocument ();
        doc.Load ("test.xml");

        XmlNode node = doc.DocumentElement.SelectSingleNode ("/NeuronNetwork");
        network.Load(node);
    }
}
