using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();

        }
    }
}
