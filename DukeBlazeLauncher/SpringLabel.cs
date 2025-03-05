using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DragDukeLauncher
{
[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
	public partial class SpringLabel : ToolStripStatusLabel
	{
    #nullable enable
        private string? _text;
        public new string? Text
		{
            get => _text;
            set { _text = value; ToolTipText = _text; Invalidate(); }
        }
		public SpringLabel()
		{
			Spring = true;
		}

        protected override void OnPaint(PaintEventArgs e)
		{
            base.OnPaint(e);
            var flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
			var bounds = new Rectangle(0, 0, Bounds.Width, Bounds.Height);
			TextRenderer.DrawText(e.Graphics, _text, Font, bounds, ForeColor, flags);
		}
	}
}