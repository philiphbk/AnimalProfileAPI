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
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly Pagination _pagination;

        public AnimalController(IUnitOfWork unitOfWork, Pagination pagination)
        {
            _unitOfWork = unitOfWork;
            _pagination = pagination;
        }



        //Get All Animals
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            try
            {
                
                var animals =  await _unitOfWork.Animals.GetAll();
                return Ok(animals);
            }
            catch
            {
                return StatusCode(500, "Internal Server error");
            }
        }




        //Get Animal by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal(string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {

                var result = await _unitOfWork.Animals.Get(x => x.Id == id);
                return Ok(result);

            }
            catch 
            {
                return StatusCode(500, "Internal Server error");
            }
        }



        //Create Animal
        [HttpPost("CreateAnimal")]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _unitOfWork.Animals.Insert(animal);
                await _unitOfWork.Save();
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal Server error");
            }
        }

        //Update Animal
        [HttpPut("UpdateAnimal")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] Animal animal)
        {
            if (!ModelState.IsValid || id == 0) return BadRequest(ModelState);
            try
            {
                _unitOfWork.Animals.Update(animal);
                await _unitOfWork.Save();
                return Accepted();
            }
            catch 
            {
                return StatusCode(500, "Internal Server error");
            }
        }

        //Delete Animal
        [HttpDelete("DeleteAnimal")]
        public async Task<IActionResult> DeleteAnimal(string id)
        {
            if (id == null) return BadRequest();
            try
            {
                var animal = await _unitOfWork.Animals.Get(q => q.Id == id);
                if (animal != null)
                {
                    await _unitOfWork.Animals.Delete(animal.Id);
                }
                await _unitOfWork.Save();

                return Ok();
            }
            catch 
            {
                return StatusCode(500, "Internal Server error");
            }
        }
    }
}
