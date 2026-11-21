using System.Collections.Generic;
using WoodworkingWorkshop.Entities;

namespace WoodworkingWorkshop.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> ReadEmployees();
        Employee ReadEmployeeById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}