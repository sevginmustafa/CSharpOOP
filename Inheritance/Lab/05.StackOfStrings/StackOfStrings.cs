using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddRange(List<string> list)
        {
            for (int i = 0; i <= list.Count; i++)
            {
                Push(list[i]);
            }
        }
    }
}
