using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player : IEquatable<Player>
    {
        static Board board;
        private string name;
        public ushort position;
        private uint money;
        public bool inJail;
        public List<BuyableCase> possessions;

        public string Name { get => name; set => name = value; }
        public uint Money { get => money; set => money = value; }

        public Player(string _name, Board board)
        {
           // board = Board.Instance;
            name = _name;
            position = 0;
            money = 150000;
            inJail = false;
            possessions = new List<BuyableCase>();
            Player.board = board;
        }

        /// <summary>
        /// Roll the dices, move the player and trigger effetcs
        /// If it's a double, play again
        /// Player will go to jail after 3 consecutive double
        /// </summary>
        /// TO REDO
        public void Play() 
        {
            ushort[] dices;
            ushort combo;

            combo = 3;
            do
            {
                dices = board.dices.Roll();
                combo--;
                Console.WriteLine("Vous avez fait {0}", dices[0] + dices[1]);
                if(dices[0] == dices[1])
                {
                    Console.WriteLine("C'est un double !");
                    if(combo >= 0)
                    {
                        Console.WriteLine("Vous allez rejouer.");
                    }
                    else
                    {
                        Console.WriteLine("Vous allez directement en prison.");
                    }
                }
                this.Forward((ushort)(dices[0] + dices[1]));
            }
            while (dices[0] == dices[1] && combo >= 1);
            if (combo == 0)
            {
                this.teleport(30);
            }
        }

        public void Backward(ushort value) 
        {
            this.teleport((ushort)((position - value)%40));
        }

        public void Forward(ushort value) 
        {
            if (position + value > 39)
                money += 20000;
            this.teleport((ushort)((position + value)%40));
        }
        public void teleport(ushort position)
        {
            this.position = (ushort)(position % 40);
            Board.PositionUpdate(this);
        }

        public void PositionDisp()
        {
            foreach(Player p in Board.players)
                Console.WriteLine("Le joueur " + p.name + " est actuellement à la case " + Board.cases[p.position].name + " (" + ((p.position/5)+1) + "eme ligne)");
        }

        public void Turn()
        {
            bool verif1 = false;
            bool verif2 = false;
            Console.Clear();
            Board.Display();
            PositionDisp();
            Console.WriteLine("C'est au tour de {0}", this.Name);
            while (!verif1)
            {
                this.Summary();
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1. Lancer les des");
                Console.WriteLine("2. Consulter vos proprietes");
                Console.WriteLine("3. Proposer un echange a un autre joueur");
                Console.WriteLine("\nEntrez votre choix : ");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        this.Play();
                        verif1 = true;
                        break;

                    case "2":
                        this.Consult();
                        break;

                    case "3":
                       // this.Exchange();
                        break;

                    default:
                        break;
                }
            }
            Console.Clear();
            while (!verif2)
            {
                this.Summary();
                Console.WriteLine("Que voulez-vous faire ?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("1. Lancer les des");
                Console.ResetColor();
                Console.WriteLine("2. Consulter vos proprietes");
                Console.WriteLine("3. Proposer un echange a un autre joueur");
                Console.WriteLine("0. Passer au joueur suivant");
                Console.WriteLine("\nEntrez votre choix : ");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Vous avez deja joue votre tour.");
                        Console.ReadKey();
                        break;

                    case "2":
                        this.Consult();
                        break;

                    case "3":
                        // this.Exchange();
                        break;

                    case "0":
                        verif2 = true;
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("Votre tour est termine. Veuillez appuyer sur une touche pour passer au joueur suivant.");
            Console.ReadKey();

        }

        public void Summary()
        {
            int propDisp = 0;
            int propMort = 0;
            foreach(BuyableCase bc in possessions)
            {
                if (bc.IsMort)
                {
                    propMort++;
                }
                else
                {
                    propDisp++;
                }
            }
            Console.WriteLine("Joueur {0} \n\nArgent disponible {1}\nProporietes disponibles : {2}\nProprietes hypothequees : {3}\n\n",this.Name, this.Money, propDisp, propMort);
        }

        public void Consult()
        {
            Console.Clear();
            Console.WriteLine("Liste des proprietes de {0} :", this.Name);
            Console.WriteLine("Les proprietes en rouge sont hypothequees \n");
            possessions.Sort();
            int i = 1;
            foreach(BuyableCase bc in this.possessions)
            {
                Console.Write("{0}. ", i);
                i++;
                bc.Display();
            }
            Console.WriteLine("\nEntrez le numero de la propriete que vous voulez gerer.. (0 pour retourner au menu de jeu)");
            bool verif2 = false;
            do
            {
                string answer = Console.ReadLine();
                if (answer == "0")
                {
                    return;
                }
                i = 1;
                bool verif = false;
                foreach (BuyableCase bc in this.possessions)
                {
                    if (i.ToString() == answer)
                    {
                        bc.Manage();
                        verif = true;
                        verif2 = true;
                    }
                    i++;
                }
                if (!verif)
                {
                    Console.WriteLine("Je n'ai pas compris..Veuillez reessayer");
                }
            } while (!verif2);
        }

        public void Taxe(uint amount)
        {
            if(this.money >= amount)
            {
                this.money = this.money - amount;
            }
            else
            {
                Board.Failure(this);
            }
        }

        public bool Equals(Player other)
        {
            return this.name.Equals(other.name);    
        }
    }
}
