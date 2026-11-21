using System.Collections.Generic;
using WoodworkingWorkshop.Entities;

namespace WoodworkingWorkshop.Repositories.Implementations
{
    internal class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order) { }
        public IEnumerable<Order> ReadOrders() => [];
    }
}