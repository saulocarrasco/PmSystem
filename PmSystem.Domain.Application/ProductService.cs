using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Domain.Application
{
    public class ProductService : IService<Customer>
    {
        private readonly IRepository<Customer> _productRepository;

        public ProductService(IRepository<Customer> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Customer product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }

}
