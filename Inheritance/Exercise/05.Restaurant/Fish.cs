using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, decimal price) : base(name, price, DefaultGrams)
        {
          
        }

        private const double DefaultGrams = 22;
    }
}
