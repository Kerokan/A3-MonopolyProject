using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class EventCase : Case
    {
        public uint taxe;

        public EventCase(uint _taxe, string _name)
        {
            taxe = _taxe;
            Name = _name;
        }

        public override void Effect(Player p)
        {
            Console.WriteLine("Vous devez payer {0} euros", this.taxe);
            p.Taxe((int)this.taxe);
            Console.ReadKey();
        }
    }
}
