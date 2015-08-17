//  
//  BattlelordsCharacterWindow.cs
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
using Gtk;
using Battle.Core;
using Battle.Data;

namespace Battle.Gui
{
	public class BattlelordsCharacterWindow : Gtk.Window
	{
		private BattlelordsSession session;
		public BattlelordsCharacterWindow (BattlelordsSession session) : base("Battlelords Character")
		{
			this.session = session;
			this.SetDefaultSize(400,600);
			this.SetPosition(WindowPosition.Center);
			this.build();
		}
		private void build()
		{
			VBox vb = new VBox();
			
			
			
			//ScrolledWindow sw = new ScrolledWindow();
			TreeStore ts = new TreeStore(typeof(string), typeof(string));
			foreach (BattlelordsRace r in this.session.Races)
			{
				ts.AppendValues(r.Name, r.Name);
			}
			TreeView tv = new TreeView(ts);
			tv.HeadersVisible = true;
			tv.AppendColumn("Race", new CellRendererText(), "text", 0);
			//sw.Add(tv);
			//this.Add(sw);
			
			
			Gtk.Notebook nb = new Gtk.Notebook();
			nb.AppendPage(tv, new Label("Race"));
			vb.PackStart(nb);
			//vb.PackEnd();
			
			
			this.ShowAll();
		}

	}
}

