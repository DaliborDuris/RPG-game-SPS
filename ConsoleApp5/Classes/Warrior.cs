using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Classes
{
    public class Warrior : Person
    {
        public int Strength { get; set; }

        public Warrior(string name, int health, int strength)
            : base(name, health)
        {
            Strength = strength;
        }

        public override void Attack(Person target)
        {
            int damage = Strength + new Random().Next(5, 15);
            Console.WriteLine($"{Name} máva mečom na {target.Name} a spôsobí {damage} poškodenia!");
            target.TakeDamage(damage);
            // Aktualizace statistiky
            AttacksCount++;
            TotalDamageDealt += damage;
        }
    }
}
