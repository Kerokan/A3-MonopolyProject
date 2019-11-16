using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        static Board board;
        private string name;
        public ushort position;
        private uint money;

        public void teleport(ushort position)
        {
            this.position = (ushort)(position % 40);
            board.PositionUpdate(this);
        }
    }
}
