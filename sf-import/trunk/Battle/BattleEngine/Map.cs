// 
//  Map.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo.nascimento@va.gov>
//  
//  Copyright (c) 2011 U.S. Department of Veterans Affairs
// 
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleEngine
{
	public class Map
	{
		
		public Map ()
		{
			this.Length = 0;
			this.Height = 0;
			this.Width = 0;
		}
		
		public Map (int length, int width, int height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
			this.player_locations = new Dictionary<BattleEngine.Player.Player, Location>();
		}
		
		public int Length
		{
			get;
			private set;
		}
		public int Width
		{
			get;
			private set;
		}
		public int Height
		{
			get;
			private set;
		}		
		private Dictionary<BattleEngine.Player.Player,Location> player_locations;
		
		private void check_location_bounds (Location l)
		{
			if (l.X > this.Length)
				throw new ArgumentOutOfRangeException ("Max X is " + this.Length.ToString ());
			if (l.X < 0)
				throw new ArgumentOutOfRangeException ("X can not be less than 0");
			if (l.Y > this.Width)
				throw new ArgumentOutOfRangeException ("Max Y is " + this.Width.ToString ());
			if (l.Y < 0)
				throw new ArgumentOutOfRangeException ("Y can not be less than 0");
		}
		
		public void SetPlayerOnMap (BattleEngine.Player.Player p, Location l)
		{
			this.check_location_bounds (l);
			this.player_locations.Add (p, l);
		}
		
		public Location GetPlayerOnMap (BattleEngine.Player.Player p)
		{
			return this.player_locations[p];
		}
		
		public void ClearPlayers ()
		{
			this.player_locations.Clear ();
		}
		
		public void MovePlayerToTarget (BattleEngine.Player.Player p, double distance, BattleEngine.Player.Player t)
		{
			Location pl = this.player_locations[p];
			Location tl = this.player_locations[t];
			int dx = Convert.ToInt32(distance/2.0);
			int dy = Convert.ToInt32(distance) - dx;
			if (pl.X < tl.X)
				pl.X += Convert.ToInt32(dx);
			else
				pl.X -= Convert.ToInt32(dx);
			if (pl.Y < tl.Y)
				pl.Y += Convert.ToInt32(dy);
			else
				pl.Y -= Convert.ToInt32(dy);
		}
	}
}

