using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Rodic
    {
        protected string Jmeno { get; set; }
        protected int Vek { get; set; }
        protected string Adresa { get; set; }

        public Rodic(string jmeno, int vek, string adresa) { 
            this.Adresa = adresa;
            this.Jmeno = jmeno;
            this.Vek = vek;
        }
    }
}
