using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface ISmartphone
    {
        public string Calling(string phoneNumber);
        public string Browsing(string site);
    }
}
