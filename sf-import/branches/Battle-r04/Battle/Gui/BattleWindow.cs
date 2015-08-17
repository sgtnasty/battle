// 
//  BattleWindow.cs
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
using Gtk;
using BattleLibrary;
using Battle;
using Battle.Gui.Controls;

namespace Battle.Gui
{
	public class BattleWindow : Gtk.Window
	{
		public BattleWindow (BattleSession session) : base (WindowType.Toplevel)
		{
			this.session = session;
			this.build ();
			this.sbar.Push (0, "Ready");
		}
		
		#region GUI
		protected VBox vbox;
		protected Toolbar tbar;
		protected ToolButton about;
		protected Frame frame;
		protected HPaned hpaned;
		protected MapControl map;
		protected Statusbar sbar;
		#endregion
		
		protected BattleSession session;
		
		protected void build ()
		{
			this.SetDefaultSize (1000, 600);
			this.Title = "Battle";
			this.DeleteEvent += HandleDeleteEvent;
			
			this.vbox = new VBox ();
			
			this.tbar = new Toolbar ();
			this.tbar.ToolbarStyle = ToolbarStyle.BothHoriz;
			this.about = new ToolButton (Stock.About);
			this.about.IsImportant = false;
			this.about.Label = "About";
			this.about.TooltipText = "About this application";
			this.tbar.Add (this.about);
			
			this.hpaned = new HPaned ();
			this.frame = new Frame ("Battle Map");
			this.map = new MapControl ();
			this.frame.Add (this.map);
			Label a = new Label ("Welcome");
			this.hpaned.Pack1 (a, false, false);
			this.hpaned.Pack2 (this.frame, true, true);
			
			this.sbar = new Statusbar ();
			
			this.vbox.PackStart (this.tbar, false, true, 0);
			this.vbox.PackStart (this.hpaned, true, true, 0);
			this.vbox.PackEnd (this.sbar, false, true, 0);
			
			
			this.Add (this.vbox);
		}

		void HandleDeleteEvent (object o, DeleteEventArgs args)
		{
			Gtk.Application.Quit ();
		}
	}
}

