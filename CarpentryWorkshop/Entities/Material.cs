using WoodworkingWorkshop.Entities.Enums;

namespace WoodworkingWorkshop.Entities
{
    public class Material
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public MaterialType MaterialType { get; private set; }
        public double QuantityInStock { get; private set; }

        public static Material CreateEntity(int id, string name, MaterialType type, double qty)
        {
            return new Material
            {
                Id = id,
                Name = name ?? string.Empty,
                MaterialType = type,
                QuantityInStock = qty
            };
        }
    }
}