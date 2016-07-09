using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.DTOs
{
    public class ProductDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public List<ProductRetailerDTO> ProductRetailerDTOs { get; set; }
    }
}
