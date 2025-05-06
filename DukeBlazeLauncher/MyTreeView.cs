//using DragDukeLauncher.Extensions;
//using System;
using System.Windows.Forms;

namespace DukeBlazeLauncher
{
	public partial class MyTreeView : TreeView
	{
		public event TreeViewEventHandler SelectedNodeChanged;
		public MyTreeView()
		{
			this.AfterSelect += new TreeViewEventHandler(SelectNodeChangedEvent);
			this.MouseUp += new MouseEventHandler(MouseUpEvent);
		}
		void SelectNodeChangedEvent(object sender, TreeViewEventArgs e)
		{
			SelectedNodeChangedTrigger(sender, e);
		}
		void MouseUpEvent(object sender, MouseEventArgs e)
		{
			if (this.SelectedNode is null)
				SelectedNodeChangedTrigger(sender, new TreeViewEventArgs(null));
		}
		void SelectedNodeChangedTrigger(object sender, TreeViewEventArgs e)
		{
            SelectedNodeChanged?.Invoke(sender, e);
        }
/*
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
*/
    }
}