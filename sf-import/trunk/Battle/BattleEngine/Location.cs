// 
//  Location.cs
//  
//  Author:
//       Ronaldo Nascimento <ronaldo.nascimento@va.gov>
//  
//  Copyright (c) 2011 U.S. Department of Veterans Affairs
// 
using System;
namespace BattleEngine
{
	public class Location
	{
		
		public Location ()
		{
			this.X = 0;
			this.Y = 0;
			this.Z = 0;
		}
		
		public double DistanceTo (Location point)
		{
			return Math.Sqrt (Math.Pow((this.X - point.X), 2.0) + Math.Pow ((this.Y - point.Y), 2.0));
		}
		
		public Location (int x, int y, int z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}
		
		public int X
		{
			get;
			set;
		}
		
		public int Y
		{
			get;
			set;
		}
		
		public int Z
		{
			get;
			set;
		}
		
		public override string ToString ()
		{
			return string.Format ("[Location: X={0}, Y={1}, Z={2}]", X, Y, Z);
		}
	}
}

