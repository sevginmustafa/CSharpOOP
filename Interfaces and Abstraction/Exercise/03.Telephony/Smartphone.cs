using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Browsing(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }

            return "Browsing: " + site + "!";
        }

        public string Calling(string phoneNumber)
        {
            if (phoneNumber.Any(x => !char.IsDigit(x)))
            {
                return "Invalid number!";
            }

            return "Calling... " + phoneNumber;
        }
    }
}
