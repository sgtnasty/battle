// 
//  NamePattern.cs
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
using System.Collections.Generic;
using System.Text;

namespace BattleNames
{
	public class NamePattern
	{
		public enum Token
		{
			Consonant,
			Vowel
		}
		
		private double startVowelPct = 0.33;
		private double nextVowelFromVowel = 0.9;
		private double nextVowelFromConsonant = 0.1;
		private int minLen;
		private int maxLen;
		
		public NamePattern (int min, int max)
		{
			this.minLen = min;
			this.maxLen = max;
		}
		
		private Token WhatsNext (Token prev, Random rand)
		{
			if (prev == NamePattern.Token.Consonant)
			{
				if (rand.NextDouble () > this.nextVowelFromConsonant)
					return Token.Vowel;
				else
					return Token.Consonant;
			}
			else
			{
				if (rand.NextDouble () > this.nextVowelFromVowel)
					return Token.Vowel;
				else
					return Token.Consonant;
			}
		}
		
		public Token[] GenerateLogicalPattern (Random rand)
		{
			List<Token> pattern = new List<Token> ();
			int length = rand.Next (this.minLen, this.maxLen);
			if (length < this.minLen) length = this.minLen;
			if (rand.NextDouble() > this.startVowelPct)
				pattern.Add (Token.Consonant);
			else
				pattern.Add (Token.Vowel);
			for (int i=1; i < length; i++)
			{
				pattern.Add (this.WhatsNext (pattern[i-1], rand));
			}
			return pattern.ToArray ();
		}
	}
}

