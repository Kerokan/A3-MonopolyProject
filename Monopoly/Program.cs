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

            Board.players[0].Forward(6);
            Board.players[0].Forward(2);
            Board.players[0].possessions[1].IsMort = true;
            Board.players[0].Turn();
            Board.players[0].teleport(9);
            Board.players[0].Turn();
            Console.ReadKey();
        }
    }
}
