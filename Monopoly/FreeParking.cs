using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class FreeParking : Case
    {
        public FreeParking()
        {
        name = "Parking gratuit";
        }

        override public void Effect(Player p)
        {
            Console.WriteLine("Rien ne se passe..");
            Console.ReadKey();
        }
    }
}
