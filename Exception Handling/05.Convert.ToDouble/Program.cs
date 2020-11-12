using System;

namespace _05.Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[]
            {
                "number",
                "5,68",
                "7.4115646648564654165165",
                "6666",
                "19.64",
                "55555555555555555555555555555555555.55"
            };

            for (int i = 0; i < test.Length; i++)
            {
                try
                {
                    double convertedNumber = System.Convert.ToDouble(test[i]);
                    Console.WriteLine(convertedNumber);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unhandled exeption");
                }
            }
        }
    }
}
