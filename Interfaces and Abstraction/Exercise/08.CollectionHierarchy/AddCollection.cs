using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class AddCollection : Collection
    {
        public override int Add(string item)
        {
            List.Add(item);

            return List.Count - 1;
        }
    }
}
