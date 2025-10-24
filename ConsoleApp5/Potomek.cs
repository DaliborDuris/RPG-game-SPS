using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Potomek : Rodic
    {
        public Potomek(string jmeno, int vek, string adresa) : base(jmeno, vek, adresa)
        {
        }

        public void GetInfo()
        {
            Console.WriteLine(Jmeno + ", " + Vek + ", " + Adresa + ".");
        }
    }
}
