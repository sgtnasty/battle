// 
//  Skill.cs
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
	public class SkillDefinition : BattleEntity
	{
		public SkillDefinition () : base()
		{
			this._type = BattleEntity.Type.SKILL;
			this.Provide("skill");
		}
		
		private int expcost;
		private AbilityDefinition.AbilityName baseAbility;
				
		public AbilityDefinition.AbilityName BaseAbility {
			get {
				return this.baseAbility;
			}
			set {
				baseAbility = value;
			}
		}

		public int Expcost {
			get {
				return this.expcost;
			}
			set {
				expcost = value;
			}
		}
	}
}

