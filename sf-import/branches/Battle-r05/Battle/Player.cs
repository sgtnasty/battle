using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.attributes = new Dictionary<string, @Attribute>();
            this.attributes.Add("Attack", new @Attribute("Attack"));
            this.attributes.Add("Defence", new @Attribute("Defence"));
            this.attributes.Add("Armor", new @Attribute("Armor"));
            this.attributes.Add("Power", new @Attribute("Power"));
            this.attributes.Add("Speed", new @Attribute("Speed"));
            this.attributes.Add("Range", new @Attribute("Range"));            
        }

        public string Name
        {
            get;
            private set;
        }

        private Dictionary<string, @Attribute> attributes;
        public @Attribute GetAttribute(string name)
        {
            return this.attributes[name];
        }

        public int RollAttributes(Random r)
        {
            int total = 0;
            foreach (@Attribute attr in this.attributes.Values)
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
            foreach (@Attribute attr in this.attributes.Values)
            {
                b.AppendLine("\t" + attr.GetRollDescription());
            }
            return b.ToString();
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder(this.Name);
            b.Append(" <");
            foreach (@Attribute attr in this.attributes.Values)
            {
                b.Append(attr.ToString());
                b.Append(" ");
            }
            b.Append(">");
            return b.ToString();
        }
    }
}
