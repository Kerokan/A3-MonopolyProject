﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class BuyableCase : Case
    {
        public int buyPrice;
        // Player owner;

        // abstract public void accept(Player p); // Visitor Pattern
    }
}