// 
//  BattleCharacter.cs
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
	public class PlayerCharacter
	{
		public PlayerCharacter ()
		{
			this.charisma = new Ability(Ability.AbilityType.CHARISMA, 0);
			this.logic = new Ability(Ability.AbilityType.LOGIC, 0);
			this.perception = new Ability(Ability.AbilityType.PERCEPTION, 0);
			this.power = new Ability(Ability.AbilityType.POWER, 0);
			this.speed = new Ability(Ability.AbilityType.SPEED, 0);
			this.stamina = new Ability(Ability.AbilityType.STAMINA, 0);
			this.strength = new Ability(Ability.AbilityType.STRENGTH, 0);
			this.willpower = new Ability(Ability.AbilityType.WILLPOWER, 0);
		}
		
		private Ability charisma;
		private Ability logic;
		private Ability perception;
		private Ability power;
		private Ability speed;
		private Ability stamina;
		private Ability strength;
		private Ability willpower;
	}
}

