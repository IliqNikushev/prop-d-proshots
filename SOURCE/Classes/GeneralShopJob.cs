﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class GeneralShopJob : ShopJob
    {
        public GeneralShopJob(int id, string label, string description, int x, int y) : base(id, label, description, x, y) { }
    }
}