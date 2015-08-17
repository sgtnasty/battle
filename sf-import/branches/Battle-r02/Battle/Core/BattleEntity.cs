// 
//  BattleEntity.cs
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
	public abstract class BattleEntity
	{
		public BattleEntity ()
		{
			this._type = BattleEntity.Type.UNKNOWN;
			this.provisions = new List<string>();
			this.requirements = new List<string>();
		}
		
		#region IProvider implementation
		protected List<string> provisions;
		protected List<string> requirements;
		public void Provide (string provision)
		{
			this.provisions.Add(provision);
		}

		public void Require (string requirement)
		{
			this.requirements.Add(requirement);
		}

		public string[] Provides ()
		{
			return this.provisions.ToArray();
		}

		public string[] Requires ()
		{
			return this.requirements.ToArray();
		}

		public bool DoesProvide (string provision)
		{
			return this.provisions.Contains(provision);
		}

		public bool DoesRequire (string requirement)
		{
			return this.requirements.Contains(requirement);
		}
		#endregion

		public enum Type
		{
			UNKNOWN,
			ORIGIN,
			SPECIES,
			ABILITY,
			MODIFIER,
			SKILL,
			POWERSOURCE,
			POWER,
			EQUIPMENT
		}
		protected Type _type;
		public Type EntityType
		{
			get { return this._type; }
			set { this._type = value; }
		}
		protected string name;
		protected string description;
	

		public string Description {
			get {
				return this.description;
			}
			set {
				description = value;
			}
		}

		public string Name {
			get {
				return this.name;
			}
			set {
				name = value;
			}
		}
		
		public static BattleEntity.Type ParseEntity(string obj)
		{
			if (obj == null) return Type.UNKNOWN;
			
			if (obj.ToUpper().Equals(Type.ABILITY.ToString())) return Type.ABILITY;
			else if (obj.ToUpper().Equals(Type.EQUIPMENT.ToString())) return Type.EQUIPMENT;
			else if (obj.ToUpper().Equals(Type.MODIFIER.ToString())) return Type.MODIFIER;
			else if (obj.ToUpper().Equals(Type.ORIGIN.ToString())) return Type.ORIGIN;
			else if (obj.ToUpper().Equals(Type.POWER.ToString())) return Type.POWER;
			else if (obj.ToUpper().Equals(Type.SKILL.ToString())) return Type.SKILL;
			else if (obj.ToUpper().Equals(Type.SPECIES.ToString())) return Type.SPECIES;
			else 
				return Type.UNKNOWN;
		}
	}
}

