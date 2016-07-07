using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL
{
    public class PriceWatcherInitializer : DropCreateDatabaseIfModelChanges<PriceWatcherContext>
    {
        protected override void Seed(PriceWatcherContext context)
        {
            context.Products.Add(new Models.Product() { Name = "Roomba" });
            context.Products.Add(new Models.Product() { Name = "Iphone" });

            context.SaveChanges();
        }
    }
}
