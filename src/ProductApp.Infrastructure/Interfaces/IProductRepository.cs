using ProductApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<int> AddAsync(Product product);
    Task<int> UpdateAsync(Product product);
    Task<int> DeleteAsync(int id);
}
