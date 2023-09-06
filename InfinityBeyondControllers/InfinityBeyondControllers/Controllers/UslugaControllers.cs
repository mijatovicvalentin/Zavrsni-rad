using InfinityBeyondControllers;
using InfinityBeyondControllers.Data;
using InfinityBeyondControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UslugaController : ControllerBase
    {

        private readonly InfinityBeyondContext _context;

        public UslugaController(InfinityBeyondContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return new JsonResult(_context.Usluga.ToList());
        }

        [HttpPost]
        public IActionResult Post(Usluga usluga)
        {
            _context.Usluga.Add(usluga);
            _context.SaveChanges();

            return Created("/api/v1/Smjer", usluga);
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Usluga usluga)
        {




            return StatusCode(StatusCodes.Status200OK, usluga);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");
        }
    }
}