using Microsoft.EntityFrameworkCore;
using Moq;
using PmSystem.Domain.Contracts;
using PmSystem.Domain.Entities;

namespace PmSystem.Infrastructure.Data.Test
{
    [TestFixture]
    public class RepositoryTests
    {
        private IRepository<Customer> _customerRepository;
        private IRepository<Product> _productRepository;
        private DbContextOptions _options;

        [SetUp]
        public async Task Setup()
        {
            _options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("TestingInMemoryDb")
                .Options;

            _customerRepository = new Mock<IRepository<Customer>>(_options).Object;
            _productRepository = new Mock<IRepository<Product>>(_options).Object;

            // Add some test data
            _customerRepository.AddAsync(new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com" });
            _customerRepository.AddAsync(new Customer { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com" });
            _productRepository.AddAsync(new Product { Id = 1, Description = "Product A", Price = 9.99m });
            _productRepository.AddAsync(new Product { Id = 2, Description = "Product B", Price = 14.99m });

            // Save changes to the in-memory database
            await _customerRepository.SaveAsync();
            await _productRepository.SaveAsync();
        }

        [Test]
        public async Task TestGetAllCustomers()
        {
            // Act
            var customers = await _customerRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(customers);
            Assert.AreEqual(2, customers.Count());
        }

        [Test]
        public async Task TestGetAllProducts()
        {
            // Act
            var products = await _productRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count());
        }

        [Test]
        public async Task TestGetCustomerById()
        {
            // Arrange
            var customerId = 1;

            // Act
            var result = await _customerRepository.GetByIdAsync(customerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John Doe", result.Name);
            Assert.AreEqual("john.doe@example.com", result.Email);
        }

        [Test]
        public async Task TestGetProductById()
        {
            // Arrange
            var productId = 2;

            // Act
            var result = await _productRepository.GetByIdAsync(productId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Product B", result.Description);
            Assert.AreEqual(14.99m, result.Price);
        }

        [Test]
        public async Task TestAddCustomer()
        {
            // Arrange
            var newCustomer = new Customer { Id = 4, Name = "Tom Smith", Email = "tom.smith@example.com" };

            // Act
            await _customerRepository.AddAsync(newCustomer);
            var result = await _customerRepository.GetByIdAsync(newCustomer.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Tom Smith", result.Name);
            Assert.AreEqual("tom.smith@example.com", result.Email);
        }

        [Test]
        public async Task TestAddProduct()
        {
            // Arrange
            var newProduct = new Product { Id = 4, Description = "Product D", Price = 24.99m };

            // Act
            await _productRepository.AddAsync(newProduct);
            var result = await _productRepository.GetByIdAsync(newProduct.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Product D", result.Description);
            Assert.AreEqual(24.99m, result.Price);
        }
    }
}
