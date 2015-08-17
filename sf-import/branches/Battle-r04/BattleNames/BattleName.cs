// 
//  BattleName.cs
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
using System.Text;

namespace BattleNames
{
	public class BattleName
	{
		private Random rand;
		
		public Random Rand
		{
			get { return this.rand; }
		}
		
		public BattleName (int seed)
		{
			this.rand = new Random (seed);
		}
		
		public BattleName (Random rand)
		{
			this.rand = rand;
		}		
		
		public enum NameType
		{
			Family,
			First
		}
		
		protected string from_pattern (NamePattern.Token[] pattern)
		{
			StringBuilder sb = new StringBuilder ();
			bool first = true;
			foreach (NamePattern.Token tk in pattern)
			{
				if (tk == NamePattern.Token.Consonant)
				{
					Consonant c = new Consonant (this.rand);
					if (first)
					{
						sb.Append (c.Val.ToUpper ());
						first = false;
					}
					else
						sb.Append (c.Val);
				}
				else
				{
					Vowel v = new Vowel (this.rand);
					sb.Append (v.Val);
				}
			}
			return sb.ToString ();
		}
		
		protected string generate_string (NameType t)
		{
			if (t == BattleName.NameType.First)
			{
				NamePattern p = new NamePattern(5, 8);
				NamePattern.Token[] tp = p.GenerateLogicalPattern (this.rand);
				return this.from_pattern (tp);
			}
			else
			{
				NamePattern p = new NamePattern(5, 13);
				NamePattern.Token[] tp = p.GenerateLogicalPattern (this.rand);
				return this.from_pattern (tp);
			}
		}
		
		public string GenerateName ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (this.generate_string (NameType.First));
			sb.Append (" ");
			sb.Append (this.generate_string (NameType.Family));
			return sb.ToString ();
		}
	}
}

