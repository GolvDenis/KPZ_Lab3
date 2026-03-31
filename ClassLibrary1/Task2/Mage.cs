using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public class Mage : Hero
    {
        public override string ClassName => "Mage";
        public override int Health => 80;
        public override int Attack => 15;
        public override int Defense => 5;
        public override int Mana => 120;
    }


}
