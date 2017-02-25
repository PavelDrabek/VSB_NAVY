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

    protected void OnNewActionActivated (object sender, EventArgs e)
    {
        network.Generate (2, 2, 3);
    }

    protected void OnOpenActionActivated (object sender, EventArgs e)
    {
        Gtk.FileChooserDialog filechooser =
        new Gtk.FileChooserDialog ("Choose the file to open",
            this,
            FileChooserAction.Open,
            "Cancel", ResponseType.Cancel,
            "Open", ResponseType.Accept);

        if (filechooser.Run () == (int)ResponseType.Accept) {
            XmlDocument doc = new XmlDocument ();
            doc.Load (filechooser.Filename);

            XmlNode node = doc.DocumentElement.SelectSingleNode ("/NeuronNetwork");
            network.Load (node);
        }

        filechooser.Destroy ();
    }

    protected void OnSaveActionActivated (object sender, EventArgs e)
    {
        Gtk.FileChooserDialog filechooser =
        new Gtk.FileChooserDialog ("Choose the file to save",
            this,
            FileChooserAction.Open,
            "Cancel", ResponseType.Cancel,
            "Save", ResponseType.Accept);

        if (filechooser.Run () == (int)ResponseType.Accept) {
            using (var writer = XmlWriter.Create (filechooser.Filename)) {
                network.Save (writer);
            }
        }

        filechooser.Destroy ();
    }

    protected void OnBtnEvaluateEntered (object sender, EventArgs e)
    {

    }

    protected void OnBtnEvaluateClicked (object sender, EventArgs e)
    {
        string [] str = entryInput.Text.Split (';');
        int [] input = new int [str.Length];
        for (int i = 0; i < str.Length; i++) {
            if (!int.TryParse (str [i], out input [i])) {
                return;
            }
        }

        network.SetInputs (input);
        network.Evaluate ();

        entryOutput.Text = string.Join (";", network.GetOutput ());
    }
}
