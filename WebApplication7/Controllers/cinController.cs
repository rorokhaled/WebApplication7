using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.dto;
using WebApplication7.repo;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cinController : ControllerBase
    {
        private readonly Iceinma _iceinma;
        public cinController(Iceinma iceinma)
        {
            _iceinma = iceinma;
        }
        [HttpGet]
        public IActionResult get()
        {
            _iceinma.getAll();
            return Ok();
        }
        [HttpPut]
        public IActionResult put([FromBody ]cinamdto cinamdto, int id)
        {
            _iceinma.update(cinamdto, id);
            return Accepted();
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _iceinma.delete(id);
            return NoContent();
        }
    }
}
