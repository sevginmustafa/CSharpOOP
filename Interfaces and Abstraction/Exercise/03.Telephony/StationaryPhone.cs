using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Calling(string phoneNumber)
        {
            if (phoneNumber.Any(x => !char.IsDigit(x)))
            {
                return "Invalid number!";
            }

            return "Dialing... " + phoneNumber;
        }
    }
}
