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
    }
}
