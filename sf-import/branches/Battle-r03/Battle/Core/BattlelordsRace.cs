//  
//  BattlelordsRace.cs
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
namespace Battle.Core
{
	public class BattlelordsRace
	{
		private string name;
		public string Name
		{
			get { return this.name; }
		}
		public BattlelordsRace (string name)
		{
			this.name = name;
		}
		public static BattlelordsRace LoadFromXml(System.Xml.XPath.XPathNavigator nav)
		{
			return new BattlelordsRace(nav.GetAttribute("name", ""));
		}
	}
}

