using Microsoft.AspNetCore.Mvc;
using SampleREST_API.Models.Custom;
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
        public async Task<IActionResult> Get()
        {
            try
            {
            return Ok(await dogService.GetDogs());
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
