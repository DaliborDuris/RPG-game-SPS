using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Classes
{
    public class Person
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsDefending { get; set; } = false;

        public Person(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void Attack(Person target)
        {
            Console.WriteLine($"{Name} útočí na {target.Name}, ale nič sa nestane...");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void TakeDamage(int damage)
        {
            int finalDamage = damage;

            if (IsDefending)
            {
                finalDamage = (int)(damage * 0.5);
                Console.WriteLine($"Obrana bola úspešná! {Name} znižuje poškodenie z {damage} na {finalDamage}.");
                IsDefending = false; // Po obrane stav resetujeme
            }

            Health -= finalDamage;
            if (Health < 0)
            {
                Health = 0;
            }
            Console.WriteLine($"{Name} utrpel {finalDamage} poškodenia. Zostáva mu {Health} HP.");
        }

        public void Defend()
        {
            IsDefending = true;
            Console.WriteLine($"{Name} zaujal obranný postoj. Poškodenie v ďalšom kole bude znížené.");
        }
    }
}
