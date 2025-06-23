using Microsoft.ILP.ProductBusiness.Interfaces;
using Microsoft.ILP.ProductRepository;
using Microsoft.ILP.ProductRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.ProductBusiness.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProducts() => _repository.GetAll();

        public Product GetProductById(int id) => _repository.GetById(id);

        public void CreateProduct(Product product) => _repository.Create(product);

        public void UpdateProduct(Product product) => _repository.Update(product);

        public void DeleteProduct(int id) => _repository.Delete(id);
    }
}
