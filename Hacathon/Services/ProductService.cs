using System.Collections.Generic;
using System.Linq;
using Hacathon.Models;
using Hacathon.Repositories;

namespace Hacathon.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(RequestModel request)
        {
            var products = _productRepository.GetProducts();

            return products.Where(x => CompareProduct(x, request)).OrderBy(x => x.InCountryRanking);
        }

        private static bool CompareProduct(Product product, RequestModel request)
        {
            if (!string.IsNullOrEmpty(request?.CountryCode) &&
                product.ShippingCountryCode != request.CountryCode) return false;
            return string.IsNullOrEmpty(request?.Gender) || product.ProductGender == request.Gender;
        }
    }
}