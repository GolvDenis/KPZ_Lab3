using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public abstract class HeroDecorator : Hero
    {
        protected readonly Hero Hero;

        protected HeroDecorator(Hero hero)
        {
            Hero = hero;
        }

        public override string ClassName => Hero.ClassName;
        public override int Health => Hero.Health;
        public override int Attack => Hero.Attack;
        public override int Defense => Hero.Defense;
        public override int Mana => Hero.Mana;
        public override string Inventory => Hero.Inventory;

        protected string AddToInventory(string item)
        {
            return Hero.Inventory == "порожньо" ? item : $"{Hero.Inventory}, {item}";
        }
    }

}
