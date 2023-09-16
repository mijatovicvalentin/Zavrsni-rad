using InfinityBeyondSwagger.Data;
using InfinityBeyondSwagger.Models;
using InfinityBeyondSwagger.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class DjelatnikController : ControllerBase
    {
        private readonly InfinityBeyondContext _context;
        private readonly ILogger<DjelatnikController> _logger;

        public DjelatnikController(InfinityBeyondContext context,
            ILogger<DjelatnikController> logger)
        {
            _context = context;
            _logger = logger;
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
                var djelatnici = _context.Djelatnik.Include(d => d.Vrsta_djelatnika)
                    .ToList();

                if (djelatnici == null || djelatnici.Count == 0)
                {
                    return new EmptyResult();
                }

                List<DjelatnikDTO> vrati = new();

                djelatnici.ForEach(v =>
                {
                    vrati.Add(new DjelatnikDTO()
                    {
                        id = v.id,
                        ime = v.ime,
                        prezime = v.prezime,
                        oib = v.oib,
                        kontakt = v.kontakt,
                        jedinstvenibroj = v.jedinstvenibroj,
                        vrsta_djelatnika = v.Vrsta_djelatnika.Naziv

                    });
                });
                return Ok(vrati);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex);
            }


        }

        [HttpPost]
        public IActionResult Post(DjelatnikDTO djelatnikDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (djelatnikDTO.id <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var vrsta_Djelatnika = _context.Vrsta_Djelatnika.Find(djelatnikDTO.vd_sifra);

                if (vrsta_Djelatnika == null)
                {
                    return BadRequest(ModelState);
                }

                Djelatnik d = new()
                {
                    ime = djelatnikDTO.ime,
                    prezime = djelatnikDTO.prezime,
                    oib = djelatnikDTO.oib,
                    kontakt = djelatnikDTO.kontakt,
                    jedinstvenibroj = djelatnikDTO.jedinstvenibroj,
                    Vrsta_djelatnika = vrsta_Djelatnika


                };

                _context.Djelatnik.Add(d);
                _context.SaveChanges();

                djelatnikDTO.vd_sifra = d.id;

                return Ok(djelatnikDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status503ServiceUnavailable,
                   ex);
            }

        }
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, DjelatnikDTO djelatnikDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (sifra <= 0 || djelatnikDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var vrstedjelatnika = _context.Vrsta_Djelatnika.Find(djelatnikDTO.id);

                if (vrstedjelatnika == null)
                {
                    return BadRequest();
                }

                var Djelatnik = _context.Djelatnik.Find(sifra);

                if (Djelatnik == null)
                {
                    return BadRequest();
                }

                Djelatnik.ime = djelatnikDTO.ime;
                Djelatnik.prezime = djelatnikDTO.prezime;
                Djelatnik.oib = djelatnikDTO.oib;
                Djelatnik.kontakt = djelatnikDTO.kontakt;
                Djelatnik.jedinstvenibroj = djelatnikDTO.jedinstvenibroj;
                Djelatnik.Vrsta_djelatnika = vrstedjelatnika;

                _context.Djelatnik.Update(Djelatnik);
                _context.SaveChanges();

                djelatnikDTO.vd_sifra = sifra;

                return Ok(djelatnikDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }


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

            var DjelatnikBaza = _context.Djelatnik.Find(sifra);
            if (DjelatnikBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Djelatnik.Remove(DjelatnikBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");

            }
        }


    }
}