using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList:AddRemoveCollection
    {
        public int Used => List.Count;

        public override int Add(string item)
        {
            List.Insert(0, item);

            return 0;
        }

        public override string Remove()
        {
            string toRemove = List[0];
            List.Remove(toRemove);

            return toRemove;
        }
    }
}
