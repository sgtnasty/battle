// 
//  Consonant.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sourceforge.net>
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
namespace BattleNames
{
	public class Consonant
	{
		private static char[] consonants = {
			'b','c','d','f','g','h','j','k','l','m','n',
			'p','q','r','s','t','v','w','x','y','z'
		};
		
		private static string NewConsonant (Random rand)
		{
			int n = rand.Next (0, Consonant.consonants.Length);
			return Consonant.consonants[n].ToString ();
		}
		
		public string Val
		{
			get;
			private set;
		}
		
		public Consonant (Random rand)
		{
			this.Val = Consonant.NewConsonant (rand);
		}
	}
}

