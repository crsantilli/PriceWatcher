using PriceWatcher.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Services
{
    public class ProductService
    {
        private static ProductService instance;
        private ProductService() { }
        public static ProductService Instance
        {
            get
            {
                if (instance == null)                
                    instance = new ProductService();                
                return instance;
            }
        }

        public void Add(ProductDTO productDTO)
        {
            using (var context = new PriceWatcherEntities())
            {
                Product product = new Product()
                {
                    Name = productDTO.Name
                };

                context.Products.Add(product);
                context.SaveChangesAsync();
            }
        }

        public List<ProductDTO> GetAll()
        {
            using (var context = new PriceWatcherEntities())
            {
                return context.Products.AsEnumerable().Select(x => ConvertToDTO(x)).ToList();
            }
        }

        public ProductDTO ConvertToDTO(Product entity)
        {
            ProductDTO dto = new ProductDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                ProductRetailerDTOs = entity.ProductRetailers.Select(x => ProductRetailerService.Instance.ConvertToDto(x)).ToList()
            };

            return dto;
        }
    }
}
