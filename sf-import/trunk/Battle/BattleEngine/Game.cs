// 
//  Game.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo1@users.sf.net>
//  
//  Copyright (c) 2011 Ronaldo Nascimento
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
using System.Text;
using BattleEngine.Player;
using BattleEngine.Equipment;

namespace BattleEngine
{
	/// <summary>
	/// 
	/// </summary>
	public class Game
	{
		/// <summary>
		/// Constructs the Game engine
		/// </summary>
		public Game ()
		{
			this.RandomEngine = new Random (System.DateTime.Now.Millisecond);
			this.players = new Dictionary<string, BattleEngine.Player.Player>();
			this.GameMap = new Map (100, 100, 100);
		}
		
		/// <summary>
		/// Gets the random number generator unique throuought the game
		/// </summary>
		public Random RandomEngine
		{
			get;
			private set;
		}
		
		/// <summary>
		/// The one and only console for logging to GUI client
		/// </summary>
		public IConsole Console
		{
			get;
			set;
		}
		
		/// <summary>
		/// The one and only GUI client implementation
		/// </summary>
		public IBattleGui BattleGui
		{
			get;
			set;
		}
		
		public Map GameMap
		{
			get;
			private set;
		}
		
		private readonly Dictionary<string, BattleEngine.Player.Player> players;
		public Dictionary<string, BattleEngine.Player.Player> Players
		{
			get
			{
				return this.players;
			}
		}
		public void AddPlayer (BattleEngine.Player.Player player)
		{
			this.players.Add (player.Name, player);
			this.Console.ConsoleWriteLine (player.Summarize ());
		}
		public void RemovePlayer (BattleEngine.Player.Player player)
		{
			this.players.Remove (player.Name);
			this.Console.ConsoleWriteLine (player.Summarize () + " removed");
		}
		public int NumPlayers ()
		{
			return this.players.Count;
		}
		
		public void GuiLoaded ()
		{
			AssemblyAttributes gameaa = new AssemblyAttributes( this.GetType ());
			AssemblyAttributes guiaa = new AssemblyAttributes (this.BattleGui.GetType ());
			this.Console.ConsoleWriteLine (gameaa.TechDetails ());
			this.Console.ConsoleWriteLine (guiaa.TechDetails ());
		}
		
		private void roll_players_attributes (BattleEngine.Player.Player p)
		{
			int min_stat = 8;
            double total = 0.0;
            int rolls = 0;
			double seeking = (6.0 * (double)min_stat);
			while (total < seeking)
            {
                rolls++;
                total = (double) p.RollAttributes(this.RandomEngine);
            }
		}
		
		private void place_players_on_map ()
		{
			this.GameMap.ClearPlayers ();
			this.Console.ConsoleWriteLine ("Placing players on map...");
			foreach (BattleEngine.Player.Player p in this.players.Values)
			{
				Location l = new Location (this.RandomEngine.Next (1, this.GameMap.Length+1),
				                           this.RandomEngine.Next (1, this.GameMap.Width+1),
				                           0);
				this.GameMap.SetPlayerOnMap (p, l);
				this.Console.ConsoleWriteLine (string.Format("\"{0}\" is located at {1}", p.Name, l.ToString ()));
			}
		}
		
		public void RollAttributes()
		{
			this.Console.ConsoleWriteLine ("Determining stats randomly...");
			if (this.players.Count < 1)
				throw new Exception ("No players loaded into battle, add some players.");
			foreach (BattleEngine.Player.Player p in this.players.Values)
			{
				this.roll_players_attributes (p);
				p.Level = 1;
				this.Console.ConsoleWriteLine (p.Summarize ());
			}
			
			//this.place_players_on_map ();
		}
		
		private BattleEngine.Player.Player pick_target_by_shortest_distance (BattleEngine.Player.Player source)
		{
			List<BattleEngine.Player.Player> potential_targets = new List<BattleEngine.Player.Player>();
			foreach (BattleEngine.Player.Player p in this.players.Values)
			{
				if ((source != p) && (!p.IsDead()))
				    potential_targets.Add (p);
			}
			if (potential_targets.Count < 1)
				throw new Exception ("No potential targets!");
			Location myloc = this.GameMap.GetPlayerOnMap (source);
			Dictionary<BattleEngine.Player.Player, double> distances = new Dictionary<BattleEngine.Player.Player, double>();
			foreach (BattleEngine.Player.Player target in potential_targets)
			{
				Location tgtloc = this.GameMap.GetPlayerOnMap(target);
				distances.Add (target, myloc.DistanceTo (tgtloc));
			}
			double lowest_dist = (double)(this.GameMap.Length + this.GameMap.Width + this.GameMap.Height) * 2;
			BattleEngine.Player.Player target_player = null;
			foreach (KeyValuePair<BattleEngine.Player.Player, double> kvp in distances)
			{
				this.Console.ConsoleWriteLine (string.Format("\"{0}\" distance to \"{1}\" is {2}", source.Name, kvp.Key.Name, kvp.Value));
				if (kvp.Value < lowest_dist)
				{
					lowest_dist = kvp.Value;
					target_player = kvp.Key;
				}
			}
			return target_player;
		}
		
