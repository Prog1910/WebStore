using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IProductRepository
{
    void Add(Product product);

    Task<PagedList<Product>> GetAllAsync(ProductParameters parameters, bool trackChanges);

    Task<Product> GetByIdAsync(int id, bool trackChanges);

    void Remove(Product product);
}