// 
//  Storage.cs
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
using System.Xml;
using System.Xml.XPath;
using Battle.Core;
	
namespace Battle.Data
{
	public class Storage
	{
		private Storage ()
		{
		}
		
		#region Data Loading
		public static List<OriginDefinition> LoadOrigins(string xmlfile)
		{
			List<OriginDefinition> origins = new List<OriginDefinition>();
			XPathDocument doc = new XPathDocument(xmlfile);
			XPathNavigator nav = doc.CreateNavigator();
			
			foreach (XPathNavigator n in nav.Select("/battle/origins/origin"))
			{
				string name = n.GetAttribute("name", "");
				string descr = n.GetAttribute("description", "");
				OriginDefinition d =new OriginDefinition();
				d.Name = name;
				d.Description = descr;
				foreach (XPathNavigator n2 in n.Select("provides"))
				{
					d.Provide(n2.GetAttribute("value", ""));
				}
				foreach (XPathNavigator n3 in n.Select("requires"))
				{
					d.Require(n3.GetAttribute("value", ""));
				}
				origins.Add(d);
			}			
			return origins;
		}
		public static List<SpeciesDefinition> LoadSpecies(string xmlfile)
		{
			List<SpeciesDefinition> species = new List<SpeciesDefinition>();
			XPathDocument doc = new XPathDocument(xmlfile);
			XPathNavigator nav = doc.CreateNavigator();
			
			foreach (XPathNavigator n in nav.Select("/battle/speciess/species"))
			{
				string name = n.GetAttribute("name", "");
				string descr = n.GetAttribute("description", "");
				SpeciesDefinition d = new SpeciesDefinition();
				d.Name = name;
				d.Description = descr;
				/*
				foreach (XPathNavigator n1 in n.Select("origin"))
				{
					string oriname = n.GetAttribute("name", "");
					
					//d.AddOrigin(n.GetAttribute("name",""));
				}
				*/
				foreach (XPathNavigator n2 in n.Select("provides"))
				{
					d.Provide(n2.GetAttribute("value", ""));
				}
				foreach (XPathNavigator n3 in n.Select("requires"))
				{
					d.Require(n3.GetAttribute("value", ""));
				}
				foreach (XPathNavigator n4 in n.Select("modifier"))
				{
					string modname = n4.GetAttribute("name", "");
					string description = n4.GetAttribute("description", "");
					string val = n4.GetAttribute("value", "");
					string target = n4.GetAttribute("target", "");
					string type = n4.GetAttribute("type", "");
					ModifierDefinition mod = new ModifierDefinition();
					mod.Name = modname;
					mod.Description = description;
					mod.ModValue = double.Parse(val);
					mod.EntityType = BattleEntity.ParseEntity(type);
					mod.TargetName = target;
					d.AddModifier(mod);					
				}
				species.Add(d);
			}
			
			return species;
		}
		public static List<SkillDefinition> LoadSkills(string xmlfile)
		{
			List<SkillDefinition> skills = new List<SkillDefinition>();
			XPathDocument doc = new XPathDocument(xmlfile);
			XPathNavigator nav = doc.CreateNavigator();
			
			foreach (XPathNavigator n in nav.Select("/battle/skills/skill"))
			{
				string name = n.GetAttribute("name", "");
				string descr = n.GetAttribute("description", "");
				string cost = n.GetAttribute("cost","");
				string baseattr = n.GetAttribute("base", "");
				SkillDefinition skill = new SkillDefinition();
				skill.Name = name;
				skill.Description = descr;
				skill.BaseAbility = AbilityDefinition.ParseAbility(baseattr);
				skill.Expcost = int.Parse(cost);
				foreach (XPathNavigator n2 in n.Select("provides"))
				{
					skill.Provide(n2.GetAttribute("value", ""));
				}
				foreach (XPathNavigator n3 in n.Select("requires"))
				{
					skill.Require(n3.GetAttribute("value", ""));
				}
				skills.Add(skill);
			}
			
			return skills;
		}
		public static List<PowerSource> LoadPowerSources(string xmlfile)
		{
			List<PowerSource> powerSources = new List<PowerSource>();
			XPathDocument doc = new XPathDocument(xmlfile);
			XPathNavigator nav = doc.CreateNavigator();
			
			foreach (XPathNavigator n in nav.Select("/battle/powersources/powersource"))
			{
				PowerSource p = new PowerSource();
				string name = n.GetAttribute("name", "");
				string descr = n.GetAttribute("description", "");
				p.Name = name;
				p.Description = descr;
				foreach (XPathNavigator n2 in n.Select("provides"))
				{
					p.Provide(n2.GetAttribute("value", ""));
				}
				foreach (XPathNavigator n3 in n.Select("requires"))
				{
					p.Require(n3.GetAttribute("value", ""));
				}
				powerSources.Add(p);
			}
			return powerSources;
		}
		public static List<PowerDefinition> LoadPowers(string xmlfile)
		{
			List<PowerDefinition> powers = new List<PowerDefinition>();
			XPathDocument doc = new XPathDocument(xmlfile);
			XPathNavigator nav = doc.CreateNavigator();
			
			foreach (XPathNavigator n in nav.Select("/battle/powers/power"))
			{
				PowerDefinition p = new PowerDefinition();
				string name = n.GetAttribute("name", "");
				string descr = n.GetAttribute("description", "");
				p.Name = name;
				p.Description = descr;
				foreach (XPathNavigator n2 in n.Select("provides"))
				{
					p.Provide(n2.GetAttribute("value", ""));
				}
				foreach (XPathNavigator n3 in n.Select("requires"))
				{
					p.Require(n3.GetAttribute("value", ""));
				}
				powers.Add(p);
			}
			return powers;			
		}
		#endregion
		
		#region Data Storing
		#endregion
	}
}

