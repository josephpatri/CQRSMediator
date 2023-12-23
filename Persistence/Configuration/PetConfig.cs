using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PetConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Specie).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Race).HasMaxLength(20);
            builder.Property(p => p.BirtDate).IsRequired();
            builder.HasOne(p => p.Customer) // Relación uno a muchos con la entidad Customer
                .WithMany(c => c.Pets) // Navegación a la colección de Pets
                .HasForeignKey(p => p.CustomerId) // Clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento al eliminar en cascada
        }
    }
}
