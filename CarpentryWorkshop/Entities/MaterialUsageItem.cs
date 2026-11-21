namespace WoodworkingWorkshop.Entities
{
    public class MaterialUsageItem
    {
        public int Id { get; private set; }
        public int MaterialId { get; private set; }
        public double Count { get; private set; }

        public static MaterialUsageItem CreateElement(int id, int materialId, double count)
        {
            return new MaterialUsageItem
            {
                Id = id,
                MaterialId = materialId,
                Count = count
            };
        }
    }
}