using Microsoft.ILP.OrderRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.OrderBusiness.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
