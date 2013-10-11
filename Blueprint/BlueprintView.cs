using System;
using MonoMac.CoreGraphics;
using System.Drawing;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Xamarin.Rocks
{
	[Register("BlueprintView")]
	public class BlueprintView : NSView
	{
		public BlueprintView ()
		{
			this.AcceptsTouchEvents = true;
		}

		public BlueprintView (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		private void Initialize ()
		{
		}

		public override void DrawRect(RectangleF dirtyRect)
		{
			var context = NSGraphicsContext.CurrentContext.GraphicsPort;
			context.SetFillColor(new CGColor(1,1,1)); //White
			context.FillRect (dirtyRect);

			for (int i = 1; i < this.Bounds.Size.Height / 10; i++) {
				if (i % 10 == 0) {
					NSColor colorWithSRGBRed = NSColor.FromSrgb (100 / 255.0f, 149 / 255.0f, 237 / 255.0f, 0.3f);
					colorWithSRGBRed.Set ();
				} else if (i % 10 == 0) {
					NSColor colorWithSRGBRed = NSColor.FromSrgb (100 / 255.0f, 149 / 255.0f, 237 / 255.0f, 0.2f);
					colorWithSRGBRed.Set ();
				} else {
					NSColor colorWithSRGBRed = NSColor.FromSrgb (100 / 255.0f, 149 / 255.0f, 237 / 255.0f, 0.1f);
					colorWithSRGBRed.Set ();
				}
				var pointFrom = new PointF (0, (i * GridSize - 0.5f));
				var pointTo = new PointF (this.Bounds.Size.Width, (i * GridSize - 0.5f));

				NSBezierPath.StrokeLine (pointFrom, pointTo);
			}


			for (int i = 1; i < this.Bounds.Size.Width / 10; i++) {
				if (i % 10 == 0) {
					NSColor colorWithSRGBRed = NSColor.FromSrgb (100 / 255.0f, 149 / 255.0f, 237 / 255.0f, 0.3f);
					colorWithSRGBRed.Set ();
				} else if (i % 10 == 0) {
					NSColor colorWithSRGBRed = NSColor.FromSrgb (100 / 255.0f, 149 / 255.0f, 237 / 255.0f, 0.2f);
					colorWithSRGBRed.Set ();
				} else {
					NSColor colorWithSRGBRed = NSColor.FromSrgb (100 / 255.0f, 149 / 255.0f, 237 / 255.0f, 0.1f);
					colorWithSRGBRed.Set ();
				}
				var pointFrom = new PointF ((i * GridSize - 0.5f),0);
				var pointTo = new PointF ((i * GridSize - 0.5f),this.Bounds.Size.Height);

				NSBezierPath.StrokeLine (pointFrom, pointTo);
			}

		}

		public float GridSize
		{
			get {
				return _gridSize;
			}
			set {
				if((value >= MIN_GRID_SIZE) && (value <= MAX_GRID_SIZE))
				{
					_gridSize = value;
					NeedsDisplay = true;
				}
			}
		}

		//Fields
		private float _gridSize = 15;
		private const float MAX_GRID_SIZE = 30;
		private const float MIN_GRID_SIZE = 10;

	}
}

