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
            //var response = new HttpResponseMessage(HttpStatusCode.OK);

            //response.Content = new StringContent("Dogs house service.Version 1.0.1");

            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            //return response;

            return Content("Dogs house service.Version 1.0.1");

        }


        [HttpGet("dogs")]
        public async Task<IActionResult> Get()
        {
            return Ok(await dogService.GetDogs());
        }


        [HttpPost("dog")]
        public async Task<IActionResult> Add([FromBody] Dog dog)
        {
            try
            {

            return Ok(await dogService.AddDog(dog));
            }
            catch (Exception ex)
            {

                return Conflict(new {ex.Message});
            }
        }

        
    }
}
