using System.Collections.Generic;
using WoodworkingWorkshop.Entities;
using WoodworkingWorkshop.Entities.Enums;

namespace WoodworkingWorkshop.Repositories.Implementations
{
    internal class MaterialRepository : IMaterialRepository
    {
        public void CreateMaterial(Material material) { }
        public void DeleteMaterial(int id) { }
        public Material ReadMaterialById(int id) => Material.CreateEntity(0, string.Empty, MaterialType.None, 0);
        public IEnumerable<Material> ReadMaterials() => [];
        public void UpdateMaterial(Material material) { }
    }
}