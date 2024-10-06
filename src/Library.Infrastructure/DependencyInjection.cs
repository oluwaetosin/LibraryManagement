using Library.Application.Common.Interfaces;
using Library.Infrastructure.Books.Persistence;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlite("Data Source = Library.db"));
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
