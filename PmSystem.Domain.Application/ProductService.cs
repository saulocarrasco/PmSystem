using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Domain.Application
{
    public class ProductService : IService<Product>
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }

}
