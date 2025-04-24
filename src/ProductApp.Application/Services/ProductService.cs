using ProductApp.Domain;
using ProductApp.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.Application.Interfaces;

namespace ProductApp.Application.Services;


public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IEnumerable<Product>> GetAllAsync() => _productRepository.GetAllAsync();
    public Task<Product> GetByIdAsync(int id) => _productRepository.GetByIdAsync(id);
    public Task<int> AddAsync(Product product) => _productRepository.AddAsync(product);
    public Task<int> UpdateAsync(Product product) => _productRepository.UpdateAsync(product);
    public Task<int> DeleteAsync(int id) => _productRepository.DeleteAsync(id);
}