using Gtk;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Drawing;
using System;
using Windows;

public partial class MainWindow : Gtk.Window
{
    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
        Build ();

        //using (Image<Bgr, byte> img = new Image<Bgr, byte> (400, 200, new Bgr (255, 0, 0))) {
        //    //Create the font
        //    MCvFont f = new MCvFont (FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);

        //    //Draw "Hello, world." on the image using the specific font
        //    img.Draw ("Hello, world", ref f, new Point (10, 80), new Bgr (0, 255, 0));

        //    //Show the image using ImageViewer from Emgu.CV.UI
        //    ImageViewer.Show (img, "Test Window");
        //}
        ImageWindow w = new ImageWindow (300, 200);
        w.Show ();
        w.Redraw ();
    }

    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
        Application.Quit ();
        a.RetVal = true;
    }
}
