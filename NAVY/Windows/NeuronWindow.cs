using System;
using ANN;

namespace NAVY
{
    public partial class NeuronWindow : Gtk.Window
    {
        Neuron neuron;

        public NeuronWindow (Neuron neuron) : base (Gtk.WindowType.Toplevel)
        {
            this.Build ();

            entryID.IsEditable = false;
            entryValue.IsEditable = false;

            this.neuron = neuron;
            ShowNeuronProperties ();
        }

        private void ShowNeuronProperties ()
        {
            entryID.Text = neuron.ID.ToString ();
            entryValue.Text = neuron.IsEvaluated ? neuron.Value.ToString () : "-";
            comboboxFunction.Active = 0;
        }
    }
}
