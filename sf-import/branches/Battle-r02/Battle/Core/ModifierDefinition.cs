// 
//  Modifier.cs
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
	public class ModifierDefinition : BattleEntity
	{
		public ModifierDefinition ()
		{
			this._type = BattleEntity.Type.MODIFIER;
			this.Provide("modifier");
		}
		
		private double modValue;
		
		public double ModValue {
			get {
				return this.modValue;
			}
			set {
				modValue = value;
			}
		}
		
		private string targetName;
		public string TargetName {
			get {
				return this.targetName;
			}
			set {
				targetName = value;
			}
		}

		private BattleEntity target;
		public BattleEntity Target {
			get {
				return this.target;
			}
			set {
				this.target = value;
			}
		}
	}
}

