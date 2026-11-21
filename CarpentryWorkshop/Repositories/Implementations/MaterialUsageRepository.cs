using System;
using System.Collections.Generic;
using WoodworkingWorkshop.Entities;

namespace WoodworkingWorkshop.Repositories.Implementations
{
    internal class MaterialUsageRepository : IMaterialUsageRepository
    {
        public void CreateMaterialUsage(MaterialUsage materialUsage) { }
        public void DeleteMaterialUsage(int id) { }
        public IEnumerable<MaterialUsage> ReadMaterialUsages(DateTime? dateForm = null, DateTime? dateTo = null, int? employeeId = null, int? materialId = null) => [];
    }
}