using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.DTOs
{
    public class ProductRetailerDTO
    {
        public long ID { get; set; }
        public RetailerDTO RetailerDTO { get; set; }
        public string UrlTail { get; set; }
        public string Regex { get; set; }
        public int CharsToDeleteAtBeginning { get; set; }
    }
}
