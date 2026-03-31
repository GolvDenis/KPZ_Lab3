using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task3
{
    public class RasterRenderer : IRenderer
    {
        public string DrawCircle() => "Малюю коло як пікселі";
        public string DrawSquare() => "Малюю квадрат як пікселі";
        public string DrawTriangle() => "Малюю трикутник як пікселі";
    }

}
