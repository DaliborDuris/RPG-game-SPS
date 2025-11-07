using ConsoleApp5.Classes;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Thor", 120, 15);
            Mage mage = new Mage("Gandalf", 100, 50);
            Random random = new Random();

            Console.WriteLine("=== RPG Battle Simulator s Obrannou Mechanikou ===\n");
            Console.WriteLine($"{warrior.Name} (Warrior) vs {mage.Name} (Mage)\n");

            int round = 1;
            while (warrior.IsAlive() && mage.IsAlive())
            {
                Console.WriteLine($"\n--- Kolo {round} ---");

                // === Kolo pre Warriora (Thor) ===
                if (random.Next(0, 4) == 0) // 25% šanca na obranu
                {
                    warrior.Defend();
                }
                else
                {
                    warrior.Attack(mage);
                }
                if (!mage.IsAlive()) {
                    break;
                } 

                // === Kolo pre Magea (Gandalf) ===
                if (random.Next(0, 4) == 0) // 25% šanca na obranu
                {
                    mage.Defend();
                }
                else
                {
                    mage.Attack(warrior);
                }

                round++;
                System.Threading.Thread.Sleep(800);
            }

            Console.WriteLine("\n=== 🏁 Konec boja ===");
            if (warrior.IsAlive())
            {
                Console.WriteLine($"{warrior.Name} vyhral so {warrior.Health} HP!");
            }
            else if (mage.IsAlive())
            {
                Console.WriteLine($"{mage.Name} vyhral so {mage.Health} HP!");
            }
            else
            {
                Console.WriteLine("Obaja hrdinovia padli!");
            }

            Console.WriteLine("\nStlačte ľubovoľný kláves pre ukončenie...");
            Console.ReadKey();
        }
    }
}
