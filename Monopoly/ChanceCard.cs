using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Console.ReadKey();
        }

        public bool GoToStart(Player p)
        {
            Console.WriteLine("Carte chance : Allez à la Case Départ.");
            p.teleport(0);
            return true;
        }

        public bool GoToJail(Player p)
        {
            Console.WriteLine("Carte chance : Allez directement en prison.");
            p.teleport(30);
            return true;
        }

        public bool GoToVillette(Player p)
        {
            Console.WriteLine("Carte chance : Allez au Boulevard de la Villette.");
            ushort x = (ushort)((11 - p.position) % 40);
            p.Forward(x);
            return true;
        }

        public bool FineDrunk(Player p)
        {
            Console.WriteLine("Carte chance : Vous avez une amende de 2 000 euros pour conduite en état d'ivresse.");
            p.Taxe(2000);
            return true;
        }

        public bool CrosswordPuzzle(Player p)
        {
            Console.WriteLine("Carte chance : Vous gagnez le premier prix de mots-croisées : 10 000 euros.");
            p.Money += 10000;
            return true;
        }

        public bool GoToHenriMartin(Player p)
        {
            Console.WriteLine("Carte chance : Allez à l'Avenue Henri Martin.");
            ushort x = (ushort)((24 - p.position) % 40);
            p.Forward(x);
            return true;
        }

        public bool GoToLyon(Player p)
        {
            Console.WriteLine("Carte chance : Allez à la Gare de Lyon.");
            ushort x = (ushort)((15 - p.position) % 40);
            p.Forward(x);
            return true;
        }

        public bool FineSpeeding(Player p)
        {
            Console.WriteLine("Carte chance : Vous avez une amende de 2 000 euros pour excès de conduite");
            p.Taxe(1500);
            return true;
        }

        public bool SchoolFees(Player p)
        {
            Console.WriteLine("Carte chance : Vous payez les frais de l'ESILV pour vos enfants : 15000 euros.");
            p.Taxe(15000);
            return true;
        }

        public bool Backward3(Player p)
        {
            Console.WriteLine("Carte chance : Vous reculez de 3 cases.");
            p.Backward(3);
            return true;
        }

        public bool Reparations(Player p)
        {
            // - 2 500 Euros for every Houses // - 10 000 for every Hotels
            int[] buildings = p.GetHousesAndHotels();
            int fee = buildings[0]*2500+buildings[1]*10000;
            Console.WriteLine("Reparations dans vos bâtiments, vous payez " + fee + " euros");
            p.Taxe(fee);
            return true;
        }

        public bool Loan(Player p)
        {
            Console.WriteLine("Carte chance : Votre prêt rapporte ! Vous gagnez 15 000 euros");
            p.Money += 15000;
            return true;
        }

        public bool GoToPeace(Player p)
        {
            Console.WriteLine("Carte chance : Allez à la Rue de la Paix.");
            ushort x = (ushort)((39 - p.position) % 40);
            p.Forward(x);
            return true;
        }

        public bool RoadSystem(Player p)
        {
            // +- 4 000 for every Houses // +- 11 500 for every Hotels
            int[] buildings = p.GetHousesAndHotels();
            int fee = buildings[0]*4000+buildings[1]*11500;
            Console.WriteLine("Aménagements de systèmes routiers près de vos bâtiments, vous payez " + fee + " euros");
            p.Taxe(fee);
            return true;
        }

        public bool BankToYou(Player p)
        {
            Console.WriteLine("Carte chance : La Banque vous doit 5 000 euros.");
            p.Money += 5000;
            return true;
        }
    }
}
