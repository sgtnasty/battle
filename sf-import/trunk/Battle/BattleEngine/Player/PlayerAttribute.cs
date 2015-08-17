// 
//  PlayerAttribute.cs
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
using System.Text;
using System.Xml.XPath;

namespace BattleEngine.Player
{
	public class PlayerAttribute
	{
		
		public PlayerAttribute (string name)
            :this(name, 0, 0)
		{
		}
		
		public PlayerAttribute (string name, int baseval)
            : this(name, baseval, baseval)
		{
		}
		
		public PlayerAttribute (string name, int baseval, int curval)
		{
			this.Name = name;
			this.Base = baseval;
			this.Current = curval;
		}
		
		public string Name
        {
            get;
            set;
        }
        public int Base
        {
            get;
            set;
        }
        public int Current
        {
            get;
            set;
        }

        public int Bonus
        {
            get
            {
                // 3  4  5  6  7  8 9 10 11 12 13 14 15 16 17 18
                // -3 -2 -2 -1 -1 0 0 0  0  +1 +1 +2 +2 +3 +3 +4
                int bonus = 0;
                if (this.Current == 3)
                    bonus = -3;
                else if (this.Current >= 4 && this.Current < 6)
                    bonus = -2;
                else if (this.Current >= 6 && this.Current < 8)
                    bonus = -1;
                else if (this.Current >= 8 && this.Current < 12)
                    bonus = 0;
                else if (this.Current >= 12 && this.Current < 14)
                    bonus = 1;
                else if (this.Current >= 14 && this.Current < 16)
                    bonus = 2;
                else if (this.Current >= 16 && this.Current < 18)
                    bonus = 3;
                else if (this.Current >= 18)
                    bonus = 4;
                return bonus;
            }
        }

        public D6 Die1
        {
            get;
            private set;
        }
        public D6 Die2
        {
            get;
            private set;
        }
        public D6 Die3
        {
            get;
            private set;
        }

        private string last_roll;
        
        public int Randomize(Random r)
        {
            if (this.Die1 == null)
                this.Die1 = new D6(r);
            if (this.Die2 == null)
                this.Die2 = new D6(r);
            if (this.Die3 == null)
                this.Die3 = new D6(r);
            int d1 = this.Die1.Throw();
            int d2 = this.Die2.Throw();
            int d3 = this.Die3.Throw();
            this.Base = d1 + d2 + d3;
            this.last_roll = string.Format("rolled {0}, {1}, {2} totalling {3}", d1, d2, d3, this.Base);
            this.Current = this.Base;

            return this.Base;
        }

        public string GetRollDescription()
        {
            StringBuilder b = new StringBuilder();
            b.AppendFormat("for {0} {1} making a bonus of ({2})",
                this.Name,
                this.last_roll,
                this.Bonus.ToString("+#;-#;0"));
            return b.ToString();
        }
		
		public override string ToString ()
		{
			return string.Format ("[PlayerAttribute: Name={0}, Base={1}, Current={2}, Bonus={3:+#;-#;0}, Die1={4}, Die2={5}, Die3={6}]", Name, Base, Current, Bonus, Die1, Die2, Die3);
		}
		
		public string Summarize ()
		{
			return string.Format ("{0}={1} ({2:+#;-#;0})", this.Name, this.Current, this.Bonus);
		}
		
		public static PlayerAttribute ReadFromXml (XPathNavigator nav)
		{
			PlayerAttribute pa = null;
			
			string name = nav.GetAttribute ("name", "");
			string basevalstr = nav.GetAttribute ("base", "");
			pa = new PlayerAttribute (name, Convert.ToInt32 (basevalstr));
			
			return pa;
		}
	}
}

