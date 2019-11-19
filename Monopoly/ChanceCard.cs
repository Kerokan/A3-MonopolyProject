using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceCard : Case
    {
        protected Dictionary<int, Func<Player, bool>> myDicti = new Dictionary<int, Func<Player, bool>>();
        static Random rand = new Random();
        public ChanceCard()
        {
            Name = "Chance Card";
            myDicti.Add(1, GoToStart);
            myDicti.Add(2, GoToJail);
            myDicti.Add(3, GoToVillette);
            myDicti.Add(4, FineDrunk);
            myDicti.Add(5, CrosswordPuzzle);
            myDicti.Add(6, GoToHenriMartin);
            myDicti.Add(7, GoToLyon);
            myDicti.Add(8, FineSpeeding);
            myDicti.Add(9, SchoolFees);
            myDicti.Add(10, Backward3);
            myDicti.Add(11, Reparations);
            myDicti.Add(12, Loan);
            myDicti.Add(13, RoadSystem);
            myDicti.Add(14, GoToPeace);
            myDicti.Add(15, BankToYou);
        }

        override public void Effect(Player p)
        {
            int effect = rand.Next(1, 16);
            myDicti[effect](p);
        }

        public bool GoToStart(Player p)
        {
            Console.WriteLine("GoToStart");
            return true;
        }

        public bool GoToJail(Player p)
        {
            Console.WriteLine("GoToJail");
            return true;
        }

        public bool GoToVillette(Player P)
        {
            Console.WriteLine("GoToVillette");
            return true;
        }

        public bool FineDrunk(Player p)
        {
            // - 2 000 Euros
            Console.WriteLine("FineDrunk");
            return true;
        }

        public bool CrosswordPuzzle(Player p)
        {
            // + 10 000 Euros
            Console.WriteLine("CrosswordPuzzle");
            return true;
        }

        public bool GoToHenriMartin(Player p)
        {
            Console.WriteLine("GoToHenriMartin");
            return true;
        }

        public bool GoToLyon(Player p)
        {
            Console.WriteLine("GoToLyon");
            return true;
        }

        public bool FineSpeeding(Player p)
        {
            // - 1 500 Euros
            Console.WriteLine("FineSpeeding");
            return true;
        }

        public bool SchoolFees(Player p)
        {
            // - 15 000 Euros
            Console.WriteLine("SchoolFees");
            return true;
        }

        public bool Backward3(Player p)
        {
            Console.WriteLine("Backward3");
            return true;
        }

        public bool Reparations(Player p)
        {
            // - 2 500 Euros for every Houses // - 10 000 for every Hotels
            Console.WriteLine("Reparations");
            return true;
        }

        public bool Loan(Player p)
        {
            // + 15 000 Euros
            Console.WriteLine("Loan");
            return true;
        }

        public bool GoToPeace(Player p)
        {
            Console.WriteLine("GoToPeace");
            return true;
        }

        public bool RoadSystem(Player p)
        {
            // +- 4 000 for every Houses // +- 11 500 for every Hotels
            Console.WriteLine("RoadSystem");
            return true;
        }

        public bool BankToYou(Player p)
        {
            // + 5 000 Euros
            Console.WriteLine("BankToYou");
            return true;
        }
    }
}
