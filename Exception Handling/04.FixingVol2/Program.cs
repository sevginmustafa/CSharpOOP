using System;

namespace _04.FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 30;
            int num2 = 60;

            byte result;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} * {num2} = {result}");
            }
            catch (Exception)

            {
                Console.WriteLine("Value was either too large or too small for an unsigned byte.");
            }
        }
    }
}
