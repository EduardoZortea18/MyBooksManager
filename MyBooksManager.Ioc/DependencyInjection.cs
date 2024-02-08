using Microsoft.Extensions.DependencyInjection;
using MyBooksManager.Application.Commands.Books.CreateBook;
using MyBooksManager.Domain.Repositories;
using MyBooksManager.Infra.Persistence.Repositories;

namespace MyBooksManager.Ioc
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            AddRepositories(services);
            AddCommandHandlers(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ILoansRepository, LoansRepository>();
        }

        private static void AddCommandHandlers(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBookCommand).Assembly));
        }
    }
}
