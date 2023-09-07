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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //kontrola ako  nije dobar
            }
            try
            {
                var usluge = _context.Usluga.ToList();
                if (usluge == null || usluge.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Usluga.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }


        }



        [HttpPost]
        public IActionResult Post(Usluga usluga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Usluga.Add(usluga);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, usluga);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }


        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Usluga usluga)
        {
            if (sifra <= 0 || usluga == null)
            {

                return BadRequest();
            }
            try
            {
                var uslugaBaza = _context.Usluga.Find(sifra);
                if (uslugaBaza == null)
                {
                    return BadRequest();
                }
                uslugaBaza.Naziv = usluga.Naziv;
                uslugaBaza.Destinacija = usluga.Destinacija;
                uslugaBaza.nacin_placanja = usluga.nacin_placanja;
                uslugaBaza.Cijena = usluga.Cijena;
                uslugaBaza.broj_mjesta = usluga.broj_mjesta;

                _context.Usluga.Update(uslugaBaza);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, uslugaBaza);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }

            

        }
    
    

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if(sifra == 0)
            {
                return BadRequest();
            }
            try
            {
                var uslugaBaza = _context.Usluga.Find(sifra);
                if (uslugaBaza == null)
                {
                    return BadRequest();
                }

                _context.Usluga.Remove(uslugaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"obrisano\"}");
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
    
