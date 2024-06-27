using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IProductRepository
{
    void Add(Product product);

    Task<PagedList<Product>> GetAllAsync(ProductParameters parameters, bool trackChanges);

    void Remove(Product product);
}