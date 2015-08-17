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
using Gtk;

namespace BattleNames
{
	public class Program
	{
		public Program ()
		{
			this.treestore = new TreeStore (typeof (string));
			this.treestore.AppendValues ("Battle Name");
		}
		
		protected Gtk.Window window;
		protected Gtk.VBox vbox;
		protected Gtk.Toolbar tbar;
		protected Gtk.ToolButton generatebutton;
		protected Gtk.ToolButton clearbutton;
		protected Gtk.HPaned hpaned;
		protected Gtk.ScrolledWindow treescrolledwindow;
		protected Gtk.TreeStore treestore;
		protected Gtk.TreeView treeview;
		protected Gtk.ScrolledWindow textscrolledwindow;
		protected Gtk.TextView textview;
		protected Gtk.Statusbar sbar;
		
		public void Build ()
		{
			this.window = new Window ("BattleNames");
			this.window.SetDefaultSize (800, 600);
			this.window.DeleteEvent += HandleWindowDeleteEvent;
			
			this.vbox = new VBox ();
			{
				this.tbar = new Toolbar ();
				this.tbar.ToolbarStyle = ToolbarStyle.BothHoriz;
				{
					this.generatebutton = new ToolButton (Stock.New);
					this.generatebutton.TooltipText = "Generate a new battle name";
					this.generatebutton.Label = "Generate";
					this.generatebutton.IsImportant = true;
					this.generatebutton.Clicked += HandleGeneratebuttonClicked;
					this.clearbutton = new ToolButton (Stock.Clear);
					this.clearbutton.TooltipText = "Clear output";
					this.clearbutton.Label = "Clear";
					this.clearbutton.Clicked += HandleClearbuttonClicked;
				}
				this.tbar.Add (this.generatebutton);
				this.tbar.Add (this.clearbutton);
				
				this.hpaned = new HPaned ();
				{
					this.treescrolledwindow = new ScrolledWindow ();
					this.treeview = new TreeView ();
					this.treeview.AppendColumn ("Name", new CellRendererText (), "text", 0);
					this.treeview.HeadersVisible = true;
					this.treeview.Model = this.treestore;
					this.treescrolledwindow.Add (this.treeview);
					
					this.textscrolledwindow = new ScrolledWindow ();
					this.textview = new TextView ();
					this.textview.Editable = false;
					this.textscrolledwindow.Add (this.textview);
				}
				this.hpaned.Pack1 (this.treescrolledwindow, false, true);
				this.hpaned.Pack2 (this.textscrolledwindow, true, true);
				this.hpaned.Position = 200;
				
				this.sbar = new Statusbar ();
			}
			this.vbox.PackStart (this.tbar, false, true, 0);
			this.vbox.PackStart (this.hpaned, true, true, 0);
			this.vbox.PackEnd (this.sbar, false, true, 0);
			
			this.window.Add (this.vbox);
		}

		void HandleClearbuttonClicked (object sender, EventArgs e)
		{
			this.textview.Buffer.Text = "";
		}

		void HandleWindowDeleteEvent (object o, DeleteEventArgs args)
		{
			Gtk.Application.Quit ();
		}

		void HandleGeneratebuttonClicked (object sender, EventArgs e)
		{
			Dialog d = new Dialog ("Generate Seed", this.window, DialogFlags.DestroyWithParent,
			                       Stock.Ok, ResponseType.Ok, Stock.Cancel, ResponseType.Cancel);
			HBox hbox1 = new HBox (false, 0);
			Image icon = new Image ();
			icon.SetFromStock (Stock.DialogQuestion, IconSize.Dialog);
			Label l1 = new Label ();
			l1.Text = "<span weight=\"bold\" size=\"x-large\">Enter in a seed for the random name generator below.</span>";
			l1.UseMarkup = true;
			hbox1.PackStart (icon, false, true, 0);
			hbox1.PackEnd (l1, false, true, 0);			
			HBox hbox2 = new HBox (false, 0);
			Random r = new Random (DateTime.Now.Millisecond);
			Entry entry = new Entry (r.Next ().ToString ());
			hbox2.PackStart (new Label ("Enter seed integer:"), false, true, 0);
			hbox2.PackEnd (entry);
			d.VBox.PackStart (hbox1, false, true, 0);
			d.VBox.PackEnd (hbox2, true, true, 0);
			d.ShowAll ();
			int result = d.Run ();
			if ((ResponseType)result == ResponseType.Ok)
			{
				try
				{
					int seed = Convert.ToInt32 (entry.Text);
					this.HandleGenerateName (seed);
				}
				catch (ArgumentNullException ex)
				{
					this.ReportError (ex);
				}
				catch (FormatException ex)
				{
					this.ReportError (ex);
				}
				catch (OverflowException ex)
				{
					this.ReportError (ex);
				}
			}
			d.Hide ();
			d.Destroy ();
		}
		
		public void ReportError (Exception ex)
		{
			Dialog d = new Dialog (ex.GetType ().ToString (), this.window, DialogFlags.DestroyWithParent,
			                       Stock.Ok, ResponseType.Ok);
			Image icon = new Image ();
			icon.SetFromStock (Stock.DialogError, IconSize.Dialog);
			Label l1 = new Label ();
			l1.Text = "<span weight=\"bold\" size=\"x-large\">" + ex.GetType ().ToString () + "</span>";
			l1.UseMarkup = true;
			HBox hbox = new HBox (false, 0);
			hbox.PackStart (icon, false, true, 0);
			hbox.PackEnd (l1, true, true, 0);
			d.VBox.PackStart (hbox, false, true, 0);
			d.VBox.PackStart (new Label (ex.Message), false, true, 0);
			d.VBox.PackStart (new Label (ex.Source), false, true, 0);
			ScrolledWindow sw = new ScrolledWindow ();
			TextView tv = new TextView ();
			tv.Editable = false;
			tv.Buffer.Text = ex.StackTrace;
			sw.Add (tv);
			d.VBox.PackEnd (sw, true, true, 0);
			d.ShowAll ();
			d.Run ();
			d.Hide ();
			d.Destroy ();
		}
		
		private int namecount = 500;
		
		public void HandleGenerateName (int seed)
		{
			BattleName bname = new BattleName (seed);
			string name = bname.GenerateName ();
			this.AppendText (name);
			for (int i=0; i<this.namecount; i++)
			{
				BattleName n = new BattleName (bname.Rand);
				this.AppendText (n.GenerateName ());
			}
		}
		
		public void SetStatus (string message)
		{
			this.sbar.Push (0, message);
		}
		
		public void AppendText (string text)
		{
			string cur = this.textview.Buffer.Text;
			this.textview.Buffer.Text = cur + System.Environment.NewLine + text;
		}
		
		public void Show ()
		{
			this.window.ShowAll ();
		}
		
		public static void Main (string[] args)
		{
			Gtk.Application.Init ();
			Program p = new Program ();
			p.Build ();
			p.SetStatus ("Ready");
			p.Show ();
			Gtk.Application.Run ();
		}
	}
}

