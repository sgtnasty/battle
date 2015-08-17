// 
//  GladeWindow.cs
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
using System.Configuration;
using System.Reflection;
using Gtk;
using System.Text;
using Glade;
using WebShell.Commands;

namespace WebShell
{
	public class GladeWindow
	{
		public GladeWindow (Session session)
		{
			this.session = session;
			this.command_store = new TreeStore (typeof (string));
			this.connect ();
			this.window1.SetDefaultSize (800, 600);
			this.window1.ShowAll ();
		}
		
		#region Members
		protected Session session;
		protected List<string> commandhistory;
		protected int commandhistorypointer;
		#endregion
		
		protected XML window_gui;
		[Widget] protected Window window1;
		[Widget] protected ToolButton about_toolbutton;
		[Widget] protected ToolButton test_toolbutton;
		[Widget] protected Expander context_expander;
		[Widget] protected Label context_label;
		[Widget] protected TextView console_textview;
		[Widget] protected ComboBox command_combobox;
		protected TreeStore command_store;
		[Widget] protected Entry command_entry;
		[Widget] protected Button execute_button;
		[Widget] protected ProgressBar progressbar1;
		[Widget] protected Label status_label;
		
		protected XML error_dialog_gui;
		[Widget] Dialog error_dialog;
		[Widget] Label exception_label;
		[Widget] Label message_label;
		[Widget] TextView stacktrace_textview;
		[Widget] TreeView exception_treeview;

		protected void on_window1_delete_event (object o, DeleteEventArgs args)
		{
			MessageDialog d = new MessageDialog (this.window1, DialogFlags.DestroyWithParent,
			                                     MessageType.Question, ButtonsType.OkCancel,
			                                     true, "Are you sure you want to <b>quit</b>?");
			ResponseType result = (ResponseType) d.Run ();
			d.Hide ();
			d.Dispose ();
			args.RetVal = (result == ResponseType.Cancel);
			if (result == ResponseType.Ok)
			{
				Gtk.Application.Quit ();
			}
		}
		protected void on_about_toolbutton_clicked (object sender, EventArgs e)
		{
			Assembly assembly = Assembly.GetExecutingAssembly ();
			string[] me = new string[] {"Ronaldo Nascimento <ronaldo1@users.sourceforge.net>"};
			AboutDialog d = new AboutDialog ();
			d.SkipTaskbarHint = true;
			d.Artists = me;
			d.Authors = me;
			object[] comments = assembly.GetCustomAttributes (typeof (AssemblyDescriptionAttribute), false);
			d.Comments = ((AssemblyDescriptionAttribute)comments[0]).Description;
			object[] copyright = assembly.GetCustomAttributes (typeof(AssemblyCopyrightAttribute), false);
			d.Copyright = ((AssemblyCopyrightAttribute)copyright[0]).Copyright;
			d.Documenters = me;
			d.Icon = Gdk.Pixbuf.LoadFromResource ("WebShell.Media.wsh.png");
			d.Logo = Gdk.Pixbuf.LoadFromResource ("WebShell.Media.wsh.png");
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
			object[] programname = assembly.GetCustomAttributes (typeof (AssemblyTitleAttribute), false);
			d.ProgramName = ((AssemblyTitleAttribute)programname[0]).Title;
			d.Title = d.ProgramName;
			//d.TranslatorCredits = me[0];
			d.Version = string.Format ("{0}.{1}.{2}.{3}", assembly.GetName ().Version.Major, assembly.GetName ().Version.Minor,
			                           assembly.GetName ().Version.Revision, assembly.GetName ().Version.Build);
			d.Website = "http://battle.sourceforge.net";
			d.WebsiteLabel = d.Website;
			d.Run ();
			d.Hide ();
			d.Destroy ();
		}
		protected void on_test_toolbutton_clicked (object sender, EventArgs e)
		{
			try
			{
				throw new Exception ("I told you not to click on that!");
			}
			catch (Exception ex)
			{
				this.HandleException (ex);
			}
		}
		protected void on_command_combobox_changed (object sender, EventArgs e)
		{
		}
		protected void on_command_entry_key_release_event (object sender, KeyReleaseEventArgs e)
		{
			if (e.Event.Key == Gdk.Key.Return)
			{
				this.execute_button.Click ();
			}
		}
		protected void on_execute_button_clicked (object sender, EventArgs e)
		{
			Results r = this.session.ProcessCommand (this.command_entry.Text);
			this.ConsoleWriteLine (r.Message);
		}
		
		protected void connect ()
		{
			//this.window_gui = new XML ("wsh.ui", "window1", "interface");
			this.window_gui = new XML ("wsh.glade", "window1", null);
			this.window_gui.Autoconnect (this);
			//this.error_dialog_gui = new XML ("wsh.ui", "error_dialog", "interface");
			this.error_dialog_gui = new XML ("wsh.glade", "error_dialog", null);
			this.error_dialog_gui.Autoconnect (this);
			//this.command_combobox.SetCellDataFunc (new CellRendererText (), new CellLayoutDataFunc(
			this.command_combobox.Model = this.command_store;
		}
		
		protected void ConsoleWrite (string message)
		{
			this.console_textview.Buffer.InsertAtCursor (message);
			// TODO: scroll to bottom of window here
		}
		
		protected void ConsoleWriteLine (string message)
		{
			this.ConsoleWrite (message + System.Environment.NewLine);
		}
		
		protected void on_expander1_activate (object sender, EventArgs e)
		{
			//this.error_dialog.SetDefaultSize (400, 400);
			this.error_dialog.WidthRequest = 700;
			this.error_dialog.HeightRequest = 400;
			this.error_dialog.QueueResize ();
		}
		
		protected void HandleException (Exception ex)
		{
			this.exception_label.Text = ex.GetType ().ToString ();
			this.message_label.Text = ex.Message;
			this.stacktrace_textview.Buffer.Text = ex.StackTrace;
			this.exception_treeview.AppendColumn ("Name", new CellRendererText (), "text", 0);
			this.exception_treeview.AppendColumn ("Type", new CellRendererText (), "text", 1);
			this.exception_treeview.AppendColumn ("Value", new CellRendererText (), "text", 2);
			TreeStore store = new TreeStore (typeof (string), typeof (string), typeof (string));
			store.AppendValues (new string[] {"Class", ex.GetType().ToString(), ex.GetType().ToString()});
			store.AppendValues (new string[] {"Message", ex.Message.GetType().ToString (), ex.Message});
			store.AppendValues (new string[] {"Source", ex.Source.GetType().ToString(), ex.Source});
			store.AppendValues (new string[] {"StackTrace", ex.StackTrace.GetType().ToString(), ex.StackTrace});
			store.AppendValues (new string[] {"HashCode", ex.GetHashCode().GetType().ToString(), ex.GetHashCode().ToString()});
			foreach (TreeViewColumn tvc in this.exception_treeview.Columns)
			{
				tvc.Resizable = true;
			}
			//this.exception_treeview.Columns[1].Expand = false;
			this.exception_treeview.Model = store;
			this.exception_treeview.HeadersVisible = true;
			this.error_dialog.ShowAll ();
			this.error_dialog.Run ();
			this.error_dialog.Hide ();
		}
		
		protected void on_window1_show (object sender, EventArgs e)
		{
			this.command_store.Clear ();
			this.ConsoleWriteLine ("Registered commands:");
			foreach (ICommand cmd in this.session.commands)
			{
				this.ConsoleWriteLine (cmd.ToString ());
				this.command_store.AppendValues (new string[] {cmd.Register ()});
			}
		}
	}
}

