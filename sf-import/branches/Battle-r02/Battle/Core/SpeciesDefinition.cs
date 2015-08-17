// 
//  Species.cs
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
	public class SpeciesDefinition : BattleEntity
	{
		public SpeciesDefinition () : base()
		{
			this._type = BattleEntity.Type.SPECIES;
			this.Provide("species");
			this.modifiers = new List<ModifierDefinition>();
			this.origins = new List<OriginDefinition>();
		}
		
		private List<ModifierDefinition> modifiers;
		private List<OriginDefinition> origins;
		
		public OriginDefinition[] Origins
		{
			get { return this.origins.ToArray(); }
		}
		
		public ModifierDefinition[] Modifiers {
			get { return this.modifiers.ToArray(); }
		}

		public void AddModifier(ModifierDefinition def)
		{
			this.modifiers.Add(def);
		}
		
		public void AddOrigin(OriginDefinition ori)
		{
			this.origins.Add(ori);
		}		
	}
}

