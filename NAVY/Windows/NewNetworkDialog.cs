using System;
using ANN;

namespace Windows
{
    public partial class NewNetworkDialog : Gtk.Dialog
    {
        private NeuronNetwork network;

        public NewNetworkDialog (NeuronNetwork network)
        {
            this.Build ();
            this.network = network;
        }

        protected void OnButtonOkClicked (object sender, EventArgs e)
        {
            int inputs = int.Parse (entryInputs.Text);
            int innerLayers = int.Parse (entryInnerLayers.Text);
            int neuronsInInner = int.Parse (entryNeuronsInInner.Text);
            int outputs = int.Parse (entryOutputs.Text);

            network.Generate (inputs, innerLayers, neuronsInInner, outputs);
            Destroy ();
        }

        protected void OnButtonCancelClicked (object sender, EventArgs e)
        {
            Destroy ();
        }
    }
}
