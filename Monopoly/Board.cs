using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public sealed class Board
    {
        private static readonly Lazy<Board> lazy = new Lazy<Board> (() => new Board());
        private static Case[] cases = new Case[40];
        private static Player[] players;

        public static Board Instance 
        {
            get 
            {
                return lazy.Value; 
            } 
        }

        private Board()
        {
            // Creation of the players
            Console.WriteLine("Combien de joueurs vont participer ? (Entre 2 et 9)");
            bool verif = false;
            int nbPlayers = 0;
            while (!verif)
            {
                string response = Console.ReadLine();
                try
                {
                    nbPlayers = int.Parse(response);
                    if(nbPlayers < 10 && nbPlayers > 1)
                        verif = true;
                    else
                        Console.WriteLine("Veuillez rentrer un nombre entre 2 et 9");
                }
                catch 
                {
                    Console.WriteLine("Veuillez rentrer un nombre entre 2 et 9");
                }
            }

            Console.WriteLine("Nous allons desormais enregistrer les joueurs.");
            players = new Player[nbPlayers];

            for(int i = 0; i < nbPlayers; i++)
            {
                Console.WriteLine("Quel est le nom du joueur {0}", i + 1);
                string name = Console.ReadLine();

                players[i] = new Player(name);
            }

            // Creation of the board / cases / Borough
            cases[0] = new Start();
            Borough DBlue = new Borough(2);
            cases[1] = new Street("Boulevard de Belleville", 6000, 3000, DBlue);
            DBlue.cases.Add(cases[1]);
            cases[2] = new CommunityFund();
            cases[3] = new Street("Rue Lecourbe", 6000, 3000, DBlue);
            DBlue.cases.Add(cases[3]);
            cases[4] = new EventCase(20000, "Impots sur le revenu");
            Borough Stations = new Borough(4);
            cases[5] = new Station("Gare Montparnasse", Stations);
            Stations.cases.Add(cases[5]);
            Borough Cyan = new Borough(3);
            cases[6] = new Street("Rue de Vaugirard", 10000, 5000, Cyan);
            Cyan.cases.Add(cases[6]);
            cases[7] = new ChanceCard();
            cases[8] = new Street("Rue de Courcelles", 10000, 5000, Cyan);
            Cyan.cases.Add(cases[7]);
            cases[9] = new Street("Avenue de la République", 12000, 6000, Cyan);
            Cyan.cases.Add(cases[8]);
            cases[10] = new Jail();
            Borough Purple = new Borough(3);
            cases[11] = new Street("Boulevard de la Villette", 14000, 7000, Purple);
            Purple.cases.Add(cases[11]);
            Borough Company = new Borough(2);
            cases[12] = new Company("Compagnie de distribution d'electricite", Company);
            Company.cases.Add(cases[12]);
            cases[13] = new Street("Avenue de Neuilly", 14000, 7000, Purple);
            Purple.cases.Add(cases[13]);
            cases[14] = new Street("Rue de Paradis", 16000, 8000, Purple);
            Purple.cases.Add(cases[14]);
            cases[15] = new Station("Gare de Lyon", Stations);
            Stations.cases.Add(cases[15]);
            Borough Orange = new Borough(3);
            cases[16] = new Street("Avenue Mozart", 18000, 9000, Orange);
            Orange.cases.Add(cases[16]);
            cases[17] = new CommunityFund();
            cases[18] = new Street("Boulevard St Michel", 18000, 9000, Orange);
            Orange.cases.Add(cases[18]);
            cases[19] = new Street("Place Pigalle", 20000, 10000, Orange);
            Orange.cases.Add(cases[19]);
            cases[20] = new FreeParking();
            Borough Red = new Borough(3);
            cases[21] = new Street("Avenue Matignon", 22000, 11000, Red);
            Red.cases.Add(cases[21]);
            cases[22] = new ChanceCard();
            cases[23] = new Street("Boulevard Malesherbes", 22000, 11000, Red);
            Red.cases.Add(cases[23]);
            cases[24] = new Street("Avenue Henri Martin", 24000, 12000, Red);
            Red.cases.Add(cases[24]);
            cases[25] = new Station("Gare du Nord", Stations);
            Stations.cases.Add(cases[25]);
            Borough Yellow = new Borough(3);
            cases[26] = new Street("Faubourg Saint Honore", 26000, 13000, Yellow);
            Yellow.cases.Add(cases[26]);
            cases[27] = new Street("Place de la Bourse", 26000, 13000, Yellow);
            Yellow.cases.Add(cases[27]);
            cases[28] = new Company("Compagnie de distribution des eaux", Company);
            Company.cases.Add(cases[28]);
            cases[29] = new Street("Rue Lafayette", 28000, 14000, Yellow);
            Yellow.cases.Add(cases[29]);
            cases[30] = new GoToJail();
            Borough Green = new Borough(3);
            cases[31] = new Street("Avenue de Breteuil", 30000, 15000, Green);
            Green.cases.Add(cases[31]);
            cases[32] = new Street("Avenue Foch", 30000, 15000, Green);
            Green.cases.Add(cases[32]);
            cases[33] = new CommunityFund();
            cases[34] = new Street("Boulevard des Capucines", 32000, 16000, Green);
            Green.cases.Add(cases[34]);
            cases[35] = new Station("Gare St Lazare", Stations);
            Stations.cases.Add(cases[35]);
            cases[36] = new ChanceCard();
            Borough Blue = new Borough(2);
            cases[37] = new Street("Boulevard des Champs-Elysees", 35000, 17500, Blue);
            Blue.cases.Add(cases[37]);
            cases[38] = new EventCase(10000, "Taxe de Luxe");
            cases[39] = new Street("Rue de la Paix", 40000, 20000, Blue);
            Blue.cases.Add(cases[39]);
        }

        public void PositionUpdate(Player player) 
        {
            cases[player.position].Effect(player);
        }

        public static void PurchaseProposal(Player p, BuyableCase bc)
        {
            Console.WriteLine("{0}, voulez-vous acheter {1} pour le prix de {2} euros ? [y]Oui [n]Non", p.Name, bc.Name, bc.BuyPrice);
            bool verif = false;
            while (!verif)
            {
                string response = Console.ReadLine();
                switch (response[0])
                {
                    case 'y':
                        if (bc.Achat(p))
                        {
                            Console.WriteLine("Felicitations, {0} ! Vous avez acheter cette propriete. Votre solde actuel est de {1}", p.Name, p.Money);
                        }
                        else
                        {
                            Console.WriteLine("Vous n'avez pas suffisamment d'argent. Les encheres vont commencer...");
                            Board.Auctions(bc);
                        }
                        verif = true;
                        break;

                    case 'n':
                        Console.WriteLine("Dans ce cas, les encheres vont commencer...");
                        Board.Auctions(bc);
                        verif = true;
                        break;

                    default:
                        Console.WriteLine("Je n'ai pas compris votre choix... Veuillez reessayer");
                        break;
                }
            }
        }

        static void Auctions(BuyableCase bc)
        {
            uint actualPrice = bc.BuyPrice / 2;
            Console.WriteLine("Encheres : Le prix de depart est {0}", actualPrice);
            bool[] participate = new bool[players.Length];
            int participants = 0;
            for(int i = 0; i < players.Length - 1; i++)
            {
                Console.WriteLine("{0}, voulez-vous participer ? [y]Oui [n]Non", players[i].Name);
                bool verif = false;
                while (!verif)
                {
                    string response = Console.ReadLine();
                    switch (response[0])
                    {
                        case 'y':
                            if(players[i].Money > actualPrice)
                            {
                                participate[i] = true;
                                participants++;
                            }
                            else
                            {
                                Console.WriteLine("Vous ne possedez pas suffisamment d'argent.");
                                participate[i] = false;
                            }
                            break;

                        case 'n':
                            participate[i] = false;
                            break;

                        default:
                            Console.WriteLine("Je n'ai pas compris votre choix... Veuillez reessayer");
                            break;
                    }
                }
            }

            Player leader = null;
            int actualParticipant = 0;
            while (participants > 1)
            {
                if(leader == null)
                {
                    if (participate[actualParticipant])
                    {
                        leader = players[actualParticipant];
                        actualParticipant = (actualParticipant + 1) % players.Length;
                    }
                    else
                    {
                        actualParticipant = (actualParticipant + 1) % players.Length;
                    }
                }
                else
                {
                    if (participate[actualParticipant])
                    {
                        Console.WriteLine("Le leader actuel est {0} avec une offre de {1} euros", leader.Name, actualPrice);
                        Console.WriteLine("{0}, combien voulez-vous proposer pour {1} ? (Entrez 0 pour abandonner l'enchere)", players[actualParticipant].Name, bc.Name);
                        Console.WriteLine("Pour rappel, votre solde actuel est de {0}", players[actualParticipant].Money);
                        bool verif = false;
                        while (!verif)
                        {
                            string response = Console.ReadLine();
                            int offer;
                            if(int.TryParse(response, out offer))
                            {
                                if(offer <= actualPrice)
                                {
                                    if(offer == 0)
                                    {
                                        Console.WriteLine("Vous avez ete retire de l'enchere.");
                                        participate[actualParticipant] = false;
                                        participants--;
                                        verif = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Votre offre est trop faible. Veuillez reessayer.");
                                    }
                                }
                                else
                                {
                                    if(players[actualParticipant].Money >= offer)
                                    {
                                        Console.WriteLine("Votre offre a bien ete enregistree. Vous etes le nouveau leader.");
                                        leader = players[actualParticipant];
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vous n'avez pas suffisamment d'argent pour cette offre. Veuillez reessayer.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Veuillez n'ecrire que la valeur en chiffre que vous souhaitez proposer.");
                            }
                        }
                        actualParticipant = (actualParticipant + 1) % players.Length;
                    }
                    else
                    {
                        actualParticipant = (actualParticipant + 1) % players.Length;
                    }
                }
            }

            if(participants == 0)
            {
                Console.WriteLine("L'enchere a ete annulee faute de partcipants.");
            }

            if(participants == 1)
            {
                Player winner = null;
                for(int i = 0; i < participate.Length - 1; i++)
                {
                    if (participate[i])
                    {
                        winner = players[i];
                    }
                }
                Console.WriteLine("L'enchere a ete remportee par {0}, qui devient le proprietaire de {1} pour le prix de {2}", winner.Name, bc.Name, actualPrice);
                winner.Money = winner.Money - actualPrice;
                bc.Owner = winner;
            }
        }
        static void Failure(Player p)
        {
            Console.WriteLine("{0} a perdu.", p.Name);
            Player[] players2 = new Player[players.Length - 1];
            int j = 0;
            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].Equals(p))
                {
                    players2[j] = players[i];
                    j++;
                }
            }

            players = players2;
        }
    }
}
