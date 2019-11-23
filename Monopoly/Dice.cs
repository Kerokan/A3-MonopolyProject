using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Dice
    {
        Random rand;

        public Dice()
        {
            rand = new Random();
        }
        public ushort[] Roll()
        {
            ushort[] ret = new ushort[] { (ushort)rand.Next(1,7), (ushort)rand.Next(1, 7) };
            return ret;
        }
    }
}
