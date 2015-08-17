//  
//  Program.cs
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

namespace Battle
{
	public class Program
	{
		public static void Main (string[] args)
		{
			Battle.Core.BattlelordsSession session = new Battle.Core.BattlelordsSession();
			Console.WriteLine(string.Format("{0} started @ {1}",
			                                session.GetType().ToString(),
			                                session.StartTime.ToString()));
			session.Run();
		}
	}
}

