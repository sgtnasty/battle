// 
//  AbstractEquipment.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo.nascimento@va.gov>
//  
//  Copyright (c) 2011 U.S. Department of Veterans Affairs
// 
using System;
namespace BattleEngine.Equipment
{
	public abstract class AbstractEquipment
	{
		public AbstractEquipment ()
		{
			this.Name = "Unknown Equipment";
		}
		
		public string Name
		{
			get;
			protected set;
		}
	}
}

