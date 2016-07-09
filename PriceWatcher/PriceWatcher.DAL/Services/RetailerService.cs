using PriceWatcher.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Services
{
    public class RetailerService
    {
        private static RetailerService instance;
        private RetailerService() { }
        public static RetailerService Instance
        {
            get
            {
                if (instance == null)                
                    instance = new RetailerService();                
                return instance;
            }
        }

        public void Add(RetailerDTO retailerDTO)
        {
            using (var context = new PriceWatcherEntities())
            {
                Retailer retailer = new Retailer()
                {
                    Name = retailerDTO.Name
                };

                context.Retailers.Add(retailer);
                context.SaveChangesAsync();
            }
        }

        public List<RetailerDTO> GetAll()
        {
            using (var context = new PriceWatcherEntities())
            {
                return context.Retailers.AsEnumerable().Select(x => ConvertToDTO(x)).ToList();
            }
        }

        public RetailerDTO ConvertToDTO(Retailer entity)
        {
            RetailerDTO dto = new RetailerDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                Url = entity.Url
            };

            return dto;
        }
    }
}
