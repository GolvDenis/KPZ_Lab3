using ClassLibrary1.Task5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task6
{
    public static class BookToHtmlConverter
    {
        public static LightElementNode Convert(string path)
        {
            string text = File.ReadAllText(path);

            var root = new LightElementNode(
                HtmlTagFactory.GetTag("div"),
                ElementDisplay.Block,
                ElementClosing.Double);

            var lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].TrimEnd('\r');

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                LightElementNode element;

                if (i == 0)
                {
                    element = Create("h1", line);
                }
                else if (line.StartsWith(" "))
                {
                    element = Create("blockquote", line.Trim());
                }
                else if (line.Length < 20)
                {
                    element = Create("h2", line);
                }
                else
                {
                    element = Create("p", line);
                }

                root.AddChild(element);
            }

            return root;
        }

        private static LightElementNode Create(string tag, string text)
        {
            var el = new LightElementNode(
                HtmlTagFactory.GetTag(tag),
                ElementDisplay.Block,
                ElementClosing.Double);

            el.AddChild(new LightTextNode(text));

            return el;
        }
    }
}
