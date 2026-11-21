namespace WoodworkingWorkshop.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public static Product CreateEntity(int id, string name, string desc)
        {
            return new Product
            {
                Id = id,
                Name = name ?? string.Empty,
                Description = desc ?? string.Empty
            };
        }
    }
}