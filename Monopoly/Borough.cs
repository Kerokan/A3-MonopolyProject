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
        public List<Case> cases;
        public ConsoleColor color;

        public Borough(int _length, ConsoleColor _color)
        {
            length = _length;
            cases = new List<Case>();
            color = _color;
        }

        public Player Monopoly()
        {
            return null;
            // TODO : Verify if the borough is owned by the same player on all the cases
        }
    }
}
