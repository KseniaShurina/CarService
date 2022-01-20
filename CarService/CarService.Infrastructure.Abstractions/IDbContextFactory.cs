using CarService.Infrastructure.Abstractions.Contexts;

namespace CarService.Infrastructure.Abstractions
{
    public interface IDbContextFactory
    {
        IDefaultDbContext GetDefaultDbContext();
    }
}
