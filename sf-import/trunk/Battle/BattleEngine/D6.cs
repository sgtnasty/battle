// 
//  D6.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sf.net>
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
namespace BattleEngine
{
	public class D6 : AbstractDie
	{
		public D6 (Random rand)
			: base (rand)
		{
			this.Min = 1;
			this.Max = 6;
		}
		
		//http://rpg.stackexchange.com/questions/2654/3d6-vs-a-d20-what-is-the-effect-of-a-different-probability-curve
		
		
		public override int Throw ()
		{
			this.lastthrow = this.random.Next(this.Min, this.Max + 1);
			return this.lastthrow;
		}
		public override string ToString ()
		{
			return string.Format ("[D6 {0}]", this.lastthrow);
		}
	}
}

