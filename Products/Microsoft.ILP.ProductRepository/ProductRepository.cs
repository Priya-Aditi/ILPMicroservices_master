using Microsoft.ILP.ProductRepository.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Microsoft.ILP.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private const string FilePath = "ProductData/products.json";

        public List<Product> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<Product>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public Product GetById(int id) => GetAll().FirstOrDefault(p => p.Id == id);

        public void Create(Product product)
        {
            var products = GetAll();
            product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            Save(products);
        }

        public void Update(Product product)
        {
            var products = GetAll();
            var index = products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                products[index] = product;
                Save(products);
            }
        }

        public void Delete(int id)
        {
            var products = GetAll();
            products.RemoveAll(p => p.Id == id);
            Save(products);
        }

        private void Save(List<Product> products)
        {
            Directory.CreateDirectory("ProductData");
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
