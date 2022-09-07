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
                    Id = "1",
                    PetName = "Cat",
                    Breed = "Abyssinian",
                    Age = "10",
                    Description = "The Abyssinian /æbɪˈsɪniən/ is a breed of domestic short-haired cat with a distinctive \"ticked\" " +
                                  "tabby coat, in which individual hairs are banded with different colors.[2] " +
                                  "They are also known simply as Abys."
                },
                new Animal
                {
                    Id = "2",
                    PetName = "Cat",
                    Breed = "Aegean",
                    Age = "13",
                    Description = "Aegean cats (Greek: γάτα του Αιγαίου gáta tou Aigaíou) are a naturally occurring " +
                                  "landrace of domestic cat originating from the Cycladic Islands of Greece and western Turkey. "
                                  
                },
                new Animal
                {
                    Id = "3",
                    PetName = "Cat",
                    Breed = "Aegean",
                    Age = "13",
                    Description = "Aegean cats (Greek: γάτα του Αιγαίου gáta tou Aigaíou) are a naturally occurring " +
                                  "landrace of domestic cat originating from the Cycladic Islands of Greece and western Turkey."
                                  
                }

            );
        } 
    }
}
