using System.Collections.Generic;
using Hacathon.Models;

namespace Hacathon.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}