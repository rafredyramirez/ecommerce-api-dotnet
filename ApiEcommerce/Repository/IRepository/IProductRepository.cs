using ApiEcommerce.Models;

namespace ApiEcommerce.Repository.IRepository
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Task<List<Product>> GetProductsInPages(int pageNumber, int pageSize);
        int GetTotalProducts();
        ICollection<Product> GetProductsForCategory(Guid categoryId);
        ICollection<Product> SearchProducts(string searchTerm);
        Product? GetProduct(Guid id);
        bool BuyProduct(string name, int quantity);
        bool ProductExists(Guid id);
        bool ProductExists(string name);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
