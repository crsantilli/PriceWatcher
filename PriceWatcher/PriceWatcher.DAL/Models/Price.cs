﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Models
{
    public class Price
    {
        public decimal Value { get; set; }
        public Retailer Retailer { get; set; }

    }
}
