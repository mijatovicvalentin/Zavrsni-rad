using InfinityBeyondControllers;
using InfinityBeyondControllers.Data;
using InfinityBeyondControllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Linq.Expressions;

namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class vrsta_djelatnikaController : ControllerBase
    {

        private readonly InfinityBeyondContext _context;

        public vrsta_djelatnikaController(InfinityBeyondContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var vrsta_djelatnika = _context.vrsta_Djelatnika.ToList();
                if (vrsta_djelatnika == null || vrsta_djelatnika.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.vrsta_Djelatnika.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(vrsta_djelatnika vrsta_djelatnika)
        {
            return Created("/api/v1/Smjer", vrsta_djelatnika);

        }
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, vrsta_djelatnika vrsta_djelatnika)
        {

            return StatusCode(StatusCodes.Status200OK, vrsta_djelatnika);


        }


        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var vrste_djelatnikaBaza = _context.vrsta_Djelatnika.Find(sifra);
                if (vrste_djelatnikaBaza == null)
                {
                    return BadRequest();
                }

                _context.vrsta_Djelatnika.Remove(vrste_djelatnikaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                try
                {
                    SqlException sqle = (SqlException)ex;
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  sqle);
                }
                catch (Exception e)
                {

                }

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  ex);
            }
        }
    }
}