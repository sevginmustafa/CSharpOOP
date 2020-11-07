using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public abstract class Collection : IAdd
    {
        public Collection()
        {
            List = new List<string>();
        }

       public List<string> List { get; set; }

        public abstract int Add(string item);
    }
}
