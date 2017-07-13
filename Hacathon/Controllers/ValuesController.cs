using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Hacathon.Models;
using Newtonsoft.Json;

namespace Hacathon.Controllers
{
    public class ValuesController : ApiController
    {
        public List<Product> Get([FromUri] RequestModel request)
        {
            var path = HttpRuntime.AppDomainAppPath+ "data/products.json";
            string allText = System.IO.File.ReadAllText(path);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(allText);


            if (!string.IsNullOrEmpty(request.CountryCode))
            {
                products = products.Where(x => String.Equals(x.ShippingCountryCode, request.CountryCode, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(request.Gender))
            {
                products = products.Where(x => String.Equals(x.ProductGender, request.Gender, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            return products;
        }
    }
}
