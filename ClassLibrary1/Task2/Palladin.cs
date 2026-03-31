using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public class Palladin : Hero
    {
        public override string ClassName => "Palladin";
        public override int Health => 130;
        public override int Attack => 18;
        public override int Defense => 18;
        public override int Mana => 50;
    }

}
