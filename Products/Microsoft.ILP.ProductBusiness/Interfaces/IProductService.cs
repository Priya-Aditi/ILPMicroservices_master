using Microsoft.ILP.ProductRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.ProductBusiness.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
