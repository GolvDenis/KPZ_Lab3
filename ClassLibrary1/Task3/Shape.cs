using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task3
{
    public abstract class Shape
    {
        protected readonly IRenderer Renderer;

        protected Shape(IRenderer renderer)
        {
            Renderer = renderer;
        }

        public abstract void Draw();
    }

}
