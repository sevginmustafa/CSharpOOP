using System;

namespace _06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Ivan4o", "ivan_ivanov@abv.bg");

                Console.WriteLine(student);
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine($"Exception thrown: {ipne.Message}");
            }
        }
    }
}
