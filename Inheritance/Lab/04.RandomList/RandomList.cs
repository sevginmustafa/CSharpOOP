using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();

            int index = rand.Next(0, Count);

            string toRemove = this[index];

            Remove(toRemove);

            return toRemove;
        }
    }
}
