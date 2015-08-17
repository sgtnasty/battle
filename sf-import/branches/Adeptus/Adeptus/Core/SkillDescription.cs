// 
//  Skill.cs
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
	public class SkillDescription
	{
		
		public enum Category
		{
			Basic,
			Advanced
		}
		
		public enum Advancement
		{
			None,
			Trained,
			Master1,
			Master2,
			Master3,
			Master4
		}
		
		public SkillDescription (string name, Category cat, CharacteristicDescription charac, List<string> descr, bool isgrp)
		{
			this.name = name;
			this.category = cat;
			this.characteristic = charac;
			this.descriptors = descr;
			this.isGroup = isgrp;
		}
		
		#region Properties
		private string name;
		private Category category;
		private CharacteristicDescription characteristic;
		private List<string> descriptors;
		private bool isGroup;
		#endregion
	}
}