		public int PlayersLeftStanding ()
		{
			int left = 0;
			foreach (BattleEngine.Player.Player p in this.players.Values)
			{
				if (!p.IsDead())
					left ++;
			}
			return left;
		}
		
		private void attack (BattleEngine.Player.Player source, BattleEngine.Player.Player target)
		{
			string details = string.Format ("<u>Round {0}</u>: <i>{1}</i> is <b>attacking</b> <i>{2}</i>", 
			                                 this.round, source.Name, target.Name);
			this.BattleGui.ShowAttackDialog (details);
			Location sloc = this.GameMap.GetPlayerOnMap (source);
			Location tloc = this.GameMap.GetPlayerOnMap (target);
			double dist = sloc.DistanceTo (tloc);
			int range = source.GetAttribute ("Range").Current;
			if ((double)dist <= range)
			{
				int attackroll = source.ThrowForAttack ();
				int defenseroll = target.ThrowForDefense ();
				this.Console.ConsoleWrite (string.Format ("\t\"{0}\" attack rolls {1} at a distance of {2} with range {3}", 
				                                          source.Name, attackroll, dist, range));
				this.Console.ConsoleWrite (string.Format (" : \"{0}\" defense rolls {1}", target.Name, defenseroll));
				if (attackroll >= defenseroll)
				{
					this.Console.ConsoleWrite (" HIT");
					int power = source.RollDamage ();
					this.Console.ConsoleWrite (string.Format (" for {0} damage", power));
					int armor = target.GetAttribute("Armor").Current;
					int damage = armor - power;
					if (damage < 0)
					{
						target.TakeDamage (damage);
						this.Console.ConsoleWriteLine(string.Format(" \"{0}\" took {1} damage leaving {2} armor", 
						                                            target.Name, damage, target.GetAttribute("Armor").Current));
					}
					else
					{
						this.Console.ConsoleWriteLine(string.Format(" \"{0}\" took no damage \"{1}\" could not penetrate armor of {2}", 
						                                            target.Name, source.Name, target.GetAttribute ("Armor").Current));
					}					
				}
				else
				{
					this.Console.ConsoleWriteLine (" MISSED");
				}
			}
			else
			{
				this.Console.ConsoleWriteLine (string.Format ("\tOUT OF RANGE: \"{0}\" is {1} meters away from \"{2}\"", target.Name, dist, source.Name));
				int move = source.GetAttribute ("Speed").Current;				
				this.Console.ConsoleWriteLine (string.Format ("{0} closing {1} meters", source.Name, move));
				this.GameMap.MovePlayerToTarget (source, move, target);
			}
		}
		
		private int round;
		
		public void Battle ()
		{
			this.round = 0;
			if (this.players.Count < 2)
				throw new Exception ("Need at least 2 players to battle, add more players.");
			this.Console.ConsoleWriteLine ("==========================");
			this.Console.ConsoleWriteLine ("=   THE BATTLE BEGINS!   =");
			this.Console.ConsoleWriteLine ("==========================");
			// initial targetting
			
			this.place_players_on_map ();
			foreach (BattleEngine.Player.Player p in this.players.Values)
				p.Reset ();
			
			foreach (BattleEngine.Player.Player p in this.players.Values)
			{		
				p.Target = this.pick_target_by_shortest_distance (p);
				this.Console.ConsoleWriteLine (string.Format ("\"{0}\" targets \"{1}\"", p.Name, p.Target.Name));
			}
			
			BattleEngine.Player.Player winner = null;
			while (this.PlayersLeftStanding() > 1)
			{
				this.Console.ConsoleWriteLine ("");
				this.Console.ConsoleWriteLine ("ROUND " + this.round.ToString());
				this.BattleGui.DoEvents ();
				foreach (BattleEngine.Player.Player p in this.players.Values)
				{
					if (!p.IsDead())
					{
						if (!p.Target.IsDead())
						{
							this.attack (p, p.Target);
						}
						else if (this.PlayersLeftStanding () > 1)
						{
							p.Target = this.pick_target_by_shortest_distance (p);
						}
					}
				}
				// show current stats
				foreach (BattleEngine.Player.Player p in this.players.Values)
				{
					if (!p.IsDead())
						this.Console.ConsoleWriteLine (p.SummarizeHealth ());
				}
				this.round++;
				if (this.round > 1000)
				{
					this.Console.ConsoleWriteLine ("Battle has lasted too long");
					winner = null;
					break;
				}
			}
			foreach (BattleEngine.Player.Player p in this.players.Values)
			{
				if (!p.IsDead()) winner = p;
			}
			this.Console.ConsoleWriteLine ("==========================");
			this.Console.ConsoleWriteLine ("=    THE BATTLE ENDS!    =");
			this.Console.ConsoleWriteLine ("==========================");
			if (winner != null)
			{
				this.Console.ConsoleWriteLine (string.Format("\"{0}\" wins the battle in {1} rounds!", winner.Name, this.round));
				this.Console.ConsoleWriteLine (winner.Summarize ());
			}
			else
				this.Console.ConsoleWriteLine ("Its a draw");
		}
	}
}

