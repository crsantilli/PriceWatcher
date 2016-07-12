using PriceWatcher.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Services
{
    public class ProductRetailerService
    {
        private static ProductRetailerService instance;
        private ProductRetailerService() { }
        public static ProductRetailerService Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductRetailerService();
                return instance;
            }
        }

        public ProductRetailerDTO ConvertToDto(ProductRetailer entity)
        {
            ProductRetailerDTO dto = new ProductRetailerDTO()
            {
                ID = entity.ID,
                UrlTail = entity.UrlTail,
                Regex = entity.Regex,
                CharsToDeleteAtBeginning = (int)entity.CharsToDeleteAtBeginning,
                RetailerDTO = RetailerService.Instance.ConvertToDTO(entity.Retailer)
            };

            return dto;
        }
    }
}
