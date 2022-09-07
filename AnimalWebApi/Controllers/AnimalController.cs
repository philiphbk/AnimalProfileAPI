using AnimalWebApi.Data;
using AnimalWebApi.Entities;
using AnimalWebApi.RepositoryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebApi.Controllers
{
    [Route("api/[controller]/api/v1")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IGenericRepository<Animal> _animal;

        public AnimalController(IGenericRepository<Animal> animal)
        {
            _animal = animal;
        }



        //Get All Animals
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            return Ok();
        }
    }
}
