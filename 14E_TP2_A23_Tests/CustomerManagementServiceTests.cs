using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services.CustomerManagement;
using _14E_TP2_A23.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Castle.Core.Resource;
using System.Collections.ObjectModel;

namespace _14E_TP2_A23_Tests
{

    [TestClass]
    public class CustomerManagementServiceTests
    {
       
        private Mock<IDALService> dalServiceMock = new Mock<IDALService>();
        private CustomerManagementService customerManagementService;
        private string email = "satya@example.com";
        private Customer? customer;

        [TestMethod]
        public async Task Add_Customer_Returns_True()
        {
            // Arrange
            customer = new Customer { Email = email, FullName = "sat", IsMembershipActive = true, MembershipStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)  };
            customerManagementService = new CustomerManagementService(dalServiceMock.Object);

            dalServiceMock.Setup(dal => dal.FindCustomerByEmailAsync(email))
                .ReturnsAsync((Customer)null);

            dalServiceMock.Setup(dal => dal.AddCustomerAsync(customer))
            .ReturnsAsync(true);

            // Act
            var result = await customerManagementService.AddCustomer(customer);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task AddCustomer_CustomerAlreadyExists_ThrowsException()
        {
            // Arrange
            var customer = new Customer { Email = email };
            customerManagementService = new CustomerManagementService(dalServiceMock.Object);

            dalServiceMock.Setup(x => x.FindCustomerByEmailAsync(email))
                .ReturnsAsync(customer);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await customerManagementService.AddCustomer(customer);
            });
        }

        [TestMethod]
        public async Task GetAllCustomers_ReturnsCollection()
        {
            customerManagementService = new CustomerManagementService(dalServiceMock.Object);
            // Arrange
            var customers = new ObservableCollection<Customer>
            {
                new Customer { Email = "customer1@example.com" },
                new Customer { Email = "customer2@example.com" },
                new Customer { Email = "customer3@example.com" }
            };

            // Act
            dalServiceMock.Setup(x => x.GetAllCustomersAsync())
            .ReturnsAsync(customers);

            // Act
            var result = await customerManagementService.GetAllCustomers();

            // Assert
            CollectionAssert.AreEqual(customers, result); // Verify that the retrieved collection matches the in-memory data.
        }

        [TestMethod]
        public async Task UpdateCustomer_CustomerExists_ReturnsTrue()
        {

            var existingCustomer = new Customer { Email = "existingcustomer@example.com" };
            var updatedCustomer = new Customer { Email = "existingcustomer@example.com" }; // Same email as existingCustomer

            dalServiceMock.Setup(dal => dal.FindCustomerByEmailAsync(updatedCustomer.Email))
                .ReturnsAsync(existingCustomer);
            dalServiceMock.Setup(dal => dal.UpdateCustomerAsync(updatedCustomer))
                .ReturnsAsync(true);

            // Act
            var result = await customerManagementService.UpdateCustomer(updatedCustomer);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateCustomer_CustomerDoesNotExist_ThrowsException()
        {
            // Arrange
            var nonExistingCustomer = new Customer { Email = "nonexistingcustomer@example.com" };

            // Act and Assert
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await customerManagementService.UpdateCustomer(nonExistingCustomer);
            });
        }

    }
}

