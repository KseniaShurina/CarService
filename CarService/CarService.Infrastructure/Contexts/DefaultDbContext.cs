using CarService.Infrastructure.Abstractions.Contexts;
using CarService.Infrastructure.Models;
using CarService.Infrastructure.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarService.Infrastructure.Contexts
{
    internal class DefaultDbContext : DbContext, IDefaultDbContext
    {
        // Не удалять используется при накате миграций и инициализации
        public DefaultDbContext(DbContextOptions<DefaultDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyModelDefaultContextConfiguration();
        }

        public DbSet<Car> Cars { get; set; }
    }
}
