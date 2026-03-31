using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task3
{
    public class VectorRenderer : IRenderer
    {
        public string DrawCircle() => "Малюю коло як векторну графіку";
        public string DrawSquare() => "Малюю квадрат як векторну графіку";
        public string DrawTriangle() => "Малюю трикутник як векторну графіку";
    }
}
