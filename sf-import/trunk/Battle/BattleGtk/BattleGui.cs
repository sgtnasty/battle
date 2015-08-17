// 
//  BattleGui.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sf.net>
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
using Glade;
using BattleEngine;

namespace BattleGtk
{
	public class BattleGui : IBattleGui, IConsole
	{
		public BattleGui ()
		{
			this.attack_dialog = null;
		}
		
		const string GladeResource = "BattleGtk.BattleGtk.glade";
		const string BattleIconRes = "BattleGtk.Resources.battleicon00.jpg";
		
		private Glade.XML glade;
		[Glade.Widget]
		private Gtk.Window window1;
		[Glade.Widget]
		private Gtk.ToolButton quit_toolbutton;
		[Glade.Widget]
		private Gtk.TextView console_textview;
		[Glade.Widget]
		private Gtk.Statusbar statusbar1;
		[Glade.Widget]
		private ToolButton addplayer_toolbutton;
		[Glade.Widget]
		private ToolButton rollchar_toolbutton;
		[Glade.Widget]
		private ToolButton battle_toolbutton;
		public BattleEngine.Game GameEngine
		{
			get;
			private set;
		}
		
		#region IConsole implementation
		public void ConsoleWrite (string message)
		{
			TextIter end = this.console_textview.Buffer.EndIter;
			this.console_textview.Buffer.Insert 
				(ref end, message);
			TextMark m = this.console_textview.Buffer.CreateMark 
				(null, end, false);
			this.console_textview.ScrollMarkOnscreen (m);
		}

		public void ConsoleWriteLine (string message)
		{
			this.ConsoleWrite (message + System.Environment.NewLine);
		}
		#endregion

		#region IBattleGui implementation
		public void Init (Game game)
		{
			this.GameEngine = game;
			this.GameEngine.BattleGui = this;
			Gtk.Application.Init ();
			this.glade = new Glade.XML (this.GetType ().Assembly, 
			                            GladeResource, "window1", null);
			this.glade.Autoconnect (this);
			
			this.window1.SetDefaultSize (1000, 600);
			this.addplayer_toolbutton.TooltipText = "Add a player to the mix";
			this.rollchar_toolbutton.TooltipText = "Roll attributes for all players";
			this.quit_toolbutton.TooltipText = "Quit BattleGui client";
			this.console_textview.ModifyBase (StateType.Normal, new Gdk.Color (0, 0, 0));
			this.console_textview.ModifyText (StateType.Normal, new Gdk.Color (196, 196, 196));
			
			this.window1.Icon = Gdk.Pixbuf.LoadFromResource (BattleIconRes);
			
			// event handler config
			this.window1.DeleteEvent += HandleWindow1DeleteEvent;
			this.addplayer_toolbutton.Clicked += HandleAddplayer_toolbuttonClicked;
			this.rollchar_toolbutton.Clicked += HandleRollchar_toolbuttonClicked;
			this.battle_toolbutton.Clicked += HandleBattle_toolbuttonClicked;
			this.quit_toolbutton.Clicked += HandleQuit_toolbuttonClicked;
			
			this.statusbar1.Push (0, "Ready");			
		}

		public void Run ()
		{
			this.window1.ShowAll ();
			this.GameEngine.GuiLoaded ();
			Gtk.Application.Run ();
		}
		
		public void DoEvents ()
		{
			Gtk.Application.RunIteration (true);
		}
		
		#endregion

