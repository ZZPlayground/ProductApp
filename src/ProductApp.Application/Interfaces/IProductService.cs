using ProductApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<int> AddAsync(Product product);
    Task<int> UpdateAsync(Product product);
    Task<int> DeleteAsync(int id);
}