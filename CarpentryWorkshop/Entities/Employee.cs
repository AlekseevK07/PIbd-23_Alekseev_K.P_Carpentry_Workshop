using WoodworkingWorkshop.Entities.Enums;

namespace WoodworkingWorkshop.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public EmployeePost EmployeePost { get; private set; }

        public static Employee CreateEntity(int id, string first, string last, EmployeePost post)
        {
            return new Employee
            {
                Id = id,
                FirstName = first ?? string.Empty,
                LastName = last ?? string.Empty,
                EmployeePost = post
            };
        }
    }
}