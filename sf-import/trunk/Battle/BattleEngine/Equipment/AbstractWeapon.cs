// 
//  AbstractWeapon.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo.nascimento@va.gov>
//  
//  Copyright (c) 2011 U.S. Department of Veterans Affairs
// 
using System;
namespace BattleEngine.Equipment
{
	public abstract class AbstractWeapon : AbstractEquipment
	{
		public AbstractWeapon ()
			: base()
		{
			this.Name = "Unknown Weapon";
		}
		
		public enum WeaponWeight
		{
			Light,
			Medium,
			Heavy
		}
		
		public enum WeaponHandedness
		{
			OneHanded,
			TwoHanded
		}
		
		public enum WeaponType
		{
			Natural,
			Melee,
			Thrown,
			Missile
		}
		
		public WeaponWeight Weight
		{
			get;
			protected set;
		}
		
		public WeaponHandedness Handedness
		{
			get;
			protected set;
		}
		
		public WeaponType Type
		{
			get;
			protected set;
		}
		
		public string WeaponClass ()
		{
			return this.Weight.ToString () + this.Handedness.ToString () + this.Type.ToString ();
		}
		
		public int Range
		{
			get;
			protected set;
		}
		
		public int DamageDice
		{
			get;
			protected set;
		}
		public int Penetration
		{
			get;
			protected set;
		}
	}
}

