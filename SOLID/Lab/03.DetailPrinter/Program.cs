using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> list = new List<Employee>();

            Employee employee = new Manager("Ivan", new List<string> { "1", "2", "3" });
            Employee employee2 = new Employee("Dragan");

            list.Add(employee);
            list.Add(employee2);

            DetailsPrinter printer = new DetailsPrinter(list);

            printer.PrintDetails();
        }
    }
}
