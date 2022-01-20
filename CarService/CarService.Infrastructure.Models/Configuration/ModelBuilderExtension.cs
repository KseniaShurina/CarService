using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Infrastructure.Models.Configuration
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyModelDefaultContextConfiguration(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(CarMap.Instance);

            return builder;
        }
    }
}
