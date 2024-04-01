using CarService.Infrastructure.Abstractions;
using CarService.Infrastructure.Abstractions.Contexts;
using CarService.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarService.Infrastructure
{
    internal class DbContextFactory : IDbContextFactory
    {
        private readonly IDbContextFactory<DefaultDbContext> _dbContextFactoryDefault;

        public DbContextFactory(IDbContextFactory<DefaultDbContext> dbContextFactoryDefault)
        {
            _dbContextFactoryDefault = dbContextFactoryDefault;
        }

        /// <summary>
        /// Creates a new DbContext
        /// </summary>
        /// <returns>IDefaultDbContext</returns>
        public IDefaultDbContext GetDefaultDbContext()
        {
            return _dbContextFactoryDefault.CreateDbContext();
        }
    }
}
