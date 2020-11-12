using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            ReadNumber(start, end);
        }

        static void ReadNumber(int start, int end)
        {
            int currentNumber = 0;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number > 1 && number < 100
                        && number >= start && number <= end
                        && number > currentNumber)
                    {
                        currentNumber = number;
                    }
                    else
                    {
                        throw new Exception("You've entered an invalid number!"
                            + Environment.NewLine + "Try all over again!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i = -1;
                    currentNumber = 0;
                }
            }
            Console.WriteLine($"You've successfully entered 10 valid numbers!"
                + Environment.NewLine + "Congratulations, you're the smartest person in the world!");
        }
    }
}
