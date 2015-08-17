// 
//  Character.cs
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
	public class Character
	{
		public Character (AdeptusSession session, string name, string player)
		{
			this.session = session;
			this.name = name;
			this.player = player;
		}
		
		public void NewCharacteristic(CharacteristicDescription cd, int baseval)
		{
			if (cd.Abbreviation.Equals("WS"))
			    this.weaponSkill = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("BS"))
				this.ballisticSkill = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("S"))
				this.strength = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("T"))
				this.toughness = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("Ag"))
				this.agility = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("Int"))
				this.intelligence = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("Per"))
				this.perception = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("WP"))
				this.willPower = new Characteristic(cd, baseval);
			else if (cd.Abbreviation.Equals("Fel"))
				this.fellowship = new Characteristic(cd, baseval);
			else
				throw new Exception(string.Format("Unknown characteristic '{0}'", cd.Abbreviation));
		}
		
		#region Properties
		private AdeptusSession session;
		private string name;
		private string player;
		private Characteristic weaponSkill;
		private Characteristic ballisticSkill;
		private Characteristic strength;
		private Characteristic toughness;
		private Characteristic agility;
		private Characteristic intelligence;
		private Characteristic perception;
		private Characteristic willPower;
		private Characteristic fellowship;
		public string Player {
			get {
				return player;
			}
			set {
				player = value;
			}
		}
		
		
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
		public Characteristic WillPower {
			get {
				return willPower;
			}
		}
		
		
		public Characteristic WeaponSkill {
			get {
				return weaponSkill;
			}
		}
		
		
		public Characteristic Toughness {
			get {
				return toughness;
			}
		}
		
		
		public Characteristic Strength {
			get {
				return strength;
			}
		}
		
		
		public AdeptusSession Session {
			get {
				return session;
			}
		}
		
		
		public Characteristic Perception {
			get {
				return perception;
			}
		}
		
		
		public Characteristic Intelligence {
			get {
				return intelligence;
			}
		}
		
		
		public Characteristic Fellowship {
			get {
				return fellowship;
			}
		}
		
		
		public Characteristic BallisticSkill {
			get {
				return ballisticSkill;
			}
		}
		
		
		public Characteristic Agility {
			get {
				return agility;
			}
		}
		#endregion
	}
}

