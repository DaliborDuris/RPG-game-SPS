using System.Globalization;
using ConsoleApp5.Classes;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // === ZOZNAM POSTÁV ===
            List<Person> characters = new List<Person>()
            {
                new Warrior("Thor", 120, 15),
                new Warrior("Conan", 110, 18),
                new Mage("Gandalf", 100, 50),
                new Mage("Merlin", 90, 60),
                new Archer("Hudiny", 100, 5)
            };

            Console.WriteLine("=== Výber postáv pre boj ===\n");

            // Výpis postáv
          
            
            int indexHelper = 1;
            foreach (Person character in characters) {
                Console.WriteLine(indexHelper + character.Name);
                indexHelper++;
            }

            // Výber postavy
            Console.Write("\nVyber prvú postavu: ");
            Person p1 = SelectCharacter(characters);

            Console.Write("Vyber druhú postavu: ");
            Person p2 = SelectCharacter(characters);

            Console.WriteLine($"=== {p1.Name} vs {p2.Name} ===\n");

            Random random = new Random();
            int round = 1;

            while (p1.IsAlive() && p2.IsAlive())
            {
                Console.WriteLine($"\n--- Kolo {round} ---");

                // P1
                if (random.Next(0, 4) == 0)
                    p1.Defend();
                else
                    p1.Attack(p2);

                if (!p2.IsAlive()) break;

                // P2
                if (random.Next(0, 4) == 0)
                    p2.Defend();
                else
                    p2.Attack(p1);

                round++;
                Thread.Sleep(800);
            }

            Console.WriteLine("\n=== 🏁 Koniec boja ===");
            if (p1.IsAlive())
            {
                Console.WriteLine($"{p1.Name} vyhral so {p1.Health} HP!");
            }
            else if (p2.IsAlive())
            {
                Console.WriteLine($"{p2.Name} vyhral so {p2.Health} HP!");
            }
            else
            {
                Console.WriteLine("Obaja bojovníci padli!");
            }


            Console.WriteLine("\n=== Statistika souboje ===\n");

            List<Person> fighters = new List<Person> { p1, p2 };
            foreach (var fighter in fighters)
            {
                double avgDamage;

                if (fighter.AttacksCount > 0)
                {
                    avgDamage = (double)fighter.TotalDamageDealt / fighter.AttacksCount;
                }
                else
                {
                    avgDamage = 0;
                }

                Console.WriteLine($"{fighter.Name}:");
                Console.WriteLine($" - Počet útoků: {fighter.AttacksCount}");
                Console.WriteLine($" - Celkové poškození: {fighter.TotalDamageDealt}");
                Console.WriteLine($" - Průměrné poškození na útok: {avgDamage:F2}\n");
            }

            Console.ReadKey();
        }


        static Person SelectCharacter(List<Person> characters)
        {
            int choice = 0;
            bool valid = false;

            while (!valid)
            {
                Console.Write("Zadaj číslo postavy: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    if (choice >= 1 && choice <= characters.Count)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Neplatné číslo! Skús znova.");
                    }
                }
                else
                {
                    Console.WriteLine("Musíš zadať číslo!");
                }
            }

            return characters[choice - 1];
        }


    }
}
