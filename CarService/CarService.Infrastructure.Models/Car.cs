using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Infrastructure.Models
{
    public class Car
    {
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Series { get; set; }
    }

    internal class CarMap : IEntityTypeConfiguration<Car>
    {
        public static CarMap Instance = new();

        public void Configure(EntityTypeBuilder<Car> builder)
        {

            builder.HasKey(i => i.Id);
            builder.HasIndex(i => i.Id).IsUnique();
            //builder.Property(i => i.Id).ValueGeneratedOnAdd().IsRequired();


            builder.Property(i => i.Id).HasColumnName("ID");
        }
    }
}
