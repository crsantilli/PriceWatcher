using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Services
{
    public class ScrapperService
    {
        private static ScrapperService instance;
        private ScrapperService() { }
        public static ScrapperService Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScrapperService();
                return instance;
            }
        }

        public double GetValueFromPage(string url)
        {
            return 100;
        }
    }
}
