﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class CartItem
    {
        public int quantity { set; get; }
        public Products product { set; get; }
        public int total { get; set; }
    }
}
