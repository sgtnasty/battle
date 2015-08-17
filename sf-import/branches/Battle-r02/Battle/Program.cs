// 
//  Program.cs
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
using Glade;
using Gtk;

using Battle.Core;
using Battle.Data;
using Battle.Gui;

namespace Battle
{
	public class Program
	{
		public Program ()
		{
			Application.Init();
			this.session = new Battle.Core.BattleSession();
			Console.WriteLine(Environment.CurrentDirectory);
			Glade.XML gxml = new Glade.XML (null, "Battle.battle.glade", "window1", null);
			gxml.Autoconnect (this);
			
			window1.DeleteEvent += HandleWindow1DeleteEvent;
			statusbar1.Push(0, "Ready");
			
			this.aboutbutton.Clicked += HandleAboutbuttonClicked;
			
			this.treeview1.AppendColumn("Source", new CellRendererText (), "text", 0);
			this.treeview1.AppendColumn("Description", new CellRendererText (), "text", 1);

			store = new TreeStore (typeof (string), typeof (string));
			TreeIter i = store.AppendValues("Origins", "0 loaded");
			foreach (Battle.Core.OriginDefinition o in this.session.Origins)
			{
				store.AppendValues(i, o.Name, o.Description);
			}
			store.SetValue(i, 1, string.Format("{0} loaded", this.session.Origins.Length));
			i = store.AppendValues("Species", "0 loaded");
			foreach (Battle.Core.SpeciesDefinition s in this.session.Species)
			{
				store.AppendValues(i, s.Name, s.Description);
			}
			store.SetValue(i, 1, string.Format("{0} loaded", this.session.Species.Length));
			i = store.AppendValues("Skills", "0 loaded");
			foreach (Battle.Core.SkillDefinition d in this.session.Skills)
			{
				store.AppendValues(i, d.Name, d.Description);
			}
			store.SetValue(i, 1, string.Format("{0} loaded", this.session.Skills.Length));
			i = store.AppendValues("Power Sources", "0 loaded");
			foreach (Battle.Core.PowerSource p in this.session.PowerSources)
			{
				store.AppendValues(i, p.Name, p.Description);
			}
			store.SetValue(i, 1, string.Format("{0} loaded", this.session.PowerSources.Length));
			i = store.AppendValues("Powers", "0 loaded");
			foreach (Battle.Core.PowerDefinition p in this.session.Powers)
			{
				store.AppendValues(i, p.Name, p.Description);
			}
			store.SetValue(i, 1, string.Format("{0} loaded", this.session.Powers.Length));
			
			i = store.AppendValues("Characters", "0 loaded");
			i = store.AppendValues("Adventures", "0 loaded");
			
			this.treeview1.Model = store;
			
			this.hpaned1.Position = 256;
			
			this.viewport1.Add(new Label("Battle"));
			
			this.treeview1.CursorChanged += HandleTreeview1CursorChanged;
			
			session.PrepCoreRules();
			
			window1.ShowAll();
			
			Application.Run();
		}

		#region About Dialog
		void HandleAboutbuttonClicked (object sender, EventArgs e)
		{
			AboutDialog dialog = new AboutDialog ();
			Assembly asm = Assembly.GetExecutingAssembly ();
			
			dialog.ProgramName = (asm.GetCustomAttributes (
				typeof (AssemblyTitleAttribute), false) [0]
				as AssemblyTitleAttribute).Title;
			
			dialog.Version = asm.GetName ().Version.ToString ();
			
			dialog.Comments = (asm.GetCustomAttributes (
				typeof (AssemblyDescriptionAttribute), false) [0]
				as AssemblyDescriptionAttribute).Description;
			
			dialog.Copyright = (asm.GetCustomAttributes (
				typeof (AssemblyCopyrightAttribute), false) [0]
				as AssemblyCopyrightAttribute).Copyright;
			
			dialog.License = license;
			
			dialog.Authors = authors;
			
			dialog.Run ();
		}

		private static string [] authors = new string [] {
			"Ronaldo Nascimento <ronaldo1@users.sourceforge.net>"
		};
	
	private static string license =
@"Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
""Software""), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";
		#endregion

		void HandleTreeview1CursorChanged (object sender, EventArgs e)
		{
			TreeIter i = new TreeIter();
			if (this.treeview1.Selection.GetSelected(out i))
			{
				TreePath tp = store.GetPath(i);
				string name = (string) store.GetValue(i, 0); 
				this.statusbar1.Push(0, tp.ToString());
				string tpath = tp.ToString();
				string[] parts = tpath.Split(new char[] { ':' });
				int ident = int.Parse(parts[0]);
				switch (ident)
				{
				case 0:
					// origins
					OriginDefinition o = this.session.FindOrigin(name);
					if (o != null)
					{
						this.viewport1.Remove(this.viewport1.Child);
						this.viewport1.Add(new Gui.OriginView(this.session, o));
						this.viewport1.ShowAll();
					}
					break;
				default:
					this.viewport1.Remove(this.viewport1.Child);
					this.viewport1.Add(new Label("Battle"));
					this.viewport1.ShowAll();
					break;
				}
			}
		}
		
		void HandleWindow1DeleteEvent (object o, DeleteEventArgs args)
		{
			Application.Quit();
		}
		
		private Battle.Core.BattleSession session;
		private TreeStore store;
		
		[Glade.Widget]
		Gtk.Window window1;
		
		[Glade.Widget]
		Gtk.Statusbar statusbar1;
		
		//[Glade.Widget]
		//Gtk.Table table1;
		
		[Glade.Widget]
		Gtk.TreeView treeview1;
		
		[Glade.Widget]
		Gtk.HPaned hpaned1;
		
		[Glade.Widget]
		Gtk.Viewport viewport1;
		
		[Glade.Widget]
		Gtk.ToolButton aboutbutton;
		
		public static void Main(string[] args)
		{
			try {
				Program p = new Program();
				Console.WriteLine(p.ToString());
			}
			catch (Exception exp)
			{
				MessageDialog d = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
				                                    ButtonsType.Close, "{0}: {1}", exp.GetType().ToString(),
				                                    exp.Message);
				d.Title = "Battle Error";
				d.Run();
				d.Destroy();
			}
		}
	}
}

