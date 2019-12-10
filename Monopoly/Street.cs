using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Street : BuyableCase
    {

        public Street(string _name, uint _buyPrice, uint _mortgagePrice, Borough _borough)
        {
            this.Name = _name;
            this.BuyPrice = _buyPrice;
            this.Owner = null;
            this.MortgagePrice = _mortgagePrice;
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
                    //Paiement !
                }
            }
        }
    }
}
