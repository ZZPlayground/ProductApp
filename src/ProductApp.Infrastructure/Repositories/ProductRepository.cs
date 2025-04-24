using Dapper;
using ProductApp.Domain;
using ProductApp.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var sql = "SELECT * FROM ProductApp.Products ORDER BY CreatedDate DESC";
        return await _dbConnection.QueryAsync<Product>(sql);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM ProductApp.Products WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
    }

    public async Task<int> AddAsync(Product product)
    {
        var sql = @"
                INSERT INTO ProductApp.Products (Name, Description, Price, Status, Category, Quantity, CreatedDate)
                VALUES (@Name, @Description, @Price, @Status, @Category, @Quantity, @CreatedDate);";
        return await _dbConnection.ExecuteAsync(sql, product);
    }

    public async Task<int> UpdateAsync(Product product)
    {
        product.UpdatedDate = DateTime.UtcNow;
        var sql = @"
                UPDATE ProductApp.Products
                SET Name = @Name, Description = @Description, Price = @Price,
                    Status = @Status, Category = @Category, Quantity = @Quantity,
                    UpdatedDate = @UpdatedDate
                WHERE Id = @Id;";
        return await _dbConnection.ExecuteAsync(sql, product);
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM ProductApp.Products WHERE Id = @Id";
        return await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}