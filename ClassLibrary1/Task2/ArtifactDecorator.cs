using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public class ArtifactDecorator : HeroDecorator
    {
        private readonly string _name;
        private readonly int _healthBonus;
        private readonly int _manaBonus;

        public ArtifactDecorator(Hero hero, string name, int healthBonus, int manaBonus) : base(hero)
        {
            _name = name;
            _healthBonus = healthBonus;
            _manaBonus = manaBonus;
        }

        public override int Health => Hero.Health + _healthBonus;
        public override int Mana => Hero.Mana + _manaBonus;
        public override string Inventory => AddToInventory($"артефакт: {_name} (+HP {_healthBonus}, +MP {_manaBonus})");
    }

}
