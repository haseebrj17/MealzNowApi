using MealzNow.Db.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MealzNow.DbEntities
{
    public static class RepositoriesRegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            serviceCollection.AddTransient<IClientRepository, ClientRepository>();
            serviceCollection.AddTransient<IFranchiseRepository, FranchiseRepository>();
            serviceCollection.AddTransient<IBannerRepository, BannerRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<IPackagesRepository, PackagesRepository>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();
            serviceCollection.AddTransient<ICityRepository, CityRepository>();

            return serviceCollection;
        }
    }
}