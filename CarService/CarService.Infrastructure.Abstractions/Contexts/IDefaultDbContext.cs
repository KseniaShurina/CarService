using CarService.Infrastructure.Abstractions.Contexts.Base;
using CarService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.Infrastructure.Abstractions.Contexts
{
    public interface IDefaultDbContext : IDbContextBase
    {
        DbSet<Car> Cars { get; set; }
    }
}
