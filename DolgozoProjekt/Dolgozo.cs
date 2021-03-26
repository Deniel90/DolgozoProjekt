using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjekt
{
    class Dolgozo
    {
        string vezeteknev;
        string keresztnev;
        string nem;
        int eletkor;
        int fizetes;

        public Dolgozo(string vezeteknev, string keresztnev, string nem, int eletkor, int fizetes)
        {
            this.vezeteknev = vezeteknev;
            this.keresztnev = keresztnev;
            this.nem = nem;
            this.eletkor = eletkor;
            this.fizetes = fizetes;
        }

        public string Vezeteknev { get => vezeteknev; set => vezeteknev = value; }
        public string Keresztnev { get => keresztnev; set => keresztnev = value; }
        public string Nem { get => nem; set => nem = value; }
        public int Eletkor { get => eletkor; set => eletkor = value; }
        public int Fizetes { get => fizetes; set => fizetes = value; }

        public override string ToString()
        {
            return String.Format("\n\tA dolgozó neve: {0} {1}\n" +
                "\tNeme: {2}\n" +
                "\tÉletkora: {3}\n" +
                "\tFizetése: {4} ft",
                vezeteknev, keresztnev, nem, eletkor, fizetes);
        }
    }
}
