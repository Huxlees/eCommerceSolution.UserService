using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.Services;
using eCommerce.Core.UserContracts;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUsersService,UsersService>();
            return services;
        }
    }
}
