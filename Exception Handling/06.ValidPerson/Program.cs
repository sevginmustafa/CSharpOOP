using System;

namespace _06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person personOne = new Person("Ivan", "Ivanov", 36);
            //Person personTwo = new Person(string.Empty, "Ivanov", 36);
            //Person personThree = new Person("Ivan", null, 36);
            //Person personFour = new Person("Ivan", "Ivanov", -36);
            //Person personFive = new Person("Ivan", "Ivanov", 36);

            try
            {
                Person person = new Person(string.Empty, "Ivanov", 36);

                Console.WriteLine(person);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
        }
    }
}
