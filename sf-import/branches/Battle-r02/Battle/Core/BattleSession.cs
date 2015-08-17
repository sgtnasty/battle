// 
//  BattleSession.cs
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
	public class BattleSession
	{
		public BattleSession ()
		{
			this.coreAbilities = new List<AbilityDefinition>(8);
			this.coreAbilities.Add(AbilityDefinition.Charisma);
			this.coreAbilities.Add(AbilityDefinition.Logic);
			this.coreAbilities.Add(AbilityDefinition.Perception);
			this.coreAbilities.Add(AbilityDefinition.Power);
			this.coreAbilities.Add(AbilityDefinition.Speed);
			this.coreAbilities.Add(AbilityDefinition.Stamina);
			this.coreAbilities.Add(AbilityDefinition.Strength);
			this.coreAbilities.Add(AbilityDefinition.Willpower);
			
			try {
				this.origins = new List<OriginDefinition>();
				this.origins = Battle.Data.Storage.LoadOrigins("Data/origins.xml");
				this.species = new List<SpeciesDefinition>();
				this.species = Battle.Data.Storage.LoadSpecies("Data/species.xml");
				this.skills = new List<SkillDefinition>();
				this.skills = Battle.Data.Storage.LoadSkills("Data/skills.xml");
				this.powerSources = new List<PowerSource>();
				this.powerSources = Battle.Data.Storage.LoadPowerSources("Data/powersources.xml");
				this.powers = new List<PowerDefinition>();
				this.powers = Battle.Data.Storage.LoadPowers("Data/powers.xml");
			}
			catch (Exception exp)
			{
				Gtk.MessageDialog dlg = new Gtk.MessageDialog(null, Gtk.DialogFlags.Modal, Gtk.MessageType.Error,
				                                              Gtk.ButtonsType.Close, "{0}: {1}", 
				                                              exp.GetType().ToString(), exp.Message);
				dlg.Run();
			}
		}
		
		private List<AbilityDefinition> coreAbilities;
		private List<OriginDefinition> origins;
		private List<SpeciesDefinition> species;
		private List<SkillDefinition> skills;
		private List<PowerSource> powerSources;
		private List<PowerDefinition> powers;
		
		public AbilityDefinition[] CoreAbilities {
			get {
				return this.coreAbilities.ToArray();
			}
		}

		public OriginDefinition[] Origins {
			get {
				return this.origins.ToArray();
			}
		}
		
		public SpeciesDefinition[] Species
		{
			get { return this.species.ToArray(); }
		}
		
		public SkillDefinition[] Skills
		{
			get { return this.skills.ToArray(); }
		}
		
		public PowerSource[] PowerSources
		{
			get { return this.powerSources.ToArray(); }
		}
		
		public PowerDefinition[] Powers
		{
			get { return this.powers.ToArray(); }
		}
		
		public OriginDefinition FindOrigin(string identifier)
		{
			foreach (OriginDefinition d in this.origins)
			{
				if (d.Name.Equals(identifier)) 
				{
					return d;
				}
			}
			return null;
		}

		public void PrepCoreRules()
		{
			
		}
	}
}

