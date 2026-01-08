using System;
using System.Collections.Generic;
using System.IO; // <--- PRIDANÉ: Potrebné pre prácu so súbormi
using System.Threading;
using ConsoleApp5.Classes;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ... (tvoj kód pre zoznam postáv a výber zostáva rovnaký) ...
            List<Person> characters = new List<Person>()
            {
                new Warrior("Thor", 120, 15),
                new Warrior("Conan", 110, 18),
                new Mage("Gandalf", 100, 50),
                new Mage("Merlin", 90, 60),
                new Archer("Hudiny", 100, 5)
            };

            Console.WriteLine("=== Výber postáv pre boj ===\n");

            int indexHelper = 1;
            foreach (Person character in characters)
            {
                Console.WriteLine($"{indexHelper}. {character.Name}");
                indexHelper++;
            }

            Console.Write("\nVyber prvú postavu: ");
            Person p1 = SelectCharacter(characters);

            Console.Write("Vyber druhú postavu: ");
            Person p2 = SelectCharacter(characters);

            Console.WriteLine($"=== {p1.Name} vs {p2.Name} ===\n");

            // ... (tvoj kód pre cyklus súboja zostáva rovnaký) ...
            Random random = new Random();
            int round = 1;

            while (p1.IsAlive() && p2.IsAlive())
            {
                Console.WriteLine($"\n--- Kolo {round} ---");
                if (random.Next(0, 4) == 0) p1.Defend(); else p1.Attack(p2);
                if (!p2.IsAlive()) break;
                if (random.Next(0, 4) == 0) p2.Defend(); else p2.Attack(p1);
                round++;
                Thread.Sleep(500);
            }

            // === PRÁCA SO SÚBOROM (LOGOVANIE VÝSLEDKU) ===
            string cestaKSuboru = "vysledok_boja.txt";

            // Pripravíme si text, ktorý chceme uložiť
            string vitaz = p1.IsAlive() ? p1.Name : (p2.IsAlive() ? p2.Name : "Remíza");

            // String Interpolation pre pekný formát
            string zaznam = $"--- Súboj ({DateTime.Now}) ---\n" +
                            $"Bojovníci: {p1.Name} vs {p2.Name}\n" +
                            $"Víťaz: {vitaz}\n" +
                            $"Počet kôl: {round}\n" +
                            $"------------------------------\n\n";

            try
            {
                // Použijeme AppendAllText, aby sa staré výsledky nevymazali, ale pridali na koniec
                File.AppendAllText(cestaKSuboru, zaznam);
                Console.WriteLine($"\n[INFO] Výsledok boja bol uložený do: {Path.GetFullPath(cestaKSuboru)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[CHYBA] Nepodarilo sa zapísať do súboru: " + ex.Message);
            }

            // Výpis štatistík na konzolu (tvoj pôvodný kód)
            Console.WriteLine("\n=== Statistika souboje ===\n");
            List<Person> fighters = new List<Person> { p1, p2 };
            foreach (var fighter in fighters)
            {
                double avgDamage = fighter.AttacksCount > 0 ? (double)fighter.TotalDamageDealt / fighter.AttacksCount : 0;
                Console.WriteLine($"{fighter.Name}:");
                Console.WriteLine($" - Počet útoků: {fighter.AttacksCount}");
                Console.WriteLine($" - Celkové poškození: {fighter.TotalDamageDealt}");
                Console.WriteLine($" - Průměrné poškození na útok: {avgDamage:F2}\n");
            }

            Console.WriteLine("Stlač kláves pre ukončenie...");
            Console.ReadKey();
        }

        static Person SelectCharacter(List<Person> characters)
        {
            // ... (tvoja metóda SelectCharacter zostáva nezmenená) ...
            int choice = 0;
            bool valid = false;
            while (!valid)
            {
                Console.Write("Zadaj číslo postavy: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= characters.Count)
                    valid = true;
                else
                    Console.WriteLine("Neplatná voľba!");
            }
            return characters[choice - 1];
        }
    }
}