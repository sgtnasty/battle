// 
//  Characteristic.cs
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
namespace Adeptus.Core
{
	public class Characteristic
	{
		public Characteristic (CharacteristicDescription description, int baseval)
		{
			this.description = description;
			this.baseValue = baseval;
			this.advancement = CharacteristicDescription.Advancement.None;
		}
		
		private CharacteristicDescription description;
		private CharacteristicDescription.Advancement advancement;
		private int baseValue;
		public CharacteristicDescription Description {
			get {
				return description;
			}
		}
		
		
		public int CurrentValue {
			get {
				if (this.advancement == CharacteristicDescription.Advancement.Simple)
					return this.baseValue + 5;
				else if (this.advancement == CharacteristicDescription.Advancement.Intermediate)
					return this.baseValue + 10;
				else if (this.advancement == CharacteristicDescription.Advancement.Trained)
					return this.baseValue + 15;
				else if (this.advancement == CharacteristicDescription.Advancement.Expert)
					return this.baseValue + 20;
				else
					return this.baseValue;
			}
		}
		
		
		public int BaseValue {
			get {
				return baseValue;
			}
		}
		
		
		public CharacteristicDescription.Advancement Advancement {
			get {
				return advancement;
			}
			set {
				advancement = value;
			}
		}
		
		
	}
}

