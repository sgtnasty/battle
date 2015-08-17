//  
//  VitalWidget.cs
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

namespace Battle.Gui
{
	public class VitalWidget : Gtk.Frame
	{
		private BattlelordsSession session;
		private string vitalname;
		private int vital;
		public int Vital {
			get {
				return vital;
			}
			set {
				vital = value;
			}
		}
		public string Vitalname {
			get {
				return vitalname;
			}
		}
		private bool enabled;
		public bool Enabled {
			get {
				return enabled;
			}
			set {
				enabled = value;
				this.sbutton1.Sensitive = enabled;
			}
		}
		
		
		public VitalWidget (BattlelordsSession session, string vitalname, int vitalvalue) : base()
		{
			this.session = session;
			this.vitalname = vitalname;
			this.vital = vitalvalue;
			this.build();
		}
		private Gtk.HBox hbox1;
		private Gtk.Label label1;
		private Gtk.SpinButton sbutton1;
		private Gtk.Label label2;
		private Gtk.Entry entry2;
		private Gtk.Label label3;
		private Gtk.Entry entry3;
		private void build()
		{
			//this.img1 = new Image(Stock.Dnd);
			this.sbutton1 = new SpinButton(0.0,200.0,1.0);
			this.sbutton1.Value = this.vital;
			this.sbutton1.WidthRequest = 50;
			this.sbutton1.ValueChanged += delegate(object sender, EventArgs e) {
				this.calc_total();
			};
			this.label1 = new Label(this.vitalname);
			this.label1.WidthRequest = 100;
			this.label2 = new Label("racial");
			this.label2.WidthRequest = 50;
			this.label3 = new Label("total");
			this.label3.WidthRequest = 50;
			this.entry2 = new Entry("0");
			this.entry2.IsEditable = false;
			this.entry2.WidthRequest = 50;
			this.entry3 = new Entry(this.sbutton1.Value.ToString());
			this.entry3.IsEditable = false;
			this.entry3.WidthRequest = 50;
			
			this.sbutton1.TooltipText = "Player's value";
			this.entry2.TooltipText = this.label1.Text + " racial bonus";
			this.entry3.TooltipText = this.label1.Text + " total (racial + player)";
			
			this.hbox1 = new HBox(false, 1);
			this.hbox1.Homogeneous = false;
			this.hbox1.PackStart(this.label1, false, false, 0);
			this.hbox1.PackStart(this.sbutton1, false, false, 0);
			this.hbox1.PackStart(new HSeparator(), false, false, 2);
			this.hbox1.PackStart(this.label2, false, false, 0);
			this.hbox1.PackStart(this.entry2, false, false, 0);
			this.hbox1.PackStart(new HSeparator(), false, false, 2);
			this.hbox1.PackStart(this.label3, false, false, 0);
			this.hbox1.PackStart(this.entry3, false, false, 0);
			this.Add(hbox1);
		}
		private void calc_total()
		{
			int v1 = int.Parse(this.sbutton1.Value.ToString());
			int r1 = int.Parse(this.entry2.Text);
			int t1 = r1 + v1;
			this.entry3.Text = t1.ToString();
			Console.WriteLine("recalc");
		}
	}
}

