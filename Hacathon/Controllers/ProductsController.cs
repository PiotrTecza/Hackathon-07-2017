using System.Collections.Generic;
using System.Web.Http;
using Hacathon.Models;
using Hacathon.Services;

namespace Hacathon.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Route("api/Products")]
        public IEnumerable<Product> Get([FromUri] RequestModel request)
        {
            var products = productService.GetProducts(request);
            return products;
        }
    }
}
