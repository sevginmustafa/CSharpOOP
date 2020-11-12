using System;

namespace _03.Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[]
            {
               "Sunday","Monday","Tuesday","Wednesday","Thursday"
            };

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i]);
                }
                Console.ReadLine();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index was outside the bounds of the array!");
            }
        }
    }
}
