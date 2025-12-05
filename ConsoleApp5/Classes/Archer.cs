using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Classes
{
    public class Archer : Person
    {
        public int Arrows { get; set; }

        public Archer(string name, int health, int arrows) : base(name, health)
        {
            Arrows = arrows;
        }

        public override void Attack(Person target)
        {
            if (Arrows <= 0)
            {
                Console.WriteLine($"{Name} nemá šípy! Pøipravuji nové šípy...");
                Arrows += 5; // reload
                return;
            }

            int damage = new Random().Next(15, 30);
            Arrows--;
            Console.WriteLine($"{Name} vystøelí šíp na {target.Name} a zpùsobí {damage} poškození! (Šípy zbylé: {Arrows})");
            target.TakeDamage(damage);

            // Aktualizace statistiky
            AttacksCount++;
            TotalDamageDealt += damage;
        }
    }
}