		private Dialog attack_dialog;
		private VBox atkdlg_vbox;
		private void build_attack_dialog ()
		{
			if (this.attack_dialog != null)
			{
				this.attack_dialog.Hide ();
				this.attack_dialog.Dispose ();
			}
			this.attack_dialog = new Dialog ();
			this.attack_dialog.Title = "Attack";
			this.attack_dialog.KeepAbove = true;
			this.attack_dialog.Modal = false;
			this.attack_dialog.SkipPagerHint = true;
			this.attack_dialog.SkipTaskbarHint =true;
			this.attack_dialog.WindowPosition = WindowPosition.Center;
			ScrolledWindow sw = new ScrolledWindow ();
			Viewport vp = new Viewport ();
			this.atkdlg_vbox = new VBox();
			Label header= new Label();
			header.UseMarkup = true;
			header.LabelProp = "<b>Battle Details</b>";
			this.atkdlg_vbox.PackStart (header, false, true, 3);
			vp.Add (this.atkdlg_vbox);
			sw.Add (vp);
			this.attack_dialog.SetDefaultSize (400, 200);
			this.attack_dialog.VBox.PackStart (sw, true, true, 3);
			//this.attack_dialog.AddButton ("Close", ResponseType.Close);
		}
		
		public void ShowAttackDialog (string details)
		{
			if (attack_dialog == null)
			{
				this.build_attack_dialog ();
			}
			Label lbl = new Label ();
			lbl.UseMarkup = true;
			lbl.LabelProp = details;
			this.atkdlg_vbox.PackStart (lbl, false, true, 3);			
			this.attack_dialog.ShowAll ();
		}

		void SetControlState (bool sensitive)
		{
			this.addplayer_toolbutton.Sensitive = sensitive;
			this.battle_toolbutton.Sensitive = sensitive;
			this.quit_toolbutton.Sensitive = sensitive;
			this.rollchar_toolbutton.Sensitive = sensitive;
		}

		void HandleAddplayer_toolbuttonClicked (object sender, EventArgs e)
		{
			BattleEngine.RandomName rname = new BattleEngine.RandomName (this.GameEngine.RandomEngine);
			BattleEngine.Player.Player p = new BattleEngine.Player.Player (rname.GetRandomName ());
			
			this.GameEngine.AddPlayer (p);
		}
		
		void HandleRollchar_toolbuttonClicked (object sender, EventArgs e)
		{
			this.SetControlState (false);
			try 
			{
				this.GameEngine.RollAttributes ();
			}
			catch (Exception exp)
			{
				MessageDialog d = new MessageDialog (this.window1, DialogFlags.DestroyWithParent,
				                                     MessageType.Error,
				                                     ButtonsType.Close,
				                                     true,
				                                     "<b>{0}</b>: {1}\n<i>{2}</i>",
				                                     exp.GetType().ToString (),
				                                     exp.Message,
				                                     exp.Source);
				d.Title = "Error";
				d.Modal = true;
				this.ConsoleWriteLine (exp.StackTrace);
				d.Run ();
				d.Hide ();
				d.Dispose ();
			}
			this.SetControlState (true);
		}

		void HandleBattle_toolbuttonClicked (object sender, EventArgs e)
		{
			this.SetControlState (false);
			try
			{
				this.build_attack_dialog ();
				this.GameEngine.Battle ();
			}
			catch (Exception exp)
			{
				MessageDialog d = new MessageDialog (this.window1, DialogFlags.DestroyWithParent,
				                                     MessageType.Error,
				                                     ButtonsType.Close,
				                                     true,
				                                     "<b>{0}</b>: {1}\n<i>{2}</i>",
				                                     exp.GetType().ToString (),
				                                     exp.Message,
				                                     exp.Source);
				d.Title = "Error";
				d.Modal = true;
				this.ConsoleWriteLine (exp.StackTrace);
				d.Run ();
				d.Hide ();
				d.Dispose ();
			}
			this.SetControlState (true);
		}
		
		public void ExitClientApplication ()
		{
			if (this.attack_dialog != null)
			{
				this.attack_dialog.Hide ();
				this.attack_dialog.Dispose ();
			}
			Gtk.Application.Quit ();
		}

		void HandleQuit_toolbuttonClicked (object sender, EventArgs e)
		{
			this.ExitClientApplication ();
		}

		void HandleWindow1DeleteEvent (object o, DeleteEventArgs args)
		{
			this.ExitClientApplication ();
		}
	
	}
}

