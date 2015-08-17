// 
//  Program.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using BattleEngine;

namespace Battle
{
	public class Program
	{
		public Program (string[] args)
		{
			Console.WriteLine (System.Environment.MachineName);
			Console.WriteLine (System.Environment.OSVersion.Platform.ToString ());
			Console.WriteLine (System.Environment.OSVersion.VersionString);
			Console.WriteLine (System.Environment.ProcessorCount.ToString ());
			Console.WriteLine (System.Environment.UserName);
			Console.WriteLine (System.Environment.Version.ToString ());
			Console.WriteLine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.LocalApplicationData));
			
			this.battle_gui_assembly = 
				ConfigurationManager.AppSettings["client-assembly"];
			this.battle_gui_typename = 
				ConfigurationManager.AppSettings["client-type"];
		}
		
		public void InitEngine ()
		{
			Console.WriteLine ("loading BattleEngine ...");
			this.game = new Game ();
		}
		
		public void InitClient ()
		{
			Console.Write ("loading Battle client library ");
			string battle_gui_fulltypename = string.Format("{0}.{1}",
			                   this.battle_gui_assembly,
			                   this.battle_gui_typename);
			Console.WriteLine (battle_gui_fulltypename);
			System.Runtime.Remoting.ObjectHandle oh = 
				Activator.CreateInstance (this.battle_gui_assembly, 
				                          battle_gui_fulltypename);
			this.battle_gui = (IBattleGui)oh.Unwrap ();
			this.game.Console = (IConsole)this.battle_gui;
			this.battle_gui.Init (this.game);
		}
		
		public void RunClient ()
		{
			this.battle_gui.Run ();
		}

		private IBattleGui battle_gui;
		private BattleEngine.Game game;
		private string battle_gui_assembly;
		private string battle_gui_typename;
		//private Type battle_gui_type;
		//private AssemblyAttributes battle_engine_attr;
		//private AssemblyAttributes battle_gui_attr;
		
		[STAThread]
		public static void Main (string[] args)
		{
			Program p = new Program (args);
			p.InitEngine ();
			p.InitClient ();
			p.RunClient ();
		}
	}
}

