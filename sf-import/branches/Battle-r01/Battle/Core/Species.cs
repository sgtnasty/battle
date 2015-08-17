// 
//  BattleSpecies.cs
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

namespace Battle.Core
{
	public class Species : Provider
	{
		public Species () : base()
		{
			this.modifiers = new List<Modifier>();
			this.sampleNames = new List<string>();
			this.homeWorlds = new List<HomeWorld>();
		}
		
		public Species(string name, string descr) : this()
		{
			this.name = name;
			this.description = descr;
		}
		
		private string name;
		private List<Modifier> modifiers;
		private string description;
		private List<string> sampleNames;
		private List<HomeWorld> homeWorlds;
		
		public string Description {
			get {
				return this.description;
			}
		}

		public List<HomeWorld> HomeWorlds {
			get {
				return this.homeWorlds;
			}
		}

		public List<Modifier> Modifiers {
			get {
				return this.modifiers;
			}
		}

		public string Name {
			get {
				return this.name;
			}
		}

		public List<string> SampleNames {
			get {
				return this.sampleNames;
			}
		}
		
		public void AddModifier(Modifier mod)
		{
			this.modifiers.Add(mod);
		}
	}
}

