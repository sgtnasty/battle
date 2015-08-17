// 
//  MapControl.cs
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
using Gdk;
using Cairo;

namespace Battle.Gui.Controls
{
	public class MapControl : Gtk.DrawingArea
	{
		public MapControl ()
		{
			this.ModifyBg (Gtk.StateType.Normal, new Gdk.Color (255, 255, 255));
		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose args)
		{
			Window w = args.Window;
			int width;
			int height;
			w.GetSize(out width, out height);
			double dw = (double) width;
			double dh = (double) height;
			Context g = Gdk.CairoHelper.Create (w);
			
			// calculate points
			double posx = 0.5 * dw;
			double posy = 0.5 * dh;			
			
			// do yer drawing 'ere
			g.Save ();
			g.MoveTo (posx, posy);
			g.Rectangle (posx, posy, 4, 4);
			g.Restore ();
			g.LineWidth = 1;
			g.Fill ();
			
			((IDisposable)g).Dispose ();
			return true;
		}
	}
}

