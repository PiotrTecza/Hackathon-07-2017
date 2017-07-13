using System.Collections.Generic;
using System.Web;
using Hacathon.Models;
using Newtonsoft.Json;

namespace Hacathon.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            var path = HttpRuntime.AppDomainAppPath + "data/products.json";
            var allText = System.IO.File.ReadAllText(path);
            var products = JsonConvert.DeserializeObject<List<Product>>(allText);
            return products;
        }
    }
}