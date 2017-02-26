using System;
namespace NAVY
{
    public class TrainingDataNode : Gtk.TreeNode
    {
        public TrainingDataNode (string input, string output)
        {
            Input = input;
            Output = output;
        }

        [Gtk.TreeNodeValue(Column=0)]
        public string Input { get; set; }
        [Gtk.TreeNodeValue (Column=1)]
        public string Output { get; set; }
    }
}
