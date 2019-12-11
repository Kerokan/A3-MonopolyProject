using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class BuyableCase : Case, IComparable<BuyableCase>
    {
        protected uint buyPrice;
        protected Player owner;
        protected uint mortgagePrice;
        private Borough borough;
        private bool isMort;

        public int houses = 0;
        public int hotel = 0;
        private uint housePrice;

        public Player Owner { get => owner; set => owner = value; }
        public uint MortgagePrice { get => mortgagePrice; set => mortgagePrice = value; }
        public uint BuyPrice { get => buyPrice; set => buyPrice = value; }
        public Borough Borough { get => borough; set => borough = value; }
        public bool IsMort { get => isMort; set => isMort = value; }
        public int Houses { get => houses; set => houses = value; }
        public int Hotel { get => hotel; set => hotel = value; }
        public uint HousePrice { get => housePrice; set => housePrice = value; }

        public bool Achat(Player p)
        {
            if(p.Money > buyPrice)
            {
                p.Money = p.Money - this.buyPrice;
                this.Owner = p;
                p.possessions.Add(this);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CompareTo(BuyableCase other)
        {
            return this.BuyPrice.CompareTo(other.BuyPrice);
        }

        public void Display()
        {
            if (this.IsMort)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(this.Name);
            Console.ResetColor();
        }

        virtual public uint Rent()
        {
            uint rent = 0;
            if (this.Borough.Monopoly())
            {
                bool verifMort = false;
                foreach(BuyableCase bc in this.Borough.cases)
                {
                    if (bc.IsMort)
                    {
                        verifMort = true;
                    }
                }
                if (!verifMort)
                {
                    rent = rent * 2;
                }
                if(this.hotel == 1)
                {

                }
                else
                {
                    
                }

            }
            return rent;
        }

        public void Manage()
        {
            Console.Clear();
            Console.WriteLine("{0} :\n\nLoyer : {1} euros", this.Name, this.Rent());
            if (this.IsMort)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hypothequee");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Disponible");
                Console.WriteLine("Constructions : \n\tMaisons : {0}\n\tHotel   : {1}", this.Houses, this.Hotel);
            }

            Console.WriteLine("\nQue voulez-vous faire ?");
            if (this.IsMort)
            {
                Console.WriteLine("1. Lever l'hypotheque");
                Console.WriteLine("0. Quitter");
                bool verif = false;
                while (!verif) 
                {
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            if(Owner.Money > this.MortgagePrice + this.MortgagePrice / 10)
                            {
                                Owner.Money = Owner.Money - (this.MortgagePrice + this.MortgagePrice / 10);
                                this.IsMort = false;
                                Console.WriteLine("L'hypotheque a ete levee");
                                verif = true;
                                this.Manage();
                            }
                            else
                            {
                                Console.WriteLine("Vous n'avez pas suffisamment d'argent pour lever l'hypotheque");
                                verif = true;
                                this.Manage();
                            }
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Je n'ai pas compris. Veuillez reessayer");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("1. Placer une hypotheque");
                if (this.Borough.Monopoly())
                {
                    if(this.houses < 4 && this.hotel < 1)
                    {
                        Console.WriteLine("2. Construire une maison");
                    }
                    else
                    {
                        if(this.houses == 4)
                        {
                            Console.WriteLine("2. Construire un hotel");
                        }
                    }
                }
                Console.WriteLine("0. Quitter");

                bool verif = false;
                while (!verif)
                {
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            this.IsMort = true;
                            this.Owner.Money = this.Owner.Money + this.MortgagePrice;
                            verif = true;
                            this.Manage();
                            break;

                        case "2":
                            if (this.Borough.Monopoly())
                            {
                                if (this.houses < 4 && this.hotel < 1)
                                {
                                    if(this.Owner.Money >= this.HousePrice)
                                    {
                                        this.Owner.Money = this.Owner.Money - this.HousePrice;
                                        this.Houses++;
                                        verif = true;
                                        this.Manage();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vous n'avez pas suffisamment d'argent.");
                                        verif = true;
                                        this.Manage();
                                        break;
                                    }
                                }
                                else
                                {
                                    if (this.houses == 4)
                                    {
                                        if (this.Owner.Money >= this.HousePrice)
                                        {
                                            this.Owner.Money = this.Owner.Money - this.HousePrice;
                                            this.Houses = 0;
                                            this.Hotel++;
                                            verif = true;
                                            this.Manage();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Vous n'avez pas suffisamment d'argent.");
                                            verif = true;
                                            this.Manage();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Je n'ai pas compris. Veuillez reessayer");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Je n'ai pas compris. Veuillez reessayer");
                            }
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Je n'ai pas compris. Veuillez reessayer");
                            break;
                    }
                }
            }
        }
    }
}
