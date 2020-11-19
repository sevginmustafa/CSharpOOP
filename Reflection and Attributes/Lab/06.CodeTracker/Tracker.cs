using System;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {
        public static void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is writen by {attribute.Name}");
                    }
                }
            }
        }
    }
}
