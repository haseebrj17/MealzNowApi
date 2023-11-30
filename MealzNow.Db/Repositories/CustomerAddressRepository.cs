using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db.Repositories
{
    public interface ICustomerAddressRepository
    {
        Task<Customer> AddAddress(Guid customerId, CustomerAddresses newAddress);
        Task<bool> UpdateAddress(Guid customerId, CustomerAddresses updatedAddress);
        Task<Customer> GetAllAddresses(Guid customerId);
        Task<CustomerAddresses> GetAddressById(Guid addressId, Guid customerId);
    }
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;

        public CustomerAddressRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<Customer> AddAddress(Guid customerId, CustomerAddresses newAddress)
        {
            if (newAddress == null)
                throw new ArgumentNullException(nameof(newAddress));

            var customer = await _mealzNowDataBaseContext.Customers
                               .Include(c => c.CustomerAddresses)
                               .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
                throw new InvalidOperationException("Customer not found.");

            newAddress.CreatedDateTimeUtc = DateTime.UtcNow;
            newAddress.UpdatedDateTimeUtc = DateTime.UtcNow;
            newAddress.CreatedById = customerId;
            newAddress.UpdatedById = customerId;

            customer.CustomerAddresses.Add(newAddress);

            await _mealzNowDataBaseContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> GetAllAddresses(Guid customerId)
        {
            var customer = await _mealzNowDataBaseContext.Customers
                            .Include(c => c.CustomerAddresses)
                            .FirstOrDefaultAsync(c => c.Id == customerId);

            return customer;
        }

        public async Task<bool> UpdateAddress(Guid customerId, CustomerAddresses updatedAddress)
        {
            if (updatedAddress == null)
                throw new ArgumentNullException(nameof(updatedAddress));

            var customer = await _mealzNowDataBaseContext.Customers
                                .Include(c => c.CustomerAddresses)
                                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
                return false;

            var existingAddress = customer.CustomerAddresses.FirstOrDefault(a => a.Id == updatedAddress.Id);
            if (existingAddress == null)
                return false;

            _mealzNowDataBaseContext.Entry(existingAddress).CurrentValues.SetValues(updatedAddress);
            await _mealzNowDataBaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerAddresses> GetAddressById(Guid addressId, Guid customerId)
        {
            var customer = await _mealzNowDataBaseContext.Customers
                            .Include(c => c.CustomerAddresses)
                            .FirstOrDefaultAsync(c => c.Id == customerId);

            var address = customer?.CustomerAddresses.Find(c => c.Id == addressId);

            return address;
        }
    }
}