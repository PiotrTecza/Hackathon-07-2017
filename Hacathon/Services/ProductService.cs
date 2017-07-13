using System;
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

            if (!string.IsNullOrEmpty(request?.CountryCode))
            {
                products = products.Where(x => String.Equals(x.ShippingCountryCode, request.CountryCode, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(request?.Gender))
            {
                products = products.Where(x => String.Equals(x.ProductGender, request.Gender, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            return products.OrderBy(x => x.InCountryRanking);
        }
    }
}