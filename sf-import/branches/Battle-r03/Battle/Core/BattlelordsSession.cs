//  
//  BattlelordsSession.cs
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
using System.Collections;
using System.Collections.Generic;
using Gtk;
using Battle.Gui;

namespace Battle.Core
{
	/// <summary>
	/// This is the controller/model of the wole application.
	/// </summary>
	public class BattlelordsSession
	{
		private DateTime start;
		public DateTime StartTime
		{
			get { return this.start; }
		}
		private BattlelordsRace[] races;
		public BattlelordsRace[] Races
		{
			get { return this.races; }
		}
		public BattlelordsSession ()
		{
			this.start = DateTime.Now;
		}
		private void LoadData()
		{
			this.races = Battle.Data.DataManager.LoadRaces("races.xml");
		}
		public void 	Run()
		{
			Application.Init ();
			this.LoadData();
			MainWindow win = new MainWindow (this);
			win.ShowAll ();
			Application.Run ();
		}
	}
}

