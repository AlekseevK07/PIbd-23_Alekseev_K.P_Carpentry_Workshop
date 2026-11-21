using System;
using System.Collections.Generic;
using WoodworkingWorkshop.Entities;

namespace WoodworkingWorkshop.Repositories
{
    public interface IMaterialUsageRepository
    {
        IEnumerable<MaterialUsage> ReadMaterialUsages(DateTime? dateForm = null, DateTime? dateTo = null, int? employeeId = null, int? materialId = null);
        void CreateMaterialUsage(MaterialUsage materialUsage);
        void DeleteMaterialUsage(int id);
    }
}