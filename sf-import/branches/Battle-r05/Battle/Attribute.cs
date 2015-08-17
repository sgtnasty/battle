using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle
{
    public class @Attribute
    {
        public @Attribute(string name)
            :this(name, 0, 0)
        {
        }
        public @Attribute(string name, int baseval)
            : this(name, baseval, baseval)
        {
        }
        public @Attribute(string name, int baseval, int curval)
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

        public override string ToString()
        {
            /*
            return string.Format("{0}={1} (rolled {2}, {3}, {4})",
                this.Name, this.Current, this.DieRoll1, this.DieRoll2, this.DieRoll3);
            */
            return string.Format("{0}={1:00} ({2})", this.Name.Substring(0,3), this.Current, this.Bonus.ToString("+#;-#; 0"));
        }

        public string ToLongString()
        {
            return string.Format("{0}={1} ({2})", this.Name, this.Current, this.Bonus.ToString("+0;-0;##"));
        }
    }
}
