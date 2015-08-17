using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle
{
    public class D6
    {
        public D6(Random random)
        {
            this.random = random;
        }

        private Random random;

        public int Throw()
        {
            int x = this.random.Next(1, 7);
            if (x <1) throw new ArgumentOutOfRangeException("Roll is less than 1!");
            if (x >6) throw new ArgumentOutOfRangeException("Roll is greater than 6!");
            return x;
        }
    }
}
