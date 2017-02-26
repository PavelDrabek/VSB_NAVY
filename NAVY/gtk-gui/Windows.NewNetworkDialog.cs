
// This file has been generated by the GUI designer. Do not modify.
namespace Windows
{
	public partial class NewNetworkDialog
	{
		private global::Gtk.Table table5;

		private global::Gtk.Entry entryInnerLayers;

		private global::Gtk.Entry entryInputs;

		private global::Gtk.Entry entryNeuronsInInner;

		private global::Gtk.Entry entryOutputs;

		private global::Gtk.Label label12;

		private global::Gtk.Label label13;

		private global::Gtk.Label label14;

		private global::Gtk.Label label15;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Windows.NewNetworkDialog
			this.Name = "Windows.NewNetworkDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("New neuron network");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child Windows.NewNetworkDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.table5 = new global::Gtk.Table (((uint)(4)), ((uint)(2)), false);
			this.table5.Name = "table5";
			this.table5.RowSpacing = ((uint)(6));
			this.table5.ColumnSpacing = ((uint)(6));
			// Container child table5.Gtk.Table+TableChild
			this.entryInnerLayers = new global::Gtk.Entry ();
			this.entryInnerLayers.CanFocus = true;
			this.entryInnerLayers.Name = "entryInnerLayers";
			this.entryInnerLayers.Text = global::Mono.Unix.Catalog.GetString ("0");
			this.entryInnerLayers.IsEditable = true;
			this.entryInnerLayers.InvisibleChar = '●';
			this.table5.Add (this.entryInnerLayers);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table5 [this.entryInnerLayers]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.entryInputs = new global::Gtk.Entry ();
			this.entryInputs.CanFocus = true;
			this.entryInputs.Name = "entryInputs";
			this.entryInputs.Text = global::Mono.Unix.Catalog.GetString ("2");
			this.entryInputs.IsEditable = true;
			this.entryInputs.InvisibleChar = '●';
			this.table5.Add (this.entryInputs);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table5 [this.entryInputs]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.entryNeuronsInInner = new global::Gtk.Entry ();
			this.entryNeuronsInInner.CanFocus = true;
			this.entryNeuronsInInner.Name = "entryNeuronsInInner";
			this.entryNeuronsInInner.Text = global::Mono.Unix.Catalog.GetString ("3");
			this.entryNeuronsInInner.IsEditable = true;
			this.entryNeuronsInInner.InvisibleChar = '●';
			this.table5.Add (this.entryNeuronsInInner);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table5 [this.entryNeuronsInInner]));
			w4.TopAttach = ((uint)(2));
			w4.BottomAttach = ((uint)(3));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.entryOutputs = new global::Gtk.Entry ();
			this.entryOutputs.CanFocus = true;
			this.entryOutputs.Name = "entryOutputs";
			this.entryOutputs.Text = global::Mono.Unix.Catalog.GetString ("1");
			this.entryOutputs.IsEditable = true;
			this.entryOutputs.InvisibleChar = '●';
			this.table5.Add (this.entryOutputs);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table5 [this.entryOutputs]));
			w5.TopAttach = ((uint)(3));
			w5.BottomAttach = ((uint)(4));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("input count");
			this.table5.Add (this.label12);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table5 [this.label12]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.label13 = new global::Gtk.Label ();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString ("inner layers");
			this.table5.Add (this.label13);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table5 [this.label13]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString ("neurons in layer");
			this.table5.Add (this.label14);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table5 [this.label14]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table5.Gtk.Table+TableChild
			this.label15 = new global::Gtk.Label ();
			this.label15.Name = "label15";
			this.label15.LabelProp = global::Mono.Unix.Catalog.GetString ("output count");
			this.table5.Add (this.label15);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table5 [this.label15]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			w1.Add (this.table5);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(w1 [this.table5]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Internal child Windows.NewNetworkDialog.ActionArea
			global::Gtk.HButtonBox w11 = this.ActionArea;
			w11.Name = "dialog1_ActionArea";
			w11.Spacing = 10;
			w11.BorderWidth = ((uint)(5));
			w11.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.buttonCancel]));
			w12.Expand = false;
			w12.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.buttonOk]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 257;
			this.DefaultHeight = 185;
			this.Show ();
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
