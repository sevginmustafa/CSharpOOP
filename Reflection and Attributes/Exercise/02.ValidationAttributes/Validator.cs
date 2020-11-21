using System.Reflection;

namespace ValidationAttributes
{
   public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyCustomAttributes = property.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in propertyCustomAttributes)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
