using System.Collections.Generic;
using System.Threading.Tasks;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Interfaces;

namespace RetailCloud.Application.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;

        public ProductService(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsByBarcode(string barcode)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}