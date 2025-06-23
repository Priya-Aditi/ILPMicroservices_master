using Microsoft.ILP.OrderRepository.Models;
using System.Collections.Generic;

namespace Microsoft.ILP.OrderRepository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
