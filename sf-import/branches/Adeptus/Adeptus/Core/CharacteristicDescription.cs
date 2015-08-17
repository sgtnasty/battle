// 
//  Characteristic.cs
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
namespace Adeptus.Core
{
	public class CharacteristicDescription
	{
		
		public enum Advancement
		{
			None,
			Simple,
			Intermediate,
			Trained,
			Expert
		}
		
		public CharacteristicDescription (string name, string abbrev)
		{
			this.name = name;
			this.abbreviation = abbrev;
		}
		
		#region Properties
		private string name;
		private string abbreviation;
		public string Name {
			get {
				return name;
			}
		}
		
		
		public string Abbreviation {
			get {
				return abbreviation;
			}
		}
		#endregion
	}
}

