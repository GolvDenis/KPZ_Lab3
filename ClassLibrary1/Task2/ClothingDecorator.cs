using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public class ClothingDecorator : HeroDecorator
    {
        private readonly string _name;
        private readonly int _defenseBonus;

        public ClothingDecorator(Hero hero, string name, int defenseBonus) : base(hero)
        {
            _name = name;
            _defenseBonus = defenseBonus;
        }

        public override int Defense => Hero.Defense + _defenseBonus;
        public override string Inventory => AddToInventory($"одяг: {_name} (+DEF {_defenseBonus})");
    }
}
