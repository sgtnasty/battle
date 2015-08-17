//  
//  PreferencesDialog.cs
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
	public class PreferencesDialog : Gtk.Dialog
	{
		private BattlelordsSession session;
		public PreferencesDialog (BattlelordsSession session) : base()
		{
			this.session = session;
			this.build();
		}
		private Gtk.VBox vb1;
		private Gtk.Button cancelBtn;
		private Gtk.Button applyBtn;
		private Gtk.Button saveBtn;
		private Gtk.ScrolledWindow sw1;
		private Gtk.Expander generalExp;
		private Gtk.Expander sourcesExp;
		private Gtk.Expander generationExp;
		private Gtk.Expander printExp;
		private Gtk.Expander reportExp;
		private void build()
		{
			this.Modal = true;
			this.HeightRequest = 400;
			this.WidthRequest = 600;
			this.Title = "Battle Preferences";
			this.IconName = Stock.Preferences;
			this.vb1 = new VBox(true, 1);
			this.sw1 = new ScrolledWindow();
			this.generalExp = new Expander("General Options");
			this.generalExp.Add(new Label("Print some options description here"));
			this.sourcesExp = new Expander("Sources");
			this.generationExp = new Expander("Generation Options");
			this.printExp = new Expander("Print Options");
			this.reportExp = new Expander("Report Options");
			this.vb1.PackStart(generalExp, false, true, 1);
			this.vb1.PackStart(sourcesExp, false, true, 1);
			this.vb1.PackStart(generationExp, false, true, 1);
			this.vb1.PackStart(printExp, false, true, 1);
			this.vb1.PackStart(reportExp, false, true, 1);
			this.sw1.Add(this.vb1);
			this.cancelBtn = new Button("Cancel");
			this.applyBtn = new Button("Apply");
			this.saveBtn = new Button("Save");
			this.cancelBtn.Image = new Image(Stock.Cancel, Gtk.IconSize.Button);
			this.applyBtn.Image = new Image(Stock.Apply, Gtk.IconSize.Button);
			this.saveBtn.Image = new Image(Stock.Save, IconSize.Button);
			this.ActionArea.PackStart(cancelBtn, false, false, 1);
			this.ActionArea.PackStart(applyBtn, false, false, 1);
			this.ActionArea.PackEnd(saveBtn, false, false, 1);
			this.VBox.PackStart(this.sw1, true, true, 1);
			this.ShowAll();
		}
	}
}
