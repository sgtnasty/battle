// 
//  AdeptusWindow.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sourceforge.net>
//  
//  Copyright (c) 2010 Ronaldo Nascimento
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
using System.Reflection;
using Gtk;
using Adeptus.Core;

namespace Adeptus.Gui
{
	public class AdeptusWindow : Gtk.Window
	{
		public AdeptusWindow (AdeptusSession session) : base ("Adeptus")
		{
			this.session = session;
			this.DeleteEvent += HandleDeleteEvent;
			this.build ();
			this.ActiveCharacter(false);
		}
		
		private AdeptusSession session;
		private Gtk.Toolbar toolbar1;
		private Gtk.ToolButton newcharbutton;
		private Gtk.ToolButton savecharbutton;
		private Gtk.ToolButton printcharbutton;
		private Gtk.ToolButton rollbutton;
		private Gtk.ToolButton aboutbutton;
		private Gtk.VBox vbox1;
		private Gtk.Statusbar statusbar1;
		private Gtk.Frame frame1;
		
		private void build ()
		{
			this.SetDefaultSize (1000, 600);
			
			this.vbox1 = new VBox ();
			
			this.toolbar1 = new Toolbar ();
			this.toolbar1.ToolbarStyle = ToolbarStyle.BothHoriz;
			this.newcharbutton = new ToolButton (Stock.New);
			this.newcharbutton.Label = "New";
			this.newcharbutton.TooltipText = "New Character";
			this.newcharbutton.IsImportant = true;
			this.newcharbutton.Clicked += HandleNewcharbuttonClicked;
			this.toolbar1.Add (this.newcharbutton);
			this.savecharbutton = new ToolButton (Stock.Save);
			this.savecharbutton.Label = "Save";
			this.savecharbutton.TooltipText = "Save Character";
			this.savecharbutton.Clicked += HandleSavecharbuttonClicked;
			this.toolbar1.Add(this.savecharbutton);
			this.printcharbutton = new ToolButton (Stock.Print);
			this.printcharbutton.Label = "Print";
			this.printcharbutton.TooltipText = "Print Character";
			this.printcharbutton.Clicked += HandlePrintcharbuttonClicked;
			this.toolbar1.Add(this.printcharbutton);
			this.toolbar1.Add(new SeparatorToolItem());			                  
			this.rollbutton = new ToolButton (Stock.Refresh);
			this.rollbutton.Label = "Roll";
			this.rollbutton.TooltipText = "Roll Characteristics";
			this.rollbutton.IsImportant = true;
			this.rollbutton.Clicked += HandleRollbuttonClicked;
			this.toolbar1.Add(this.rollbutton);
			this.aboutbutton = new ToolButton (Stock.About);
			this.aboutbutton.Label = "About";
			this.aboutbutton.TooltipText = "About Adeptus";
			this.aboutbutton.Clicked += HandleAboutbuttonClicked;
			SeparatorToolItem  sti = new SeparatorToolItem();
			sti.Draw = false;
			sti.Expand = true;
			this.toolbar1.Add(sti);
			this.toolbar1.Add (this.aboutbutton);
			
			this.frame1 = new Frame ();
			this.frame1.Add(new Image(Gdk.Pixbuf.LoadFromResource("Adeptus.Gui.EmperorVHorus.jpg")));
			
			this.statusbar1 = new Statusbar ();
			this.statusbar1.Push (0, "Ready");
			
			this.vbox1.PackStart (this.toolbar1, false, true, 0);
			this.vbox1.PackStart (this.frame1, true, true, 0);
			this.vbox1.PackEnd (this.statusbar1, false, true, 0);
			
			this.Add (this.vbox1);
		}

		void HandleAboutbuttonClicked (object sender, EventArgs e)
		{
			AboutDialog d = new AboutDialog();
			Assembly asm = Assembly.GetExecutingAssembly ();
			//d.Artists = new string [] {"Ronaldo Nascimento <ronaldo1@users.sourceforge.net>"};
			d.Authors = new string [] {"Ronaldo Nascimento <ronaldo1@users.sourceforge.net>"};
			d.Copyright = (asm.GetCustomAttributes (
				typeof (AssemblyCopyrightAttribute), false) [0]
				as AssemblyCopyrightAttribute).Copyright;
			d.Documenters = new string [] {"Ronaldo Nascimento <ronaldo1@users.sourceforge.net>"};
			d.License = @"This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU Lesser General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU Lesser General Public License for more details.

 You should have received a copy of the GNU Lesser General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.";
			d.ProgramName = (asm.GetCustomAttributes (
				typeof (AssemblyTitleAttribute), false) [0]
				as AssemblyTitleAttribute).Title;
			d.Title = "About Adeptus";
			d.Version = asm.GetName ().Version.ToString ();
			d.Website = "http://battle.sourceforge.net";
			d.WebsiteLabel = "http://battle.sourceforge.net";
			d.Response += delegate(object o, ResponseArgs args) {
				d.Hide();	
			};
			d.Logo = Gdk.Pixbuf.LoadFromResource("Adeptus.Gui.adeptus.jpeg");
			d.Run();
		}

		void HandleRollbuttonClicked (object sender, EventArgs e)
		{
			
		}

		void HandlePrintcharbuttonClicked (object sender, EventArgs e)
		{
			
		}

		void HandleSavecharbuttonClicked (object sender, EventArgs e)
		{
			
		}

		void HandleNewcharbuttonClicked (object sender, EventArgs e)
		{
			NewCharacterWindow d = new NewCharacterWindow(this.session);
			d.Show();
		}

		void HandleDeleteEvent (object o, DeleteEventArgs args)
		{
			Gtk.Application.Quit ();
			args.RetVal = true;
		}
		
		void ActiveCharacter(bool isActive)
		{
			this.newcharbutton.Sensitive = true;
			this.savecharbutton.Sensitive = isActive;
			this.printcharbutton.Sensitive = isActive;
			this.rollbutton.Sensitive = isActive;
		}
	}
}

