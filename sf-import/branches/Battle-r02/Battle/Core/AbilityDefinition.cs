// 
//  Ability.cs
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
	public class AbilityDefinition : BattleEntity
	{
		public AbilityDefinition () : base()
		{
			this._type = BattleEntity.Type.ABILITY;
			this.Provide("ability");
		}
		
		public AbilityDefinition(AbilityName ability, string description, string[] provides, string[] requires) : this()
		{
			this.aname = ability;
			this.name = ability.ToString().ToUpperInvariant();
			this.description = description;
			if (provides != null)
			{
				foreach (string provide in provides)
				{
					this.Provide(provide);
				}
			}
			if (requires != null)
			{
				foreach (string require in requires)
				{
					this.Provide(require);
				}
			}
		}
		
		public enum AbilityName
		{
			UNKNOWN,
			CHARISMA,
			LOGIC,
			PERCEPTION,
			POWER,
			SPEED,
			STAMINA,
			STRENGTH,
			WILLPOWER
		}
		
		public static AbilityName ParseAbility(string obj)
		{
			if (obj == null) return AbilityName.UNKNOWN;
			if (obj.ToUpper().Equals(AbilityName.CHARISMA.ToString())) return AbilityName.CHARISMA;
			else if (obj.ToUpper().Equals(AbilityName.LOGIC.ToString())) return AbilityName.LOGIC;
			else if (obj.ToUpper().Equals(AbilityName.PERCEPTION.ToString())) return AbilityName.PERCEPTION;
			else if (obj.ToUpper().Equals(AbilityName.POWER.ToString())) return AbilityName.POWER;
			else if (obj.ToUpper().Equals(AbilityName.SPEED.ToString())) return AbilityName.SPEED;
			else if (obj.ToUpper().Equals(AbilityName.STAMINA.ToString())) return AbilityName.STAMINA;
			else if (obj.ToUpper().Equals(AbilityName.STRENGTH.ToString())) return AbilityName.STRENGTH;
			else if (obj.ToUpper().Equals(AbilityName.WILLPOWER.ToString())) return AbilityName.WILLPOWER;
			else 
				return AbilityName.UNKNOWN;
		}
		
		private AbilityName aname;
		public AbilityName AbilityIdentifier
		{
			get { return this.aname; }
			set { this.aname = value; }
		}
		
		public static AbilityDefinition Charisma = new AbilityDefinition(AbilityName.CHARISMA, "", null, null);
		public static AbilityDefinition Logic = new AbilityDefinition(AbilityName.LOGIC, "", null, null);
		public static AbilityDefinition Perception = new AbilityDefinition(AbilityName.PERCEPTION, "", null, null);
		public static AbilityDefinition Power = new AbilityDefinition(AbilityName.POWER, "", null, null);
		public static AbilityDefinition Speed = new AbilityDefinition(AbilityName.SPEED, "", null, null);
		public static AbilityDefinition Stamina = new AbilityDefinition(AbilityName.STAMINA, "", null, null);
		public static AbilityDefinition Strength = new AbilityDefinition(AbilityName.STRENGTH, "", null, null);
		public static AbilityDefinition Willpower = new AbilityDefinition(AbilityName.WILLPOWER, "", null, null);

	}
}

