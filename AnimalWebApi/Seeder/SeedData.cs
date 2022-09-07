using AnimalWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalWebApi.Seeder
{
    public class SeedData: IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData(
                new Animal
                {
                    Id = 1,
                    PetName = "Jojo",
                    Breed = "",
                    Age = 10,
                    Description = ""
                }
            );
        } 
    }
}
