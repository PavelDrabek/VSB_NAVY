using System;
using System.Xml;
using ANN;
using Gdk;
using Gtk;
using NAVY;
using Windows;
using XnaGeometry;

public partial class MainWindow : Gtk.Window
{
    private NAVY.NetworkDrawer networkDrawer;
    private NeuronNetwork network;

    private Neuron selectedNeuron;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
        network = new NeuronNetwork ();
        network.OnNeuralNetworkChanged += OnNeuronNetworkChanged;
        networkDrawer = new NAVY.NetworkDrawer (network, drawingarea.GdkWindow);

        drawingarea.AddEvents ((int)
            (EventMask.ButtonPressMask
            | EventMask.ButtonReleaseMask
            | EventMask.KeyPressMask
            | EventMask.PointerMotionMask));

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
        new NewNetworkDialog (network).Show ();
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

    protected void OnDrawingareaButtonPressEvent (object o, ButtonPressEventArgs args)
    {
        Vector2 point = new Vector2 (args.Event.X, args.Event.Y);
        selectedNeuron = networkDrawer.GetNeuronOnPostion (point);

        if (selectedNeuron != null) {
            new NeuronWindow (selectedNeuron).Show ();
        }
    }

    protected void OnTrainNetworkActivated (object sender, EventArgs e)
    {
        new TrainerWindow (network).Show ();
    }
}
