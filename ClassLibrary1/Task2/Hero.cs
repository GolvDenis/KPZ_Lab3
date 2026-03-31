using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task2
{
    public abstract class Hero
    {
        public abstract string ClassName { get; }

        public virtual int Health => 0;
        public virtual int Attack => 0;
        public virtual int Defense => 0;
        public virtual int Mana => 0;

        public virtual string Inventory => "порожньо";

        public virtual string GetInfo()
        {
            return $"{ClassName} | HP: {Health} | ATK: {Attack} | DEF: {Defense} | MP: {Mana} | Інвентар: {Inventory}";
        }
    }

}
