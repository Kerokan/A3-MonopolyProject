using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Borough
    {
        public int length;
        public List<BuyableCase> cases;
        public ConsoleColor color;
        public uint housePrice;

        public Borough(int _length, ConsoleColor _color, uint _housePrice)
        {
            length = _length;
            cases = new List<BuyableCase>();
            color = _color;
            housePrice = _housePrice;
        }

        public bool Monopoly()
        {
            bool monopoly = true;
            Player p = this.cases[0].Owner;
            if(p != null)
            {
                foreach (BuyableCase bc in this.cases)
                {
                    if (!p.Equals(bc.Owner) || bc.IsMort)
                    {
                        monopoly = false;
                    }
                }
            }
            else
            {
                monopoly = false;
            }
            try
            {
                Station s = (Station)this.cases[0];
                monopoly = false;
            }catch(InvalidCastException ice)
            {
            }
            try
            {
                Company s = (Company)this.cases[0];
                monopoly = false;
            }
            catch (InvalidCastException ice)
            {
            }
            return monopoly;
        }
    }
}
