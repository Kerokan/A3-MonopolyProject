using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Station : BuyableCase
    {
        public Station(string _name, int _buyPrice)
        {
            this.name = _name;
            this.buyPrice = _buyPrice;
        }
    }
}
