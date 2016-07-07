using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Price> Prices { get; set; }
    }
}
