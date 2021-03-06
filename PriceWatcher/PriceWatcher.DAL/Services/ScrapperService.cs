﻿using PriceWatcher.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PriceWatcher.DAL.Services
{
    public class ScrapperService
    {
        private static CultureInfo argentinaCulture = new CultureInfo("es-AR");
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

        public double GetValueFromPage(string url, ProductRetailerDTO productRetailerDTO)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                string html = String.Empty;
                using (StreamReader sr = new StreamReader(data))
                {
                    html = sr.ReadToEnd();
                }

                Match priceRegex = Regex.Match(html, productRetailerDTO.Regex, RegexOptions.Singleline);
                if (priceRegex.Success)
                {
                    var price = priceRegex.Groups[1].Value;
                    return double.Parse(price.Substring(productRetailerDTO.CharsToDeleteAtBeginning, price.Length - productRetailerDTO.CharsToDeleteAtBeginning), argentinaCulture);
                }
            } catch (Exception) { }

            return -1;
        }
    }
}
