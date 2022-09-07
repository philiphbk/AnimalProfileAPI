using AnimalWebApi.Entities;
using AnimalWebApi.MockData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IronXL;

namespace AnimalWebApi.Seeder
{
    public class SeedData: IEntityTypeConfiguration<Animal>
    {
        private readonly ReadData _readData = new ReadData();
        

        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData(

                new Animal
                {
                       
                }


            );
        }
    }
}
