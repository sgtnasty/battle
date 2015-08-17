//  
//  VitalsControl.cs
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
using Battle;

namespace Battle.Gui
{
	public class VitalsControl : Gtk.Frame
	{
		private Battle.Core.BattlelordsSession session;
		public VitalsControl (Battle.Core.BattlelordsSession session) : base()
		{
			this.session = session;
			this.build();
		}
		private bool enabled;
		private Gtk.VBox vbox1;
		private Gtk.Label label1;
		private Battle.Gui.VitalWidget stWidget;
		private Battle.Gui.VitalWidget mdWidget;
		private Battle.Gui.VitalWidget iqWidget;
		private Battle.Gui.VitalWidget agWidget;
		private Battle.Gui.VitalWidget cnWidget;
		private Battle.Gui.VitalWidget inWidget;
		private Battle.Gui.VitalWidget arWidget;
		private Battle.Gui.VitalWidget chWidget;
		public VitalWidget StrengthWidget {
			get {
				return stWidget;
			}
		}
		
		
		public VitalWidget ManualDexterityWidget {
			get {
				return mdWidget;
			}
		}
		
		
		public VitalWidget IqWidget {
			get {
				return iqWidget;
			}
		}
		
		
		public VitalWidget IntuitionWidget {
			get {
				return inWidget;
			}
		}
		
		
		public VitalWidget ConstitutionWidget {
			get {
				return cnWidget;
			}
		}
		
		
		public VitalWidget CharismaWidget {
			get {
				return chWidget;
			}
		}
		
		
		public VitalWidget ArWidget {
			get {
				return arWidget;
			}
		}
		
		
		public VitalWidget AgWidget {
			get {
				return agWidget;
			}
		}
		
		public bool Enabled {
			get {
				return enabled;
			}
			set {
				enabled = value;
				this.stWidget.Enabled = Enabled;
				this.mdWidget.Enabled = Enabled;
				this.iqWidget.Enabled = Enabled;
				this.agWidget.Enabled = Enabled;
				this.cnWidget.Enabled = Enabled;
				this.inWidget.Enabled = Enabled;
				this.arWidget.Enabled = Enabled;
				this.chWidget.Enabled = Enabled;
			}
		}
		private void build()
		{
			this.vbox1 = new VBox();
			this.label1 = new Label("Vital Statistics");
			Pango.FontDescription d = new Pango.FontDescription();
			d.Weight = Pango.Weight.Bold;
			this.label1.ModifyFont(d);
			this.stWidget = new VitalWidget(this.session, "Strength", 40);
			this.mdWidget = new VitalWidget(this.session, "Manual Dexterity", 40);
			this.iqWidget = new VitalWidget(this.session, "I.Q.", 40);
			this.agWidget = new VitalWidget(this.session, "Agility", 40);
			this.cnWidget = new VitalWidget(this.session, "Constitution", 40);
			this.inWidget = new VitalWidget(this.session, "Intuition", 40);
			this.arWidget = new VitalWidget(this.session, "Agression", 40);
			this.chWidget = new VitalWidget(this.session, "Charisma", 40);
			this.vbox1.PackStart(this.label1, true, true, 0);
			this.vbox1.PackStart(this.stWidget, true, true, 0);
			this.vbox1.PackStart(this.mdWidget, true, true, 0);
			this.vbox1.PackStart(this.iqWidget, true, true, 0);
			this.vbox1.PackStart(this.agWidget, true, true, 0);
			this.vbox1.PackStart(this.cnWidget, true, true, 0);
			this.vbox1.PackStart(this.inWidget, true, true, 0);
			this.vbox1.PackStart(this.arWidget, true, true, 0);
			this.vbox1.PackStart(this.chWidget, true, true, 0);
			this.Add(this.vbox1);
		}
	}
}

