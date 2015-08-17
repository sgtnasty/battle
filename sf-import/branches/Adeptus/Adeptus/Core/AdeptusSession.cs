// 
//  AdeptusSession.cs
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

namespace Adeptus.Core
{
	public class AdeptusSession
	{
		public AdeptusSession ()
		{
			this.characters = new List<Character>();
			this.weaponSkill = new CharacteristicDescription("Weapon Skill", "WS");
			this.ballisticSkill = new CharacteristicDescription("Ballistic Skill", "BS");
			this.strength = new CharacteristicDescription("Strength", "S");
			this.toughness = new CharacteristicDescription("Toughness", "T");
			this.agility = new CharacteristicDescription("Agility", "Ag");
			this.intelligence = new CharacteristicDescription("Intelligence", "Int");
			this.perception = new CharacteristicDescription("Perception", "Per");
			this.willPower = new CharacteristicDescription("Will Power", "WP");
			this.fellowship = new CharacteristicDescription("Fellowship", "Fel");
			this.skills = new List<SkillDescription>(45);
		}
		
		private List<Character> characters;
		private CharacteristicDescription weaponSkill;
		private CharacteristicDescription ballisticSkill;
		private CharacteristicDescription strength;
		private CharacteristicDescription toughness;
		private CharacteristicDescription agility;
		private CharacteristicDescription intelligence;
		private CharacteristicDescription perception;
		private CharacteristicDescription willPower;
		private CharacteristicDescription fellowship;
		private List<SkillDescription> skills;
	}
}

