using AnimalWebApi.Data;
using AnimalWebApi.Entities;
using AnimalWebApi.RepositoryInterface;
using AnimalWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApi.Controllers
{
    [Route("api/[controller]/api/v1")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly IAnimalService _animalService;
       

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }



      
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals([FromQuery] Pagination pagination)
        {
            try
            {
                var animals = await _animalService.GetPagedAnimals(pagination);
                return Ok(animals);
            }
            catch
            {
                return StatusCode(500, "Internal Server error");
            }
        }



        
    
        [HttpPost("CreateAnimal")]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _animalService.Insert(animal);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal Server error");
            }
        }

    
        [HttpPut("UpdateAnimal")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] Animal animal)
        {
            if (!ModelState.IsValid || id == 0) return BadRequest(ModelState);
            try
            {
               await _animalService.UpdateAnimal(animal);
               return Accepted();
            }
            catch 
            {
                return StatusCode(500, "Internal Server error");
            }
        }

  
        [HttpDelete("DeleteAnimal")]
        public async Task<IActionResult> DeleteAnimal(string id)
        {
            if (id == null) return BadRequest();
            try
            {
                await _animalService.DeleteAnimal(id);
            
                return Ok();
            }
            catch 
            {
                return StatusCode(500, "Internal Server error");
            }
        }
    }
}
