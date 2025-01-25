using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace DataAccessLayer.RepositoryContract;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<IEnumerable<Product>?> GetProductsByCondition(Expression<Func<Product,bool>> conditionExpression);
    Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);
    Task<Product?> AddProduct(Product product);
    Task<Product?> UpdateProduct(Product product);
    Task<bool> DeleteProduct(Guid productId);
}
