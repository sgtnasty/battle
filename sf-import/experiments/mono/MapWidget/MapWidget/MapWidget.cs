// 
//  MapWidget.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sourceforge.net>
//  
//  Copyright (c) 2011 Ronaldo Nascimento
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gtk;
using Cairo;

namespace MapWidget
{
	public class MapWidget : DrawingArea
	{
		public MapWidget () 
			: base ()
		{
			this.ModifyBg (StateType.Normal, this.bg);
			this.WidthRequest = MapWidget.xsize;
			this.HeightRequest = MapWidget.ysize;
			this.SizeRequested += HandleSizeRequested;
			this.Events = this.Events | Gdk.EventMask.PointerMotionMask | Gdk.EventMask.EnterNotifyMask |
				Gdk.EventMask.LeaveNotifyMask;
			this.MotionNotifyEvent += HandleMotionNotifyEvent;
			this.EnterNotifyEvent += HandleEnterNotifyEvent;
			this.LeaveNotifyEvent += HandleLeaveNotifyEvent;
			this.mouse_loc = new Cairo.PointD (0.0, 0.0);
			this.drawmouse = false;
		}

		void HandleLeaveNotifyEvent (object o, LeaveNotifyEventArgs args)
		{
			this.drawmouse = false;
			this.QueueDraw ();
		}

		void HandleEnterNotifyEvent (object o, EnterNotifyEventArgs args)
		{
			this.drawmouse = true;
			this.QueueDraw ();
		}

		void HandleMotionNotifyEvent (object o, MotionNotifyEventArgs args)
		{
			this.mouse_loc.X = args.Event.X;
			this.mouse_loc.Y = args.Event.Y;
			this.QueueDraw ();
		}

		void HandleSizeRequested (object o, SizeRequestedArgs args)
		{
			Requisition req = new Requisition ();
			req.Width = MapWidget.xsize;
			req.Height = MapWidget.ysize;
			args.Requisition = req;
		}
		
		#region Color Definitions
		protected Gdk.Color black = new Gdk.Color (0, 0, 0);
		protected Gdk.Color white = new Gdk.Color (255, 255, 255);
		protected Gdk.Color red = new Gdk.Color (255, 0, 0);
		protected Gdk.Color green = new Gdk.Color (0, 255, 0);
		protected Gdk.Color blue = new Gdk.Color (0, 0, 255);
		protected Gdk.Color yellow = new Gdk.Color (255, 255, 0);
		protected Gdk.Color pink = new Gdk.Color (255, 0, 255);
		protected Gdk.Color cyan = new Gdk.Color (0, 255, 255);
		
		protected Gdk.Color darkred = new Gdk.Color (115, 60, 60);
		protected Gdk.Color darkgreen = new Gdk.Color (60, 115, 60);
		protected Gdk.Color darkblue = new Gdk.Color (60, 60, 115);
		protected Gdk.Color brown = new Gdk.Color (143, 89, 2);
		protected Gdk.Color bg = new Gdk.Color (224, 195, 158);
		
		// grays
		protected Gdk.Color verylightgray = new Gdk.Color (240, 240, 240);
		protected Gdk.Color lightgray = new Gdk.Color (204, 204, 204);
		protected Gdk.Color gray = new Gdk.Color (128, 128, 128);
		protected Gdk.Color darkgray = new Gdk.Color (102, 102, 102);
		
		protected static Cairo.Color convert_color (Gdk.Color color)
		{
			return new Cairo.Color (color.Red, color.Green, color.Blue);
		}
		
		#endregion
		
		#region Basic Drawing Test
		protected double min (params double[] arr)
		{
			int minp = 0;
			for (int i = 1; i < arr.Length; i++)
				if (arr[i] < arr[minp])
					minp = i;
			
			return arr[minp];
		}
		
		protected void DrawRoundedRectangle (Cairo.Context gr, double x, double y, double width, double height, double radius)
		{
			gr.Save ();
			
			if ((radius > height / 2) || (radius > width / 2))
			radius = min (height / 2, width / 2);
			
			gr.MoveTo (x, y + radius);
			gr.Arc (x + radius, y + radius, radius, Math.PI, -Math.PI / 2);
			gr.LineTo (x + width - radius, y);
			gr.Arc (x + width - radius, y + radius, radius, -Math.PI / 2, 0);
			gr.LineTo (x + width, y + height - radius);
			gr.Arc (x + width - radius, y + height - radius, radius, 0, Math.PI / 2);
			gr.LineTo (x + radius, y + height);
			gr.Arc (x + radius, y + height - radius, radius, Math.PI / 2, Math.PI);
			gr.ClosePath ();
			gr.Restore ();
		}
		
