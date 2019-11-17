using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Station : BuyableCase
    {
        public Station(string _name, Borough _borough)
        {
            this.Name = _name;
            this.BuyPrice = 20000;
            this.Owner = null;
            this.MortgagePrice = (uint)10000;
            this.Borough = _borough;
        }

        override public void Effect(Player p)
        {
            if(this.Owner == null)
            {
                Board.PurchaseProposal(p, this);
            }
        }
    }
}
