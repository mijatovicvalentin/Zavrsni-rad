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

        /// <summary>
        /// Dohvaća sve Usluge iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Smjer
        ///
        /// </remarks>
        /// <returns>usluge u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
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

        /// <summary>
        /// Mijenja podatke postojeće usluge u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        /// {
        ///  "id": 0,
        ///  "destinacija": Mars
        ///  "nacin_placanja: 1
        ///  "cijena": 937498.33
        ///  "broj_mjesta": 12
        /// }
        ///
        /// </remarks>
        /// <param name="id">id usluge koja se mijenja</param>  
        /// <returns>Svi poslani podaci od usluge</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi korisnika kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 


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
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }


        }


        /// <summary>
        /// Mijenja podatke postojeće usluge u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        ///
        ///{
        ///  "id": 0,
        ///  "destinacija": Mars
        ///  "nacin_placanja: 1
        ///  "cijena": 937498.33
        ///  "broj_mjesta": 12
        /// }
        ///
        /// </remarks>
        /// <param name="id">id usluge koji se mijenja</param>  
        /// <returns>Svi poslani podaci od smjera</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi usluge kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 


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

        /// <summary>
        /// Briše uslugu iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/smjer/1
        ///    
        /// </remarks>
        /// <param name="id">id usluge koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi usluge kojeg želimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (sifra == 0)
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

