using System;
using System.Collections;
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
        public bool inJail;
        public List<BuyableCase> possessions;

        public string Name { get => name; set => name = value; }
        public uint Money { get => money; set => money = value; }

        public Player(string _name)
        {
           // board = Board.Instance;
            name = _name;
            position = 0;
            money = 150000;
            inJail = false;
            possessions = new List<BuyableCase>();
        }

        /// <summary>
        /// Roll the dices, move the player and trigger effetcs
        /// If it's a double, play again
        /// Player will go to jail after 3 consecutive double
        /// </summary>
        public void Play() 
        {
            ushort[] dices;
            ushort combo;

            combo = 3;
            do
            {
                dices = board.dices.Roll();
                combo--;
                this.Forward((ushort)(dices[0] + dices[1]));
            }
            while (dices[0] == dices[1]);
            if (combo == 0)
                this.teleport(30);
        }

        public void Backward(ushort value) 
        {
            this.teleport((ushort)((position - value)%40));
        }

        public void Forward(ushort value) 
        {
            if (position + value > 39)
                money += 20000;
            this.teleport((ushort)(position + value));
        }
        public void teleport(ushort position)
        {
            this.position = (ushort)(position % 40);
            board.PositionUpdate(this);
        }
    }
}
