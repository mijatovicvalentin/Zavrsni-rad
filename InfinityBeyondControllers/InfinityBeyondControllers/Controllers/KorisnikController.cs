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
    public class KorisnikController : ControllerBase
    {

        private readonly InfinityBeyondContext _context;

        public KorisnikController(InfinityBeyondContext context)
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
                var korisnici = _context.Korisnik.ToList();
                if (korisnici == null || korisnici.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Korisnik.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _context.Korisnik.Add(korisnik);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, korisnik);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Korisnik korisnik)
        {

            if (sifra <= 0 || korisnik == null)
            {

                return BadRequest();
            }
            try
            {
                var KorisnikBaza = _context.Korisnik.Find(sifra);
                if (KorisnikBaza == null)
                {
                    return BadRequest();
                }
                KorisnikBaza.Ime = korisnik.Ime;
                KorisnikBaza.Prezime = korisnik.Prezime;
                KorisnikBaza.Oib = korisnik.Oib;
                KorisnikBaza.Email = korisnik.Email;

                _context.Korisnik.Update(KorisnikBaza);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, KorisnikBaza);
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
            if (sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var korisnikBaza = _context.Korisnik.Find(sifra);
                if (korisnikBaza == null)
                {
                    return BadRequest();
                }
                //napisati provjeru moze li se obrisati

                _context.Korisnik.Remove(korisnikBaza);
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

        [HttpGet]
        [Route("UnosUBazu")]
        public string UnosUBazu()   
        {
            Korisnik s;
            for (int i = 0; i <= 1000; i++)
            {
                s = new()
                {
                    //Ime = "Valentin" + i,
                    Ime = Faker.Name.First(),
                    //Prezime = "Mijatovic" + i,
                    Prezime = Faker.Name.Last(),
                    //Email = "randomi@gmail.com" + i,
                    Email = Faker.Internet.Email(),
                    Oib = Faker.Identification.SocialSecurityNumber().Substring(0,10)

                 
                    

                };
                _context.Korisnik.Add(s);
            }
            _context.SaveChanges();

            return "Okej";
        }

        //ruta koja na svakom entitetu koji ima parnu sifru jednom
        //atributu mjenja vrijednost i  sprema u bazu.

        [HttpGet]
        [Route("Zad2")]
        public string Zad2()
        {
            var korisnici = _context.Korisnik.ToList();

            foreach(var k in korisnici)
            {
                if(k.id % 2 == 0)
                {
                    k.Ime += "Ime";
                    _context.Korisnik.Update(k);
                }
            }
            _context.SaveChanges();

            return "Okej";
        }
        //Napisati rutu koja vraća sumu svih sifri na odabranom entinetu

        [HttpGet]
        [Route("Zad3")]
        public string Zad3()
        {
            var korisnici = _context.Korisnik.ToList();
          
            

            return "Okej";
        }
    }
}