using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Case
    {
        private string name;
        public Borough borough;

        public string Name { get => name; set => name = value; }

        virtual public void Effect(Player p)
        {
            return;
        }

    }
}
