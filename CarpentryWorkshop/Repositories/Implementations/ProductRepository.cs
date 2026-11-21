using System.Collections.Generic;
using WoodworkingWorkshop.Entities;

namespace WoodworkingWorkshop.Repositories.Implementations
{
    internal class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product product) { }
        public void DeleteProduct(int id) { }
        public Product ReadProductById(int id) => Product.CreateEntity(0, string.Empty, string.Empty);
        public IEnumerable<Product> ReadProducts() => [];
        public void UpdateProduct(Product product) { }
    }
}