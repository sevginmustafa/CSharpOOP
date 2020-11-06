using System;
using System.Linq;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            IStationaryPhone stationaryPhone = new StationaryPhone();
            ISmartphone smartPhone = new Smartphone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (phoneNumbers[i].Length == 10)
                {
                    Console.WriteLine(smartPhone.Calling(phoneNumbers[i]));
                }
                else
                {
                    Console.WriteLine(stationaryPhone.Calling(phoneNumbers[i]));
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                Console.WriteLine(smartPhone.Browsing(sites[i]));
            }
        }
    }
}
