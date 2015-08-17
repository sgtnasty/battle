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

using Gtk;

namespace Battle.Core
{
	public class BattleSession
	{
		public BattleSession ()
		{
			this.players = new List<PlayerCharacter>();
			this.homeWorlds = new List<HomeWorld>();
			this.powers = new List<Power>();
			this.skills = new List<Skill>();
			this.species = new List<Species>();
			this.baselineRulesSetup();
		}
		
		#region Base Rules
		private void baselineRulesSetup()
		{
			this.setupHomeWorlds();
			this.setupSpecies();
			this.setupSkills();
			this.setupPowers();
		}
		private void setupHomeWorlds()
		{
			HomeWorld w = new HomeWorld("Terra", "Sol System");
			w.AddProvider("homeworld");
			this.homeWorlds.Add(w);
		}
		private void setupPowers()
		{
			Power p = new Power("Psionics", "Mental powers beyond imagination.");
			p.AddProvider("psionics");
			p.AddRequirement("sentient");
		}
		private void setupSkills()
		{
			Skill s = new Skill("Armed Combat", Ability.AbilityType.STRENGTH, "");
			s.AddRequirement("sentient");
			s.AddProvider("combat");
			this.skills.Add(s);
		}
		private void setupSpecies()
		{
			Species human = new Species("Human", "Homo-sapien");
			human.AddProvider("sentient");
			human.AddModifier(new Modifier(Modifier.ModType.ABILITY, Ability.AbilityType.LOGIC.ToString(), "Resourcefull", 1.0));
			this.species.Add(human);
			
			Species cephalopod = new Species("Cephalopod", "Sentient octopuses.");
			cephalopod.AddProvider("sentient");
			cephalopod.AddProvider("ambidextrous");
			cephalopod.AddModifier(new Modifier(Modifier.ModType.ABILITY, Ability.AbilityType.SPEED.ToString(), "Quickness", 1.0));
			this.species.Add(cephalopod);
			
			Species ursoid = new Species("Ursoid", "Sentient upright bears.");
			ursoid.AddProvider("sentient");
			ursoid.AddModifier(new Modifier(Modifier.ModType.ABILITY, Ability.AbilityType.STRENGTH.ToString(), "Strength", 1.0));
			this.species.Add(ursoid);
			
			Species reptiles = new Species("Reptile", "Sentient upgright lizards");
			reptiles.AddProvider("sentient");
			reptiles.AddProvider("naturalarmor");
			reptiles.AddModifier(new Modifier(Modifier.ModType.ABILITY, Ability.AbilityType.STAMINA.ToString(), "Stamina", 1.0));
			this.species.Add(reptiles);
			
			Species canine = new Species("Canine", "Sentient upgright dogs");
			canine.AddProvider("sentient");
			canine.AddProvider("prehensiletail");
			canine.AddModifier(new Modifier(Modifier.ModType.ABILITY, Ability.AbilityType.PERCEPTION.ToString(), "Perception", 1.0));
			this.species.Add(canine);
			
		}
		#endregion
		
		#region Properties
		private DateTime started;
		private DateTime stopped;
		private Battle.Gui.MainWindow window;
		
		private List<PlayerCharacter> players;
		private List<HomeWorld> homeWorlds;
		private List<Power> powers;
		private List<Species> species;
		private List<Skill> skills;
		
		public DateTime Started {
			get {
				return this.started;
			}
		}

		public DateTime Stopped {
			get {
				return this.stopped;
			}
		}

		public Gui.MainWindow Window {
			get {
				return this.window;
			}
		}
		#endregion

		#region Session Methods
		public void Start()
		{
			this.started = DateTime.Now;
			Gtk.Application.Init();
			this.window = new Battle.Gui.MainWindow(this);
			this.window.ShowAll();
			this.window.UpdateStatus(0, this.GetType().ToString());
			Gtk.Application.Run();
		}
		
		public void Stop()
		{
			this.stopped = DateTime.Now;
			Gtk.Application.Quit();
		}
		#endregion
	}
}

