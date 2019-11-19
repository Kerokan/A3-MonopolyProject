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
        public CommunityFund()
        {
            Name = "Community Fund";
            try
            {
                
            }catch(Exception e)
            {

            }
        }

        override public void Effect(Player p)
        {
            Random rand = new Random();
            
        }

        

    }
}
