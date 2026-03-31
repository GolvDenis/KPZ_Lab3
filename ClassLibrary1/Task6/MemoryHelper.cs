using ClassLibrary1.Task5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task6
{
    public static class MemoryHelper
    {
        public static int CountNodes(LightNode node)
        {
            if (node is LightTextNode)
                return 1;

            if (node is LightElementNode el)
                return 1 + el.Children.Sum(CountNodes);

            return 0;
        }
    }
}
