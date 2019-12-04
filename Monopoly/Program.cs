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

            Board.players[0].Forward(5);
            Board.players[0].Forward(10);
            Board.players[0].Forward(10);
            Board.players[0].possessions[1].IsMort = true;
            Board.players[0].Turn();
            Board.players[0].teleport(35);
            Board.players[0].Turn();
            Console.ReadKey();
        }
    }
}
