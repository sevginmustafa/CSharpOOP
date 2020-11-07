using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IRemove
    {
        public override int Add(string item)
        {
            List.Insert(0, item);

            return 0;
        }

        public virtual string Remove()
        {
            string toRemove = List[List.Count - 1];
            List.Remove(toRemove);

            return toRemove;
        }
    }
}
