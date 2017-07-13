using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Hacathon.Models;
using Hacathon.Services;

namespace Hacathon.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
