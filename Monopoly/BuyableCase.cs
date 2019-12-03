using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class BuyableCase : Case, IComparable<BuyableCase>
    {
        private uint buyPrice;
        private Player owner;
        private uint mortgagePrice;
        private Borough borough;
        private bool isMort;

        private int houses = 0;
        private int hotel = 0;

        public Player Owner { get => owner; set => owner = value; }
        public uint MortgagePrice { get => mortgagePrice; set => mortgagePrice = value; }
        public uint BuyPrice { get => buyPrice; set => buyPrice = value; }
        public Borough Borough { get => borough; set => borough = value; }
        public bool IsMort { get => isMort; set => isMort = value; }
        public int Houses { get => houses; set => houses = value; }
        public int Hotel { get => hotel; set => hotel = value; }

        public bool Achat(Player p)
        {
            if(p.Money > buyPrice)
            {
                p.Money = p.Money - this.buyPrice;
                this.Owner = p;
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
            if (IsMort)
            {
                Console.WriteLine("{0} est actuellement hypothequee.", this.Name);
            }
            else
            {
                Console.WriteLine("{0} rapporte actuellement {1} euros", this.Name, this.Rent());
            }
        }

        public uint Rent()
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

        // abstract public void accept(Player p); // Visitor Pattern
    }
}
