using AutoMapper;
using Contracts;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Product;
using Shared.RequestFeatures;

namespace Service;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task AddAsync(ProductForCreationDto product)
    {
        var productForDb = _mapper.Map<Product>(product);

        _repository.Product.Add(productForDb);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters parameters, bool trackChanges)
    {
        var productsFromDb = await _repository.Product.GetAllAsync(parameters, trackChanges);

        return _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);
    }

    public async Task<ProductDto> GetByIdAsync(int id, bool trackChanges)
    {
        Product productFromDb = await TryGetProductByIdAsync(id, trackChanges);

        return _mapper.Map<ProductDto>(productFromDb);
    }

    public async Task RemoveAsync(int id, bool trackChanges)
    {
        Product productFromDb = await TryGetProductByIdAsync(id, trackChanges);

        _repository.Product.Remove(productFromDb);
        await _repository.SaveAsync();
    }

    private async Task<Product> TryGetProductByIdAsync(int id, bool trackChanges)
        => await _repository.Product.GetByIdAsync(id, trackChanges)
            ?? throw new ProductNotFoundException(id);
}