using ConsoleApp5.Classes;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Thor", 120, 15);
            Mage mage = new Mage("Gandalf", 100, 50);

            Console.WriteLine("=== RPG Battle Simulator ===\n");
            Console.WriteLine($"{warrior.Name} (Warrior) vs {mage.Name} (Mage)\n");

            int round = 1;
            while (warrior.IsAlive() && mage.IsAlive())
            {
                Console.WriteLine($"--- Kolo {round} ---");
                warrior.Attack(mage);
                if (!mage.IsAlive()) break;

                mage.Attack(warrior);
                Console.WriteLine();
                round++;
                System.Threading.Thread.Sleep(800);
            }

            Console.WriteLine("=== 🏁 Konec boja ===");
            if (warrior.IsAlive())
            {
                Console.WriteLine($"{warrior.Name} vyhral so {warrior.Health} HP!");
            }
            else
            {
                Console.WriteLine($"{mage.Name} vyhral so {mage.Health} HP!");
            }
        }
    }
}
