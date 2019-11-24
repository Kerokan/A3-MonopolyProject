using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityFund : Case
    {
        protected Dictionary<int, Func<Player, bool>> myDicti = new Dictionary<int, Func<Player, bool>>();
        static Random rand = new Random();
        public CommunityFund()
        {
            Name = "Community Fund";
            
        }

        override public void Effect(Player p)
        {
            int effect = rand.Next(1, 16);
            myDicti[effect](p);
        }

        

    }
}
