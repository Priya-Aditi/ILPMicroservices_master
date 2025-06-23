using Microsoft.ILP.ProductRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.ProductRepository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
