// 
//  MainWindow.cs
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
using Gtk;

namespace Battle.Gui
{
	public class MainWindow : Gtk.Window, IBattleWindow
	{
		public MainWindow (Battle.Core.BattleSession session) : base("Battle")
		{
			this.session = session;
			this.build();
		}
		private Battle.Core.BattleSession session;
		
		#region User Interface
		private VBox vbox1;
		private Statusbar statusbar1;
		private Toolbar toolbar1;
		private ToolButton aboutbtn1;
		private HPaned hpaned1;
		private ScrolledWindow scrollw1;
		private TreeView treeview1;
		private IconView iconview1;
		private TreeStore treestore1;
		
		private void build()
		{
			this.vbox1 = new VBox();

			this.toolbar1 = new Toolbar();
			this.aboutbtn1 = new ToolButton(Stock.About);
			this.aboutbtn1.Label = "About";
			this.aboutbtn1.IsImportant = true;
			this.toolbar1.ToolbarStyle = ToolbarStyle.BothHoriz;
			this.toolbar1.Add(this.aboutbtn1);
			this.vbox1.PackStart(this.toolbar1, false, true, 0);
			
			this.treestore1 = this.populateTreeStoreFromSession();
			this.scrollw1 = new ScrolledWindow();
			this.hpaned1 = new HPaned();
			this.treeview1 = new TreeView(this.treestore1);
			this.treeview1.HeadersVisible = true;
			this.treeview1.AppendColumn("Session", new CellRendererText(), "text", 0);
			this.treeview1.AppendColumn("Name", new CellRendererText(), "text", 1);
			this.treeview1.ExpandAll();
			this.scrollw1.Add(this.treeview1);
			this.iconview1 = new IconView();
			this.hpaned1.Add1(this.scrollw1);
			this.hpaned1.Add2(this.iconview1);
			this.hpaned1.Position = 254;
			this.vbox1.PackStart(this.hpaned1, true, true, 0);
			
			this.statusbar1 = new Statusbar();
			this.vbox1.PackEnd(this.statusbar1, false, true, 0);
			
			this.Add(this.vbox1);
			this.SetSizeRequest(800,600);
			
			this.DeleteEvent += HandleDeleteEvent;
		}

		void HandleDeleteEvent (object o, DeleteEventArgs args)
		{
			this.session.Stop();
		}
		
		private TreeStore populateTreeStoreFromSession()
		{
			TreeStore ts = new TreeStore(typeof(string), typeof(string));
			TreeIter iter;
			TreeIter parent = ts.AppendNode();
			iter = parent;
			ts.SetValues(iter, "Nanoc","Human, male");
			iter = ts.AppendNode(iter);
			ts.SetValues(iter, "Abilities", "");
			ts.AppendValues(iter, "Charisma","0");
			ts.AppendValues(iter, "Dexterity","+1");
			ts.AppendValues(iter, "Intelligence", "0");
			ts.AppendValues(iter, "Power","0");
			ts.AppendValues(iter, "Perception","+1");
			ts.AppendValues(iter, "Strength","+4");
			ts.AppendValues(iter, "Stamina","+2");
			ts.AppendValues(iter, "Willpower","+1");
			iter = ts.AppendNode(parent);
			ts.SetValues(iter, "Experience", "");
			ts.AppendValues(iter, "Level", "1");
			ts.AppendValues(iter, "Barbarian", "230");
			iter = ts.AppendNode(parent);
			ts.SetValues(iter, "Adventures", "");
			return ts;
		}

		#endregion
		
		#region IBattleWindow Implementation
		public void Notify()
		{
			//TODO: this is where we are notified that the session info has changed
			this.statusbar1.Push(0, "Notified");
		}
		public void UpdateStatus(uint context_id, string message)
		{
			this.statusbar1.Push(context_id, message);
		}
		#endregion
	}
}

