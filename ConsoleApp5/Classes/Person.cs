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
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} utrpel {damage} poškodenia. Zostáva mu {Health} HP.");
        }
    }
}
