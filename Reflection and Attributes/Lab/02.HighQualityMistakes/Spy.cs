using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAcessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
