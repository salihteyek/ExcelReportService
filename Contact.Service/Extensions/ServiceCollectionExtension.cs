using Contact.Core.Repositories;
using Contact.Core.Services;
using Contact.Core.UnitOfWorks;
using Contact.Data.Repositories;
using Contact.Data.UnitOfWorks;
using Contact.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IService<>), typeof(Service<>));
            serviceCollection.AddScoped<IPersonService, PersonService>();
            serviceCollection.AddScoped<IContactInformationService, ContactInformationService>();
            return serviceCollection;
        }
    }
}