		protected void DrawCurvedRectangle (Cairo.Context gr, double x, double y, double width, double height)
		{
			gr.Save ();
			gr.MoveTo (x, y + height / 2);
			gr.CurveTo (x, y, x, y, x + width / 2, y);
			gr.CurveTo (x + width, y, x + width, y, x + width, y + height / 2);
			gr.CurveTo (x + width, y + height, x + width, y + height, x + width / 2, y + height);
			gr.CurveTo (x, y + height, x, y + height, x, y + height / 2);
			gr.Restore ();
		}
		
		protected void BasicDrawTest (Context g)
		{
			DrawCurvedRectangle (g, 30, 30, 300, 200);
			DrawRoundedRectangle (g, 70, 250, 300, 200, 40);
			g.Color = new Cairo.Color (this.darkred.Red, this.darkred.Green, this.darkred.Blue);
			g.FillPreserve ();
			g.Color = new Cairo.Color (this.black.Red, this.black.Green, this.black.Blue);
			g.LineWidth = 5;
			g.Stroke ();
		}
		#endregion
		
		protected Cairo.PointD mouse_loc;
		protected bool drawmouse;
		
		protected void DrawMouse (Cairo.Context g, Cairo.Distance dimensions)
		{
			if (this.drawmouse)
			{
				g.Save ();
				
				g.MoveTo ((double)this.mouse_loc.X, 0);
				g.LineTo ((double)this.mouse_loc.X, dimensions.Dy);
	
				g.MoveTo (0, (double)this.mouse_loc.Y);
				g.LineTo (dimensions.Dx, (double)this.mouse_loc.Y);
	
				g.Restore ();
				
				g.Color = MapWidget.convert_color (this.red);
				g.LineWidth = 1;
				g.Stroke ();
			}
		}
		
		const int size = 1000;
		const int xsize = MapWidget.size;
		const int ysize = MapWidget.size;
		const int gridlines = 100;
		const int xgridlines = MapWidget.gridlines;
		const int ygridlines = MapWidget.gridlines;
		
		protected void DrawMapGrid (Cairo.Context g, Cairo.Distance dimensions)
		{
			g.Save ();
						
			double xspan = dimensions.Dx / MapWidget.xgridlines;
			double yspan = dimensions.Dy / MapWidget.ygridlines;
			xspan = yspan = 10.0;
			
			//Console.WriteLine ("dimensions={0}:{1}  span={2}:{3}", dimensions.Dx, dimensions.Dy, xspan, yspan);
			/*
			 * dimensions=1000:1000  span=1000:10
			 * dimensions=1000:1000  span=1000:10
			 * dimensions=1428:1000  span=1000:14.28
			 */
			
			Cairo.PointD location = new Cairo.PointD (0.0, 0.0);
			
			// move along x axis
			for (int i=0; i<MapWidget.xgridlines; i++)
			{
				location.X += xspan;
				Cairo.PointD p = new Cairo.PointD (location.X, 0);
				g.MoveTo (p);
				g.LineTo (location.X, ysize);
			}
			// move along y axis
			for (int i=0; i<MapWidget.ygridlines; i++)
			{
				location.Y += yspan;
				Cairo.PointD p = new Cairo.PointD (0, location.Y);
				g.MoveTo (p);
				g.LineTo (xsize, location.Y);
			}
			
			g.Restore ();
			//g.Color = new Cairo.Color (86.0, 86.0, 86.0);
			g.Color = MapWidget.convert_color (this.gray);
			g.LineWidth = 1;
			g.Stroke ();
		}
		
		protected void DrawUnits (Cairo.Context g, Cairo.Distance dimensions)
		{
			g.Save ();
			
			g.MoveTo (105, 105);
			g.LineTo (105, 205);
			g.LineTo (205, 205);
			g.LineTo (205, 105);
			g.LineTo (105, 105);
			
			g.Restore ();
			
			g.Color = MapWidget.convert_color (this.blue);
			g.FillPreserve ();
			g.Color = MapWidget.convert_color (this.black);
			g.LineWidth = 1;
			g.Stroke ();
		}
				
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			Context g = Gdk.CairoHelper.Create (evnt.Window);
			g.Antialias = Antialias.None;
			int winh;
			int winw;
			evnt.Window.GetSize(out winw, out winh);
			Cairo.Distance d = new Cairo.Distance (winw, winh);
			//this.BasicDrawTest (g);
			this.DrawUnits (g, d);
			this.DrawMapGrid (g, d);
			this.DrawMouse (g, d);
			((IDisposable)g).Dispose ();
			return true;
		}
	}
}

