using InfinityBeyondSwagger;
using InfinityBeyondSwagger.Data;
using InfinityBeyondSwagger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Linq.Expressions;

namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class Vrsta_djelatnikaController : ControllerBase
    {

        private readonly InfinityBeyondContext _context;

        public Vrsta_djelatnikaController(InfinityBeyondContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dohvaća sve vrste djelatnika iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Smjer
        ///
        /// </remarks>
        /// <returns>Smjerovi u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 


        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var vrsta_djelatnika = _context.Vrsta_Djelatnika.ToList();
                if (vrsta_djelatnika == null || vrsta_djelatnika.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(vrsta_djelatnika);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }
        /// <summary>
        /// Mijenja podatke postojeće vrste djelatnika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/djelatnik/1
        ///
        /// {
        ///  "id": 0,
        ///  "naziv": Pilot
        ///
        /// }
        /// </remarks>
        /// <param name="id">id vrste djelatnika koji se mijenja</param>  
        /// <returns>Svi poslani podaci od vrste djelatnika</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi djelatnika kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 


        [HttpPost]
        public IActionResult Post(Vrsta_djelatnika vrstedjelatnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Vrsta_Djelatnika.Add(vrstedjelatnika);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, vrstedjelatnika);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);
            }



        }

        /// <summary>
        /// Mijenja podatke postojeće vrste djelatnika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        /// {
        ///  "id": 0,
        ///  "naziv": Pilot
        ///
        /// }
        ///
        /// </remarks>
        /// <param name="id">id vrste djelatnika koji se mijenja</param>  
        /// <returns>Svi poslani podaci od vrtse djelatnika</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int id, Vrsta_djelatnika vrstedjelatnika)
        {

            if (id <= 0 || vrstedjelatnika == null)
            {
                return BadRequest();
            }

            try
            {
                var vrstedjelatnikaBaza = _context.Vrsta_Djelatnika.Find(id);
                if (vrstedjelatnikaBaza == null)
                {
                    return BadRequest();
                }

                vrstedjelatnikaBaza.Naziv = vrstedjelatnikaBaza.Naziv;

                _context.Vrsta_Djelatnika.Update(vrstedjelatnikaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, vrstedjelatnikaBaza);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  ex);

            }
        }
        /// <summary>
        /// Briše vrstu djelatnika iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/smjer/1
        ///    
        /// </remarks>
        /// <param name="id">id vrste djelatnika koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

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
                var vrste_djelatnikaBaza = _context.Vrsta_Djelatnika.Find(sifra);
                if (vrste_djelatnikaBaza == null)
                {
                    return BadRequest();
                }

                _context.Vrsta_Djelatnika.Remove(vrste_djelatnikaBaza);
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
