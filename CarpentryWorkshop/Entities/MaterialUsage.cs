using System;
using System.Collections.Generic;

namespace WoodworkingWorkshop.Entities
{
    public class MaterialUsage
    {
        public int Id { get; private set; }
        public int EmployeeId { get; private set; }
        public DateTime UsageDate { get; private set; }
        public IEnumerable<MaterialUsageItem> MaterialUsageItems { get; private set; }

        public static MaterialUsage CreateOperation(int id, int employeeId, IEnumerable<MaterialUsageItem> items)
        {
            return new MaterialUsage
            {
                Id = id,
                EmployeeId = employeeId,
                UsageDate = DateTime.Now,
                MaterialUsageItems = items
            };
        }
    }
}