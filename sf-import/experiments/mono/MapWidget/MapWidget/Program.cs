// 
//  Program.cs
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
using System.Text;
using Gtk;
using Glade;

namespace MapWidget
{
	public class Program
	{
		public Program ()
		{
		}
		
		#region Widgets
		Glade.XML gladeui;
		[Widget] protected Window window1;
		[Widget] protected Viewport viewport1;
		[Widget] protected Statusbar statusbar1;
		protected MapWidget mapwidget1;
		#endregion
		
		public void Run ()
		{
			Gtk.Application.Init ();
			this.mapwidget1 = new MapWidget ();
			this.gladeui = new Glade.XML ("ui.glade", "window1", null);
			this.gladeui.Autoconnect (this);
			this.viewport1.Add (this.mapwidget1);
			this.window1.ShowAll ();
			Gtk.Application.Run ();
		}
		
		protected void on_window1_delete_event (object o, DeleteEventArgs args)
		{
			Gtk.Application.Quit ();
		}
		
		public static void Main (string[] args)
		{
			Program p = new Program ();
			p.Run ();
		}
	}
}

