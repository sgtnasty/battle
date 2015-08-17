//  
//  DataManager.cs
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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using Battle.Core;

namespace Battle.Data
{
	public class DataManager
	{
		public static BattlelordsRace[] LoadRaces(string filename)
		{
			List<BattlelordsRace> races = new List<BattlelordsRace>();
			XPathDocument doc = new XPathDocument(DataManager.GetDataFile("races.xml"));
			XPathNavigator nav = doc.CreateNavigator();
			nav.MoveToChild("battlelords", "");
			nav.MoveToChild("races", "");
			nav.MoveToChild("race", "");
			races.Add(BattlelordsRace.LoadFromXml(nav));
			while (nav.MoveToNext())
			{
				races.Add(BattlelordsRace.LoadFromXml(nav));
			}
			return races.ToArray();
		}
		
		public static string GetDataFile(string basefile)
		{
			string fullpath = string.Format("{0}{1}Data{2}{3}",
			                                System.Environment.CurrentDirectory,
			                                System.IO.Path.DirectorySeparatorChar,
			                                System.IO.Path.DirectorySeparatorChar,
			                                basefile);
			Console.WriteLine(fullpath);
			return fullpath;
		}
	}
}

