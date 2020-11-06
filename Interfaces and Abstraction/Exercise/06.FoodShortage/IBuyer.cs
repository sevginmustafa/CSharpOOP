using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Food { get;  }

        public void BuyFood();
    }
}
