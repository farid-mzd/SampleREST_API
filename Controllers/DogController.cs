using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleREST_API.Models.Custom;
using SampleREST_API.Models.CustomExceptions;
using SampleREST_API.Models.Pagination;
using SampleREST_API.Models.Pagination.PaginationParameters;
using SampleREST_API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SampleREST_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("/")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService dogService;

        public DogController(IDogService dogService)
        {
            this.dogService = dogService;
        }

        [HttpGet("[action]")]
        public IActionResult Ping()
        {
            return Content("Dogs house service.Version 1.0.1");
        }


        [HttpGet("dogs")]
        public async Task<IActionResult> Get([FromQuery] DogParameters dogParameters)
        {
            try
            {
                var dogs = await dogService.GetDogs(dogParameters);


                if (dogs.TotalCount > 0)
                {

                    var metadata = new
                    {
                        dogs.PageSize,
                        dogs.CurrentPage,
                        dogs.TotalPages,
                        dogs.TotalCount,
                        dogs.HasNext,
                        dogs.HasPrevious
                    };
                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                    
                    return Ok(dogs);

                }
                else
                {
                    return NoContent();
                }
            }
            catch (InvalidQueryStringException ex)
            {
               return NotFound(ex.Message);
            }
            catch (Exception)
            {
              
                return BadRequest();
            }
            
        }


        [HttpPost("dog")]
        public async Task<IActionResult> Add([FromBody] Dog dog)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(await dogService.AddDog(dog));

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return Conflict(new { ex.Message });
            }
        }


    }
}
