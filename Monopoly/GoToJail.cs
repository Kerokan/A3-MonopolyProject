using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class GoToJail : Case
    {
        public GoToJail()
        {
            name = "Allez en prison";
        }


        override public void Effect(Player p)
        {
            Console.Clear();
            Console.WriteLine("Le joueur {0} va directement en prison.", p.Name);
            p.SendToJail();
            Console.WriteLine("Votre tour est terminé, appuyez sur entrée...");
            Console.ReadKey();
        }
    }
}
