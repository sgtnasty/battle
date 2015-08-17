// 
//  AbstractArmor.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo.nascimento@va.gov>
//  
//  Copyright (c) 2011 U.S. Department of Veterans Affairs
// 
using System;
namespace BattleEngine.Equipment
{
	public abstract class AbstractArmor : AbstractEquipment
	{
		public AbstractArmor ()
			: base ()
		{
			this.Name = "Unknown Armor";
		}
		
		public enum ArmorWeight
		{
			Light,
			Medium,
			Heavy
		}
		
		public enum ArmorTech
		{
			Archaic,
			Modern,
			Advanced,
			Future
		}
		
		public enum ArmorCoverage
		{
			Helmet,			
			Gloves,
			Arms,
			Pants,
			Shirt,
			Boots
		}
		
		public int Protection
		{
			get;
			protected set;
		}
	}
}

