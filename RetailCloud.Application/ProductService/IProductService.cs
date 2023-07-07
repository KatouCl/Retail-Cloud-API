using System.Collections.Generic;
using System.Threading.Tasks;
using RetailCloud.Core.Entities;

namespace RetailCloud.Application.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsByBarcode(string barcode);
    }
}