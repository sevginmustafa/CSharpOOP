using System;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classType}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in classNonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
