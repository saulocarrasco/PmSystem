using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Domain.Application
{
    public class CustomerItemService : IService<CustomerItem>
    {
        private readonly IRepository<CustomerItem> _customerItemRepository;

        public CustomerItemService(IRepository<CustomerItem> customerItemRepository)
        {
            _customerItemRepository = customerItemRepository;
        }

        public async Task<IEnumerable<CustomerItem>> GetAllAsync()
        {
            return await _customerItemRepository.GetAllAsync();
        }

        public async Task<CustomerItem> GetByIdAsync(int id)
        {
            return await _customerItemRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CustomerItem customer)
        {
            await _customerItemRepository.AddAsync(customer);
        }

        public async Task UpdateAsync(CustomerItem customer)
        {
            await _customerItemRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerItemRepository.DeleteAsync(id);
        }
    }
}
