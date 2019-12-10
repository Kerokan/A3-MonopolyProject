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
            Board.Display();
            Board.cases[7].Effect(Board.players[0]);

            Console.ReadKey();
        }
    }
}
