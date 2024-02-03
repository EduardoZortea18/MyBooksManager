using Microsoft.Extensions.DependencyInjection;
using MyBooksManager.Domain.Repositories;
using MyBooksManager.Infra.Persistence.Repositories;

namespace MyBooksManager.Ioc
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
