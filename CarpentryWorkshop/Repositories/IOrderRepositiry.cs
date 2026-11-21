using System.Collections.Generic;
using WoodworkingWorkshop.Entities;

namespace WoodworkingWorkshop.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> ReadOrders();
        void CreateOrder(Order order);
    }
}