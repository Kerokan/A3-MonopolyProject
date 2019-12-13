using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityFund : Case
    {
        protected Dictionary<int, Func<Player, bool>> myDicti = new Dictionary<int, Func<Player, bool>>();
        static Random rand = new Random();
        public CommunityFund()
        {
            Name = "Community Fund";
            myDicti.Add(1, BankError);
            myDicti.Add(2, BackToBelleville);
            myDicti.Add(3, Contributions);
            myDicti.Add(4, LoanInterest);
            myDicti.Add(5, StockSold);
            myDicti.Add(6, Inheritance);
            myDicti.Add(7, GoToJail);
            myDicti.Add(8, ChanceOrPay);
            myDicti.Add(9, DoctorFee);
            myDicti.Add(10, Birthday);
            myDicti.Add(11, GoToStart);
            myDicti.Add(12, Hospital);
            myDicti.Add(13, Salary);
        }

        override public void Effect(Player p)
        {
            int effect = rand.Next(1, 16);
            myDicti[effect](p);
            Console.ReadKey();
        }

        public bool BankError(Player p)
        {
            Console.WriteLine("Erreur de la banque en votre faveur. Vous recevez 20 000 euros");
            p.Money = p.Money + 20000;
            return true;
        }

        public bool BackToBelleville(Player p)
        {
            Console.WriteLine("Retournez a Belleville");
            p.Backward((ushort)(p.position - 1));
            return true;
        }

        public bool Contributions(Player p)
        {
            Console.WriteLine("Les Contributions vous remboursent la somme de 2000 euros");
            p.Money = p.Money + 2000;
            return true;
        }

        public bool LoanInterest(Player p)
        {
            Console.WriteLine("Recevez les interets sur l'emprunt de 2500 euros");
            p.Money = p.Money + 2500;
            return true;
        }

        public bool StockSold(Player p)
        {
            Console.WriteLine("La vente de votre stock vous rapporte 5000 euros");
            p.Money = p.Money + 5000;
            return true;
        }

        public bool Inheritance(Player p)
        {
            Console.WriteLine("Vous heritez de 10 000 euros");
            p.Money = p.Money + 10000;
            return true;
        }

        public bool GoToJail(Player p)
        {
            Console.WriteLine("Vous allez directement en prison, sans passer par la case départ.");
            if (p.position > 30)
            {
                p.Backward((ushort)(p.position - 30));
            }
            else
            {
                p.Forward((ushort)(30 - p.position));
            }
            return true;
        }

        public bool ChanceOrPay(Player p)
        {
            Console.WriteLine("Dilemne : \n1. Vous tirez une carte chance\n2. Vous payez une amende de 1000 euros");
            bool verif = false;
            while (!verif)
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        ChanceCard cc = new ChanceCard();
                        cc.Effect(p);
                        verif = true;
                        break;

                    case "2":
                        if (p.Money > 1000)
                        {
                            p.Taxe(1000);
                            verif = true;
                        }
                        else
                        {
                            Console.WriteLine("Vous n'avez pas suffisamment d'argent");
                        }
                        break;

                    default:
                        Console.WriteLine("Je n'ai pas compris. Veuillez reessayer.");
                        break;
                }
            }
            return true;
        }

        // TODO : Verification
        public bool Birthday(Player p)
        {
            Console.WriteLine("C'est votre anniversaire. Chaque joueur doit vous donner 1000 euros");
            foreach (Player player in Board.players)
            {
                player.Taxe(1000);
                p.Money = p.Money + 1000;
            }
            return true;
        }

        public bool DoctorFee(Player p)
        {
            Console.WriteLine("Vous payez la note du médecin : 5000 euros (ca devait etre grave)");
            p.Taxe(5000);
            return true;
        }

        public bool GoToStart(Player p)
        {
            Console.WriteLine("Allez sur la case depart");
            p.Forward((ushort)(40 - p.position));
            return true;
        }

        public bool Hospital(Player p)
        {
            Console.WriteLine("Payez l'hopital 10 000 euros. (Il va falloir faire quelque chose pour votre sante)");
            p.Taxe(10000);
            return true;
        }

        public bool Salary(Player p)
        {
            Console.WriteLine("Vous recevez votre revenu annuel de 10 000 euros");
            p.Money = p.Money + 10000;
            return true;
        }
    }
}
