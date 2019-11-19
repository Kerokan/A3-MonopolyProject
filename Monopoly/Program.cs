using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Thibault");
            ChanceCard cc = new ChanceCard();
            cc.Effect(player);
            cc.Effect(player);

            ChanceCard cc2 = new ChanceCard();
            cc2.Effect(player);
            cc2.Effect(player);

            Console.ReadKey();
        }
    }
}
