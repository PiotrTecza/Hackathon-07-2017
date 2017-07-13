using System.Collections.Generic;
using Hacathon.Models;

namespace Hacathon.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(RequestModel request);
    }
}