//  
//  NewCharacterWindow.cs
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
	public class NewCharacterWindow : Gtk.Assistant
	{
		private Battle.Core.BattlelordsSession session;
		public NewCharacterWindow (Battle.Core.BattlelordsSession session)
		{
			this.session = session;
			this.SetDefaultSize(400,300);
			this.SetPosition(WindowPosition.Center);
			this.build();
		}

		void HandleHandleCancel (object sender, EventArgs e)
		{
			this.Destroy();
		}

		void HandleHandleClose (object sender, EventArgs e)
		{
			this.Destroy();
		}
		private void build()
		{
			this.Title = "New Battlelords Character";
			{
				// page 1 - intro
				Gtk.TextView tv = new Gtk.TextView();
				Gtk.TextBuffer tb;
				tb = tv.Buffer;
				//tb.Text = MediaManager.GetHtml("intro.html");
				tb.Text = "Welcome to the Battlelords Character Asistant.\n" +
					"\nThis will guide you thru the initial player character generation. " +
					"You will be presented with some initial options that can not change " +
					"once the character is created. " +
					"\nStep 1" +
					"\nStep 2" +
					"\nStep 3" +
					"\nStep 4" +
					"\nConculsion";
				tv.WrapMode = WrapMode.Word;
				tv.Editable = false;
				
				this.AppendPage(tv);
				this.SetPageTitle(tv, "Introduction");
				this.SetPageType(tv, AssistantPageType.Intro);
				this.SetPageComplete(tv, true);
			}
			{
				// page 2 - rolling method
				string method1 = "Percentile dice are rolled and marked down in order of the given visual statistics. " +
					"Eight rolls are initially made. The player then makes three additional dice rolls. " +
					"He has the option of replacing any three previously rolled statistics with one of these number. " +
					"Players may not move rolls around! First roll is Strength, second roll is Manual Dexterity, etc.";
				Gtk.VBox vb = new Gtk.VBox();
				Gtk.HBox hb1 = new Gtk.HBox();
				Gtk.Label lb1 = new Gtk.Label("Rolling Method");
				string[] entries = {"Method 1", "Method 2", "Method 3", "Fill In"};
				Gtk.ComboBox cb1 = new Gtk.ComboBox(entries);
				hb1.PackStart(lb1, true, false , 0);
				hb1.PackEnd(cb1, true, false, 0);
				cb1.Active = 0;
				Gtk.HBox hb2 = new Gtk.HBox();
				Gtk.CheckButton b1 = new Gtk.CheckButton("Max Body Points");
				Gtk.CheckButton b2 = new Gtk.CheckButton("Max Starting Money");
				b1.Active = true;
				b2.Active = true;
				hb2.PackStart(b1, true, false, 1);
				hb2.PackEnd(b2, true, false, 1);
				Gtk.ScrolledWindow sw = new Gtk.ScrolledWindow();				
				Gtk.TextView tv = new Gtk.TextView();
				tv.WrapMode = WrapMode.Word;
				tv.Editable = false;
				Gtk.TextBuffer tb = tv.Buffer;
				tb.Text = method1;
				sw.Add(tv);
				//vb.PackStart(hb1, false, false, 0);
				vb.PackStart(hb2, false, false, 0);
				//vb.PackEnd(sw, true, true, 0);

				this.AppendPage(vb);
				this.SetPageTitle(vb, "Rolling Options");
				this.SetPageType(vb, AssistantPageType.Content);
				this.SetPageComplete(vb, true);
			}
			{
				// page 3 - race
				TreeStore ts = new TreeStore(typeof(string), typeof(string));
				foreach (BattlelordsRace r in this.session.Races)
				{
					ts.AppendValues(r.Name, r.Name);
				}
				TreeView tv = new TreeView(ts);
				tv.HeadersVisible = true;
				tv.AppendColumn("Battlelords Race", new CellRendererText(), "text", 0);
				
				this.AppendPage(tv);
				this.SetPageTitle(tv, "Select Race");
				this.SetPageType(tv, AssistantPageType.Content);
				this.SetPageComplete(tv, true);
			}
			{
				// page 4 - Basics page
				/*
				 * 1 char name
				 * 2 player name
				 * 3 height
				 * 4 weight
				 * 5 body pts
				 * 6 start money
				 */
				Gtk.VBox vb2 = new Gtk.VBox();
				
				Gtk.HBox hb1 = new Gtk.HBox();
				Gtk.Label lb1 = new Gtk.Label("Player's Name:");
				Gtk.Entry en1 = new Gtk.Entry();
				hb1.PackStart(lb1, false, false, 0);
				hb1.PackStart(new Gtk.HSeparator(), true, false, 0);
				hb1.PackEnd(en1, true, true, 0);
				
				Gtk.HBox hb2 = new Gtk.HBox();
				Gtk.Label lb2 = new Gtk.Label("Character's Name:");
				Gtk.Entry en2 = new Gtk.Entry();
				hb2.PackStart(lb2, false, false, 0);
				hb2.PackStart(new Gtk.HSeparator(), true, false, 0);
				hb2.PackEnd(en2, true, true, 0);
				
				Gtk.HBox hb3 = new Gtk.HBox();
				Gtk.Label lb3 = new Gtk.Label("Height (ft):");
				Gtk.Entry en3 = new Gtk.Entry();
				en3.Sensitive = false;
				Gtk.Button b3 = new Gtk.Button();
				//b3.Label = "roll";
				b3.TooltipText = "Click here to roll height.";
				b3.Image = MediaManager.GetImageFromBaseFile("dice.png");
				hb3.PackStart(lb3, false, false, 0);
				hb3.PackStart(new Gtk.HSeparator(), true, false, 0);
				hb3.PackStart(en3, true, true, 0);
				hb3.PackEnd(b3, false, false, 0);

				Gtk.HBox hb4 = new Gtk.HBox();
				Gtk.Label lb4 = new Gtk.Label("Weight (lbs):");
				Gtk.Entry en4 = new Gtk.Entry();
				en4.Sensitive = false;
				Gtk.Button b4 = new Gtk.Button();
				//b4.Label = "roll";
				b4.TooltipText = "Click here to roll for weight.";
				b4.Image = MediaManager.GetImageFromBaseFile("dice.png");
				hb4.PackStart(lb4, false, false, 0);
				hb4.PackStart(new Gtk.HSeparator(), true, false, 0);
				hb4.PackStart(en4, true, true, 0);
				hb4.PackEnd(b4, false, false, 0);

				Gtk.HBox hb5 = new Gtk.HBox();
				Gtk.Label lb5 = new Gtk.Label("Body Points:");
				Gtk.Entry en5 = new Gtk.Entry();
				en5.Sensitive = false;
				Gtk.Button b5 = new Gtk.Button();
				b5.TooltipText = "Click here to roll for body points.";
				b5.Image = MediaManager.GetImageFromBaseFile("dice.png");
				hb5.PackStart(lb5, false, false, 0);
				hb5.PackStart(new Gtk.HSeparator(), true, false, 0);
				hb5.PackStart(en5, true, true, 0);
				hb5.PackEnd(b5, false, false, 0);

				Gtk.HBox hb6 = new Gtk.HBox();
				Gtk.Label lb6 = new Gtk.Label("Starting Money:");
				Gtk.Entry en6 = new Gtk.Entry();
				en6.Sensitive = false;
				Gtk.Button b6 = new Gtk.Button();
				b6.TooltipText = "Click here to roll for starting money.";
				b6.Image = MediaManager.GetImageFromBaseFile("dice.png");
				hb6.PackStart(lb6, false, false, 0);
				hb6.PackStart(new Gtk.HSeparator(), true, false, 0);
				hb6.PackStart(en6, true, true, 0);
				hb6.PackEnd(b6, false, false, 0);

				vb2.PackStart(hb1, false, false, 0);
				vb2.PackStart(hb2, false, false, 0);				
				vb2.PackStart(hb3, false, false, 0);				
				vb2.PackStart(hb4, false, false, 0);				
				vb2.PackStart(hb5, false, false, 0);				
				vb2.PackStart(hb6, false, false, 0);				

				this.AppendPage(vb2);
				this.SetPageTitle(vb2, "Enter Basic Information");
				this.SetPageType(vb2, AssistantPageType.Content);
				this.SetPageComplete(vb2, true);
			}
			{
				// page 5 - vitals
				VBox vb5 = new VBox();
				Gtk.Notebook nb = new Gtk.Notebook();
				//Battle.Gui.VitalsControl stvc = new Battle.Gui.VitalsControl(this.session);
				//stvc.Sensitive = false;
				VitalsControl m1vitals = new VitalsControl(this.session);
				VitalsControl m2vitals = new VitalsControl(this.session);
				VitalsControl m3vitals = new VitalsControl(this.session);
				VitalsControl fillvitals = new VitalsControl(this.session);
				
				m1vitals.Enabled = false;
				m2vitals.Enabled = false;
				m3vitals.Enabled = false;
				
				nb.AppendPage(m1vitals, new Gtk.Label("Method 1"));
				nb.AppendPage(m2vitals, new Gtk.Label("Method 2"));
				nb.AppendPage(m3vitals, new Gtk.Label("Method 3"));
				nb.AppendPage(fillvitals, new Gtk.Label("Fill In"));
				
				HButtonBox bb5 = new HButtonBox();
				Button rollBtn = new Button(Stock.Execute);
				rollBtn.Clicked += delegate(object sender, EventArgs e) {
					Console.WriteLine("{0}", sender.GetType().ToString());
				};
				rollBtn.Label = "Roll";
				Button saveBtn = new Button(Stock.Save);
				saveBtn.Label = "Save";
				bb5.PackStart(rollBtn);
				bb5.PackEnd(saveBtn);
				nb.SwitchPage += delegate(object o, SwitchPageArgs args) {
					if (args.PageNum == 3)
					{
						rollBtn.Sensitive = false;
					}
					else {
						rollBtn.Sensitive = true;
					}
				};
				
				vb5.Add(nb);
				vb5.Add(bb5);

				this.AppendPage(vb5);
				this.SetPageTitle(vb5, "Enter Vitals");
				this.SetPageType(vb5, AssistantPageType.Content);
				this.SetPageComplete(vb5, true);
				
			}
			{
				// page 6 - secondaries
				Gtk.Label not_completed_label = new Gtk.Label("not completed");
				Pango.FontDescription d = new Pango.FontDescription();
				d.Style =  Pango.Style.Italic;
				not_completed_label.ModifyFont(d);
				
				this.AppendPage(not_completed_label);
				this.SetPageTitle(not_completed_label, "Enter Secondary Attributes");
				this.SetPageType(not_completed_label, AssistantPageType.Content);
				this.SetPageComplete(not_completed_label, true);
			}
			{
				// page 7 - fate
				Gtk.Label not_completed_label = new Gtk.Label("not completed");
				Pango.FontDescription d = new Pango.FontDescription();
				d.Style =  Pango.Style.Italic;
				not_completed_label.ModifyFont(d);
				
				this.AppendPage(not_completed_label);
				this.SetPageTitle(not_completed_label, "Determine Fate");
				this.SetPageType(not_completed_label, AssistantPageType.Content);
				this.SetPageComplete(not_completed_label, true);
			}
			{ 
				// page 8 - social
				Gtk.Label not_completed_label = new Gtk.Label("not completed");
				Pango.FontDescription d = new Pango.FontDescription();
				d.Style =  Pango.Style.Italic;
				not_completed_label.ModifyFont(d);
				
				this.AppendPage(not_completed_label);
				this.SetPageTitle(not_completed_label, "Social Status");
				this.SetPageType(not_completed_label, AssistantPageType.Content);
				this.SetPageComplete(not_completed_label, true);
			}
			{
				// page 9 - skills
				Gtk.Label not_completed_label = new Gtk.Label("not completed");
				Pango.FontDescription d = new Pango.FontDescription();
				d.Style =  Pango.Style.Italic;
				not_completed_label.ModifyFont(d);
				
				this.AppendPage(not_completed_label);
				this.SetPageTitle(not_completed_label, "Choose Initial Skills");
				this.SetPageType(not_completed_label, AssistantPageType.Content);
				this.SetPageComplete(not_completed_label, true);
			}
			{
				// page 10 - matrixes
				Gtk.Label not_completed_label = new Gtk.Label("not completed");
				Pango.FontDescription d = new Pango.FontDescription();
				d.Style =  Pango.Style.Italic;
				not_completed_label.ModifyFont(d);
				
				this.AppendPage(not_completed_label);
				this.SetPageTitle(not_completed_label, "Choose Initial Matrixes");
				this.SetPageType(not_completed_label, AssistantPageType.Content);
				this.SetPageComplete(not_completed_label, true);
			}
			{
				// page 11 - confirm
				TextView tv11 = new TextView();
				TextBuffer b11 = tv11.Buffer;
				b11.Text = "Confirm this new character.";
				tv11.Editable = false;
				this.AppendPage(tv11);
				this.SetPageTitle(tv11, "Confirm New Character");
				this.SetPageType(tv11, AssistantPageType.Confirm);
				this.SetPageComplete(tv11, true);
			}
			this.Close += HandleHandleClose;
			this.Cancel += HandleHandleCancel;
			this.ShowAll();
		}
	}
}

