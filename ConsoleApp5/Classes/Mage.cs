using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Classes
{
    public class Mage : Person
    {
        public int Mana { get; set; }

        public Mage(string name, int health, int mana) : base(name, health)
        {
            Mana = mana;
        }

        public override void Attack(Person target)
        {
            if (Mana < 10)
            {
                Console.WriteLine($"{Name} nemá dosť many na kúzlo! Obnovuje energiu...");
                Mana += 20;
                return;
            }

            int damage = new Random().Next(20, 40);
            Mana -= 10;
            Console.WriteLine($"{Name} zosiela ohnivú guľu na {target.Name} a spôsobí {damage} poškodenia!");
            target.TakeDamage(damage);

            // Aktualizace statistiky
            AttacksCount++;
            TotalDamageDealt += damage;
        }
    }
}
