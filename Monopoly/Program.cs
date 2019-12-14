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
            Board board = Board.Instance;

            while(Board.players.Length > 1)
            {
                foreach (Player p in Board.players)
                    p.Turn();
            }
            Console.WriteLine("Le vainqueur est {0} !", Board.players[0].Name);
            Console.ReadKey();
        }
    }
}
