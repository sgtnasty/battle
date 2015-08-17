// 
//  Player.cs
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
using System.Xml.XPath;

namespace BattleEngine.Player
{
	public class Player : AbstractPlayer
	{
		public Player (string name)
			:base (name)
		{
            this.attributes = new Dictionary<string, PlayerAttribute>();
            this.attributes.Add("Attack", new PlayerAttribute("Attack"));
            this.attributes.Add("Defense", new PlayerAttribute("Defense"));
            this.attributes.Add("Armor", new PlayerAttribute("Armor"));
            this.attributes.Add("Power", new PlayerAttribute("Power"));
            this.attributes.Add("Speed", new PlayerAttribute("Speed"));
            this.attributes.Add("Range", new PlayerAttribute("Range"));			
			this.Target = null;
		}
		
        private Dictionary<string, PlayerAttribute> attributes;
        public PlayerAttribute GetAttribute(string name)
        {
            return this.attributes[name];
        }
		
        public int RollAttributes(Random r)
        {
            int total = 0;
            foreach (PlayerAttribute attr in this.attributes.Values)
            {
                total += attr.Randomize(r);
            }
            return total;
        }

        public string GetRollDescription()
        {
            StringBuilder b = new StringBuilder();
            b.AppendFormat("{0}", this.Name);
            b.AppendLine();
            foreach (PlayerAttribute attr in this.attributes.Values)
            {
                b.AppendLine("\t" + attr.GetRollDescription());
            }
            return b.ToString();
        }
		
		public string AttributesToString ()
		{
			StringBuilder s = new StringBuilder ();
			s.AppendLine ("[Attributes:");
			foreach (PlayerAttribute a in this.attributes.Values)
			{
				s.AppendLine (a.ToString ());
			}
			s.AppendLine ("]");
			return s.ToString ();
		}
		
		public override string ToString ()
		{
			return string.Format ("[Player: Name=\"{0}\" Level={1} {2}]", this.Name, this.Level, this.AttributesToString ());
		}
		
		public Player Target
		{
			get;
			set;
		}
		
		public bool IsDead ()
		{
			return (this.attributes["Armor"].Current < 1);
		}
		
		public int ThrowForAttack ()
		{
			int roll = this.GetAttribute("Attack").Die1.Throw() +
				this.GetAttribute("Attack").Die2.Throw() +
				this.GetAttribute("Attack").Die3.Throw();
			return roll + this.GetAttribute("Attack").Bonus + this.Level;
		}
		
		public int ThrowForDefense ()
		{
			int roll = this.GetAttribute("Defense").Die1.Throw() +
				this.GetAttribute("Defense").Die2.Throw() +
				this.GetAttribute("Defense").Die3.Throw();
			return roll + this.GetAttribute ("Defense").Bonus + this.Level;
		}
		
		public int RollDamage ()
		{
			int roll = this.GetAttribute ("Power").Die1.Throw () + 
				this.GetAttribute ("Power").Die2.Throw () + 
				this.GetAttribute ("Power").Die3.Throw ();
			return roll + this.GetAttribute ("Power").Bonus + this.Level;
		}
		
		public void TakeDamage (int damage)
		{
			this.GetAttribute("Armor").Current += damage;
		}
		
		public string Summarize ()
		{
			StringBuilder b = new StringBuilder ();
			b.AppendFormat ("\"{0}\" Level={1} Attributes=[", this.Name, this.Level);
			foreach (PlayerAttribute a in this.attributes.Values)
			{
				b.AppendFormat("{0} ", a.Summarize ());
			}
			b.Append("]");
			return b.ToString();
		}
		
		public string SummarizeHealth ()
		{
			return string.Format("\"{0}\" Armor={1}", this.Name, this.GetAttribute ("Armor").Current);
		}
		
		public override void Reset ()
		{
			foreach (PlayerAttribute a in this.attributes.Values)
			{
				a.Current = a.Base;
			}
			this.Target = null;
		}
		
		public static Player ReadFromXml (XPathNavigator nav)
		{
			throw new NotImplementedException ();
		}
	}
}

