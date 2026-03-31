using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task6
{
    public static class HtmlTagFactory
    {
        private static Dictionary<string, HtmlTag> tags = new();

        public static HtmlTag GetTag(string name)
        {
            if (!tags.ContainsKey(name))
                tags[name] = new HtmlTag(name);

            return tags[name];
        }

        public static int Count => tags.Count;
    }
}
