using ApiEcommerce.Data;
using ApiEcommerce.Models;
using ApiEcommerce.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ApiEcommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool BuyProduct(string name, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name) || quantity <= 0)
            {
                return false;
            }

            var product = _db.Products.FirstOrDefault(p => p.Name.ToLower().Trim() == name.ToLower().Trim());

            if (product == null || product.Stock <= quantity)
            {
                return false;
            }

            product.Stock -= quantity;
            _db.Products.Update(product);
            return Save();
        }

        public bool CreateProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }

            product.CreationDate = DateTime.Now;
            product.UpdateDate = DateTime.Now;
            _db.Products.Add(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }

            _db.Products.Remove(product);
            return Save();
        }

        public Product? GetProduct(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return _db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        }

        public ICollection<Product> GetProducts()
        {
            return _db.Products.Include(p => p.Category).OrderBy(p => p.Name).ToList();
        }

        public ICollection<Product> GetProductsForCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return new List<Product>();
            }

            return _db.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId).OrderBy(p => p.Name).ToList();
        }

        public async Task<List<Product>> GetProductsInPages(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            return await _db.Products
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public int GetTotalProducts()
        {
            return _db.Products.Count();
        }

        public bool ProductExists(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }

            return _db.Products.Any(p => p.ProductId == id);
        }

        public bool ProductExists(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return _db.Products.Any(p => p.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public ICollection<Product> SearchProducts(string searchTerm)
        {
            IQueryable<Product> query = _db.Products;
            var seatchTermLowered = searchTerm.ToLower().Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Include(p => p.Category).Where(
                    p => p.Name.ToLower().Trim().Contains(seatchTermLowered) ||
                    p.Description.ToLower().Trim().Contains(seatchTermLowered));
            }
            return query.OrderBy(p => p.Name).ToList();
        }

        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }

            product.UpdateDate = DateTime.Now;
            _db.Products.Update(product);

            return Save();
        }
    }
}
