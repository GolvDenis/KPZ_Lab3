using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Lab4.Task4
{
    public class LightImageNode : LightNode
    {
        public string Href { get; }
        public string Alt { get; }
        private readonly IImageLoadStrategy _strategy;

        public string LoadResult { get; private set; }

        public LightImageNode(string href, string alt = "")
        {
            Href = href;
            Alt = alt;

            if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                href.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                _strategy = new NetworkImageLoadStrategy();
            }
            else
            {
                _strategy = new FileImageLoadStrategy();
            }

            LoadResult = _strategy.Load(href);
        }

        public override string OuterHTML()
        {
            return $"<img src=\"{Href}\" alt=\"{Alt}\" />";
        }

        public override string InnerHTML()
        {
            return "";
        }
    }

}
