//  
//  MainWindow.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@sourceforge.net>
// 
//  Copyright (c) 2010 Ronaldo Nascimento
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Reflection;
using Gtk;
using Battle.Core;

namespace Battle.Gui
{
	public class MainWindow : Gtk.Window
	{
		private Battle.Core.BattlelordsSession session;
		public MainWindow (Battle.Core.BattlelordsSession session) : base("Battle")
		{
			this.session = session;
			this.build();
			this.DeleteEvent += HandleHandleDeleteEvent;
		}
		
		private Gtk.VBox vbox1;
		private Gtk.Image image1;
		private Gtk.Toolbar toolbar1;
		private Gtk.ToolButton quit_toolbutton;
		private Gtk.ToolButton new_toolbutton;
		private Gtk.ToolButton pref_toolbutton;
		private Gtk.ToolButton about_toolbutton;
		private Gtk.Statusbar statusbar1;
		private void build()
		{
			this.vbox1 = new Gtk.VBox();
			this.toolbar1 = new Gtk.Toolbar();
			this.toolbar1.ToolbarStyle = ToolbarStyle.BothHoriz;
			this.new_toolbutton = new ToolButton(Stock.New);
			this.new_toolbutton.IsImportant = true;
			this.new_toolbutton.Label = "New Character";
			this.new_toolbutton.Clicked += HandleNew_toolbuttonhandleClicked;
			this.toolbar1.Add(this.new_toolbutton);
			this.pref_toolbutton = new ToolButton(Stock.Preferences);
			this.pref_toolbutton.IsImportant = true;
			this.pref_toolbutton.Label = "Preferences";
			this.pref_toolbutton.Clicked += HandlePref_toolbuttonhandleClicked;
			this.toolbar1.Add(this.pref_toolbutton);
			this.quit_toolbutton = new ToolButton(Stock.Quit);
			this.quit_toolbutton.IsImportant = true;
			this.quit_toolbutton.Label = "Quit";
			this.quit_toolbutton.Clicked += HandleQuit_toolbuttonhandleClicked;
			this.toolbar1.Add(this.quit_toolbutton);
			this.about_toolbutton = new ToolButton(Stock.About);
			this.about_toolbutton.IsImportant = true;
			this.about_toolbutton.Label = "About";
			this.about_toolbutton.Clicked += HandleAbout_toolbuttonhandleClicked;
			SeparatorToolItem sti = new SeparatorToolItem();
			sti.Draw = false;
			sti.Expand = true;
			this.toolbar1.Add(sti);
			this.toolbar1.Add(this.about_toolbutton);
			this.statusbar1 = new Gtk.Statusbar();
			this.image1 = new Image(MediaManager.GetPixbufFromBaseFile("BLLogo.jpg").ScaleSimple(296, 149, Gdk.InterpType.Bilinear));
			Gtk.VBox vbox2 = new Gtk.VBox();
			
			Gtk.ScrolledWindow sw1 = new Gtk.ScrolledWindow();
			TreeStore ts1 = new TreeStore (typeof (string), typeof (string));
			ts1.AppendValues("Player Characters",DateTime.Now.ToString());
			ts1.AppendValues("Non-Player Characters",DateTime.Now.ToString());
			ts1.AppendValues("Database",DateTime.Now.ToString());
			TreeView tv1 = new TreeView ();
			tv1.Model = ts1;
			tv1.HeadersVisible = true;
			tv1.AppendColumn ("Source", new CellRendererText (), "text", 0);
			tv1.AppendColumn ("Last Update", new CellRendererText (), "text", 1);
			sw1.Add(tv1);
			
			
			
			vbox2.PackStart(this.image1, false, true, 0);
			vbox2.PackEnd(sw1, true, true, 0);
			this.vbox1.PackStart(this.toolbar1, false, true, 0);
			this.vbox1.PackStart(vbox2, true, true, 0);
			this.vbox1.PackStart(this.statusbar1, false, true, 0);
			this.Add(this.vbox1);
			//this.SetSizeRequest(640, Screen.Height - 100);
			this.SetSizeRequest(480, 640);
			this.Icon = Battle.Gui.MediaManager.GetPixbufFromBaseFile("LSIMMS.png");
			this.statusbar1.Push(0, string.Format("{0} started @ {1}",
			                                      this.session.GetType().ToString(),
			                                      this.session.StartTime.ToString()));
			this.Maximize();
		}

		void HandlePref_toolbuttonhandleClicked (object sender, EventArgs e)
		{
			PreferencesDialog d = new PreferencesDialog(this.session);
			//d.ShowAll();
			Gtk.ResponseType resp = (Gtk.ResponseType) d.Run();
			d.Destroy();
		}

		void HandleAbout_toolbuttonhandleClicked (object sender, EventArgs e)
		{
			Gtk.AboutDialog ad = new Gtk.AboutDialog();
			ad.SetPosition(Gtk.WindowPosition.CenterOnParent);
			Assembly asm = Assembly.GetExecutingAssembly();
			ad.ProgramName = (asm.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute).Title;
			ad.Version = asm.GetName().Version.ToString();
			ad.Comments = (asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description;
			ad.Copyright = (asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute).Copyright;
			ad.Authors = new string[] {"Ronaldo Nascimento <ronaldo1@users.sourceforge.net"};
			ad.License = "GPL 3";
			ad.Logo = Battle.Gui.MediaManager.GetPixbufFromBaseFile("BLLogo-small.jpg");
			ad.Website = "http://battle.sourceforge.net";
			
			ad.Run();
			ad.Destroy();
		}

		void HandleNew_toolbuttonhandleClicked (object sender, EventArgs e)
		{
			NewCharacterWindow w = new NewCharacterWindow(this.session);
			w.Show();
		}

		void HandleQuit_toolbuttonhandleClicked (object sender, EventArgs e)
		{
			this.HandleHandleDeleteEvent(sender, new DeleteEventArgs());
		}

		void HandleHandleDeleteEvent (object o, DeleteEventArgs args)
		{
			MessageDialog m = new MessageDialog(this, DialogFlags.Modal, MessageType.Question,
			                                    ButtonsType.YesNo, "Do you want to quit?");
			m.Title = "Battle";
			ResponseType result = (ResponseType)m.Run();
			
			if (result == ResponseType.Yes)
			{
				Application.Quit ();
				args.RetVal = true;
			}
			else 
			{
				args.RetVal =false;
				m.Destroy();
			}
		}
	}
}

