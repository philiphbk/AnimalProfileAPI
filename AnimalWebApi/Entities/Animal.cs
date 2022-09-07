using System.ComponentModel.DataAnnotations;

namespace AnimalWebApi.Entities 
{
    public class Animal
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? PetName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? Breed { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength (600)]
        public string? Description { get; set; }


    }
}
