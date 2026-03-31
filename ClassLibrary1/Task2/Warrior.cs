using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public class Warrior : Hero
    {
        public override string ClassName => "Warrior";
        public override int Health => 150;
        public override int Attack => 25;
        public override int Defense => 15;
        public override int Mana => 0;
    }

}
