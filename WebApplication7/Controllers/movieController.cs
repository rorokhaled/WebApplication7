using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.dto;
using WebApplication7.repo;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class movieController : ControllerBase
    {
        private readonly Imovie _movie;
        public movieController(Imovie movie)
        {
             _movie= movie;
        }


        [HttpGet]
        public IActionResult Get()
        {
            _movie.GettAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _movie.getbyid(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult post([FromBody]moviedto moviedto) {
        
        _movie.add(moviedto);
            return Ok();
        
        }



    }
}
