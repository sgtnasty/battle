// 
//  HomeWorld.cs
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
	public class HomeWorld : Provider
	{
		public HomeWorld () : base()
		{
			this.modifiers = new List<Modifier>();
		}
		
		public HomeWorld(string name, string loc) : this()
		{
			this.name = name;
			this.location = loc;			
		}
		private string name;
		private string location;
		private List<Modifier> modifiers;	

		public string Location {
			get {
				return this.location;
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
	}
}

