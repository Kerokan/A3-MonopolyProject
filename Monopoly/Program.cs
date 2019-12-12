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

            // TODO : Caisse de communautés pas enregistrés (wtf)
            // Loyer !!
            // Prison !!
            Board board = Board.Instance;

            while(Board.players.Length > 1)
            {
                foreach(Player p in Board.players)
                    p.Turn();
            }
            Console.ReadKey();
        }
    }
}
