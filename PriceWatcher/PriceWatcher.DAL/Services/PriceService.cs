using PriceWatcher.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Services
{
    public class PriceService
    {
        private static PriceService instance;
        private PriceService() { }
        public static PriceService Instance
        {
            get
            {
                if (instance == null)
                    instance = new PriceService();
                return instance;
            }
        }

        public void UpdatePrices()
        {
            List<ProductDTO> products = ProductService.Instance.GetAll();
            
            using (var context = new PriceWatcherEntities())
            {
                foreach (var product in products)
                {
                    foreach (var productRetailer in product.ProductRetailerDTOs)
                    {
                        //Retrieve value from web page.
                        string url = productRetailer.RetailerDTO.Url + productRetailer.UrlTail;
                        double currentPrice = ScrapperService.Instance.GetValueFromPage(url, productRetailer.Regex);

                        context.Prices.Add(new Price()
                        {
                            ProductRetailerID = productRetailer.ID,
                            Timestamp = DateTime.UtcNow.ToString(),
                            Value = currentPrice
                        });
                    }
                }

                context.SaveChangesAsync();
            }
        }
    }
}
