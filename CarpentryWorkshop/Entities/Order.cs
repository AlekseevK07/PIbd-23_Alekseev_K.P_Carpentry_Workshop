using System;

namespace WoodworkingWorkshop.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int EmployeeId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int Quantity { get; private set; }

        public static Order CreateOperation(int id, int productId, int employeeId, int quantity)
        {
            return new Order
            {
                Id = id,
                ProductId = productId,
                EmployeeId = employeeId,
                OrderDate = DateTime.Now,
                Quantity = quantity
            };
        }
    }
}