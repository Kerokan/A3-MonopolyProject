using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public sealed class Board
    {
        private static readonly Lazy<Board> lazy = new Lazy<Board> (() => new Board());
        private static Case[] cases = new Case[40];

        public static Board Instance 
        {
            get 
            {
                return lazy.Value; 
            } 
        }

        private Board()
        {
            // TODO : Board init
        }

        public void PositionUpdate(Player player) 
        {
            cases[player.position].Effect(player);
        }
    }
}
