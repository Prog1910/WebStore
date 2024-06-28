using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }

    public void Add(Product product) => base.Create(product);

    async Task<PagedList<Product>> IProductRepository.GetAllAsync(ProductParameters parameters, bool trackChanges)
    {
        var items = await FindAll(trackChanges).ToListAsync();

        return PagedList<Product>.ToPagedList(items, pageNumber: parameters.PageNumber, pageSize: parameters.PageSize);
    }

    public async Task<Product> GetByIdAsync(int id, bool trackChanges)
        => await FindByCondintion(p => p.Id == id, trackChanges).SingleOrDefaultAsync();

    public void Remove(Product product) => base.Delete(product);
}