using Shared.DataTransferObjects.Product;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IProductService
{
    Task<ProductDto> AddAsync(ProductForCreationDto productDto);

    Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters parameters, bool trackChanges);

    Task<ProductDto> GetByIdAsync(int id, bool trackChanges);

    Task RemoveAsync(int id, bool trackChanges);
}