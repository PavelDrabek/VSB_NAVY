using System;
using System.Collections.Generic;
using System.IO;
using ANN;
using ANN.Trainer;
using Gtk;
using NAVY;

namespace Windows
{
    public partial class TrainerWindow : Gtk.Window
    {
        private List<TrainingData> data;

        private NeuronNetwork network;

        public TrainerWindow (NeuronNetwork network) : base (Gtk.WindowType.Toplevel)
        {
            this.Build ();
            this.network = network;
            data = new List<TrainingData>();

            nodeview.AppendColumn ("Input", new Gtk.CellRendererText (), "text", 0);
            nodeview.AppendColumn ("Output", new Gtk.CellRendererText (), "text", 1);
            nodeview.ShowAll ();

        }

        private void Load (string path)
        {
            StreamReader file = File.OpenText (path);
            string s = file.ReadToEnd ();
            file.Close ();

            data.Clear ();
            nodeview.NodeStore = new NodeStore (typeof(TrainingDataNode));
            string [] lines = s.Split ('\n');
            for (int i = 0; i < lines.Length; i++) {
                string [] parts = lines [i].Split (';');
                if (parts.Length != 2) {
                    continue;
                }
                string [] input = parts [0].Split (' ');
                string [] output = parts [1].Split (' ');
                if (input.Length <= 0 || output.Length <= 0) {
                    continue;
                }

                TrainingData entry = new TrainingData ();
                entry.input = new int [input.Length];
                for (int j = 0; j < input.Length; j++) {
                    int.TryParse(input[j], out entry.input [j]);
                }
                entry.output = new int [output.Length];
                for (int j = 0; j < output.Length; j++) {
                    int.TryParse (output [j], out entry.output [j]);
                }
                data.Add (entry);
                nodeview.NodeStore.AddNode (new TrainingDataNode (parts[0], parts[1]));
            }

        }

        private void Save (string path)
        {
            StreamWriter writer = new StreamWriter (path);
            writer.Write ("");
            writer.Close ();
        }

        private void Refresh ()
        {

        }

        protected void OnNewActionActivated (object sender, EventArgs e)
        {
        }

        protected void OnOpenActionActivated (object sender, EventArgs e)
        {
            Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog ("Choose the file to open",
                 this,
                 FileChooserAction.Open,
                 "Cancel", ResponseType.Cancel,
                 "Open", ResponseType.Accept);

            if (filechooser.Run () == (int)ResponseType.Accept) {
                Load (filechooser.Filename);
            }

            filechooser.Destroy ();
        }

        protected void OnSaveActionActivated (object sender, EventArgs e)
        {
            Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog ("Choose the file to save",
                 this,
                 FileChooserAction.Open,
                 "Cancel", ResponseType.Cancel,
                 "Save", ResponseType.Accept);

            if (filechooser.Run () == (int)ResponseType.Accept) {
                Save (filechooser.Filename);
            }

            filechooser.Destroy ();
        }

        protected void OnYesActionActivated (object sender, EventArgs e)
        {
            NeuronTrainer trainer = new NeuronTrainer (network, data.ToArray ());
            trainer.Epochs = 50;
            trainer.LearningCoef = 0.3;
            trainer.TrainCoef = 0.5;
            trainer.Start ();
        }
    }
}
