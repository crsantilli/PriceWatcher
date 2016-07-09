using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.DTOs
{
    public class PriceDTO
    {
        public long ID { get; set; }
        public decimal Value { get; set; }
        public DateTime Timestamp { get; set; }
        public ProductRetailerDTO ProductRetailerDTO { get; set; }
    }
}
