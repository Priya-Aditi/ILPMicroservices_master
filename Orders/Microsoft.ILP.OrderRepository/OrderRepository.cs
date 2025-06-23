using Microsoft.ILP.OrderRepository.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Microsoft.ILP.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private const string FilePath = "OrderData/orders.json";

        public List<Order> GetAll()
        {
            if (!File.Exists(FilePath)) return new List<Order>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
        }

        public Order GetById(int id) => GetAll().FirstOrDefault(o => o.Id == id);

        public void Create(Order order)
        {
            var orders = GetAll();
            order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
            orders.Add(order);
            Save(orders);
        }

        public void Update(Order order)
        {
            var orders = GetAll();
            var index = orders.FindIndex(o => o.Id == order.Id);
            if (index != -1)
            {
                orders[index] = order;
                Save(orders);
            }
        }

        public void Delete(int id)
        {
            var orders = GetAll();
            orders.RemoveAll(o => o.Id == id);
            Save(orders);
        }

        private void Save(List<Order> orders)
        {
            Directory.CreateDirectory("OrderData");
            var json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
