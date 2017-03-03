using System;
using ANN;
using ANN.Functions;

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

            comboboxFunction.AppendText (typeof (BinaryFunction).ToString ());
            comboboxFunction.AppendText (typeof (PerceptronFunction).ToString ());
            comboboxFunction.AppendText (typeof (HyperbolicFunction).ToString ());
            comboboxFunction.AppendText (typeof (LogisticFunction).ToString ());
        }

        private void ShowNeuronProperties ()
        {
            entryID.Text = neuron.ID.ToString ();
            entryValue.Text = neuron.IsEvaluated ? neuron.Value.ToString () : "-";
            comboboxFunction.Active = 0;
        }

        protected void OnComboboxFunctionChanged (object sender, EventArgs e)
        {
            if (comboboxFunction.ActiveText.Equals (typeof (BinaryFunction).ToString ())) {
                neuron.Function = new BinaryFunction (1);
            } else if (comboboxFunction.ActiveText.Equals (typeof (PerceptronFunction).ToString ())) {
                neuron.Function = new PerceptronFunction ();
            } else if (comboboxFunction.ActiveText.Equals (typeof (HyperbolicFunction).ToString ())) {
                neuron.Function = new HyperbolicFunction (1);
            } else if (comboboxFunction.ActiveText.Equals (typeof (LogisticFunction).ToString ())) {
                neuron.Function = new LogisticFunction (1);
            } 
        }
    }
}
