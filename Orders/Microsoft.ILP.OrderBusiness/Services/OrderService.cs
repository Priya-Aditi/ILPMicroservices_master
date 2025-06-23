using Microsoft.ILP.OrderBusiness.Interfaces;
using Microsoft.ILP.OrderRepository;
using Microsoft.ILP.OrderRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.OrderBusiness.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public List<Order> GetAllOrders() => _repository.GetAll();

        public Order GetOrderById(int id) => _repository.GetById(id);

        public void CreateOrder(Order order) => _repository.Create(order);

        public void UpdateOrder(Order order) => _repository.Update(order);

        public void DeleteOrder(int id) => _repository.Delete(id);
    }
}
