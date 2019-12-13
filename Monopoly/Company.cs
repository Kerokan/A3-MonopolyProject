using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Company : BuyableCase
    {
        public Company(string _name, Borough _borough)
        {
            this.Name = _name;
            this.BuyPrice = 15000;
            this.Owner = null;
            this.MortgagePrice = (uint)7500;
            this.Borough = _borough;
        }

        override public void Effect(Player p)
        {
            if (this.Owner == null)
            {
                Board.PurchaseProposal(p, this);
            }
            else
            {
                if (this.Owner.Equals(p))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Le montant du loyer est : {0}", this.Rent());
                    this.Owner.Money = (int)(this.Owner.Money + this.Rent());
                    p.Taxe((int)this.Rent());
                }
            }
        }

        override public uint Rent()
        {
            int value = 7;
            int multiplier = 0;
            foreach(Company company in this.Borough.cases)
            {
                if (company.Owner.Equals(this.Owner))
                {
                    if(multiplier == 0)
                    {
                        multiplier = 400;
                    }
                    else
                    {
                        multiplier = 1000;
                    }
                }
            }

            return (uint)(value * multiplier);
        }
    }
}
