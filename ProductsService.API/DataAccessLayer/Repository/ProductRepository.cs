using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContract;
using eCommerce.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product?> AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.ProductID == productId);
        if (product != null) { return false; }
        _dbContext.Products.Remove(product);
        int affectedCount = await _dbContext.SaveChangesAsync();
        return affectedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }


    public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(conditionExpression);
    }

    public async Task<IEnumerable<Product>?> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
    {
        return await _dbContext.Products.Where(conditionExpression).ToListAsync();
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        var productExisit = await _dbContext.Products.FirstOrDefaultAsync(product => product.ProductID == product.ProductID);
        if (product != null) { return null; }
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}
