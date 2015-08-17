// 
//  OriginView.cs
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
using System.Collections.Generic;

using Gtk;

using Battle.Core;

namespace Battle.Gui
{
	public class OriginView : Gtk.Table
	{
		public OriginView (Battle.Core.BattleSession session, Battle.Core.OriginDefinition orig) : base(5, 2, false)
		{
			this.SizeRequested += HandleSizeRequested;
			this.SizeAllocated += HandleSizeAllocated;
			//this.session = session;
			//this.orig = orig;
			
			Label label1 = new Label("Name: ");
			Label label2 = new Label("Description: ");
			Entry entry1 = new Entry();
			Entry entry2 = new Entry();
			
			entry1.IsEditable = false;
			entry1.Text = orig.Name;
			
			entry2.IsEditable = false;
			entry2.Text = orig.Description;
			
			Gtk.TreeStore store1 = new Gtk.TreeStore(typeof(string));
			foreach (string prov in orig.Provides())
			{
				//string[] vs = new string[1];
				//vs[0] = prov;
				//store1.AppendValues(vs);
				TreeIter i =  store1.AppendNode();
				store1.SetValue(i, 0, prov);
			}
			TreeView treeview1 = new TreeView(store1);
			treeview1.AppendColumn("Provides", new CellRendererText(), "text", 0);

			Gtk.TreeStore store2 = new Gtk.TreeStore(typeof(string));
			foreach (string req in orig.Requires())
			{
				string[] vs = new string[1];
				vs[0] = req;
				store1.AppendValues(vs);
			}
			TreeView treeview2 = new TreeView(store2);
			treeview2.AppendColumn("Requires", new CellRendererText(), "text", 0);
			
			this.Attach(new Label("Origin"), 0, 2, 0, 1, AttachOptions.Expand, AttachOptions.Fill, 0, 0);
			
			this.Attach(label1, 0, 1, 1, 2, AttachOptions.Shrink, AttachOptions.Shrink, 0, 0);
			this.Attach(entry1, 1, 2, 1, 2, AttachOptions.Fill, AttachOptions.Fill, 0, 0);
			
			this.Attach(label2, 0, 1, 2, 3, AttachOptions.Shrink, AttachOptions.Shrink, 0, 0);
			this.Attach(entry2, 1, 2, 2, 3, AttachOptions.Fill, AttachOptions.Fill, 0, 0);
			
			this.Attach(treeview1, 0, 2, 3, 4, AttachOptions.Fill, AttachOptions.Fill, 1, 1);
			
			this.Attach(treeview2, 0, 2, 4, 5, AttachOptions.Fill, AttachOptions.Fill, 1, 1);
		}
		
		void HandleSizeAllocated (object o, SizeAllocatedArgs args)
		{
			this.SetSizeRequest(400, 64);
		}

		void HandleSizeRequested (object o, SizeRequestedArgs args)
		{
			Requisition req = args.Requisition;
			if (req.Width< 400) req.Width = 400;
			if (req.Height< 64) req.Height = 64;
			args.Requisition = req;
		}
	}
}