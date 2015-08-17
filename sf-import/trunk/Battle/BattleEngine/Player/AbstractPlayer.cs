// 
//  AbstractPlayer.cs
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
namespace BattleEngine.Player
{
	public abstract class AbstractPlayer
	{
		public AbstractPlayer (string name)
		{
			this.Name = name;
			this.Gender = AbstractPlayer.GenderType.Unknown;
		}
		
		#region Core Attributes
		public string Name
		{
			get;
			protected set;
		}
		
		public int Age
		{
			get;
			set;
		}
		
		public enum GenderType
		{
			Unknown,
			Male,
			Female
		};
		
		public GenderType Gender
		{
			get;
			set;
		}
		
		public double Height
		{
			get;
			set;
		}
		
		public double Weight
		{
			get;
			set;
		}
		
		public int ExperiencePoints
		{
			get;
			protected set;
		}
		public void AddXP (int xp)
		{
			this.ExperiencePoints += xp;			
		}
		public int Level
		{
			get;
			set;
		}
		public abstract void Reset ();
		#endregion
	}
}

