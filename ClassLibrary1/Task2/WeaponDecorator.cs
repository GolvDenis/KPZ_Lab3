using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public class WeaponDecorator : HeroDecorator
    {
        private readonly string _name;
        private readonly int _attackBonus;

        public WeaponDecorator(Hero hero, string name, int attackBonus) : base(hero)
        {
            _name = name;
            _attackBonus = attackBonus;
        }

        public override int Attack => Hero.Attack + _attackBonus;
        public override string Inventory => AddToInventory($"зброя: {_name} (+ATK {_attackBonus})");
    }

}
