using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class BuyableCase : Case
    {
        private uint buyPrice;
        private Player owner;
        private uint mortgagePrice;

        public Player Owner { get => owner; set => owner = value; }
        public uint MortgagePrice { get => mortgagePrice; set => mortgagePrice = value; }
        public uint BuyPrice { get => buyPrice; set => buyPrice = value; }
        public Borough Borough { get => borough; set => borough = value; }

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

        // abstract public void accept(Player p); // Visitor Pattern
    }
}
