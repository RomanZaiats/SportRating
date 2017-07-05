using DAL;
using DB.Entities;
using SportRating.Models;
using SportRating.Models.City;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class CityController : ApiController
    {
        private IUnitOfWork db;

        public CityController()
        {
            db = new UnitOfWork();
        }

        // GET: api/City
        public IHttpActionResult Get()
        {
            var cities = db.CityRepository.Get()
                .Select(i => new CityDto { Id = i.Id, Name = i.Name, CountryId = i.CountryId });
            return Ok(cities);
        }

        // GET: api/City/5
        public IHttpActionResult Get(int id)
        {
            City city = db.CityRepository.GetByID(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(
                new CityDetailsDto
                {
                    Id = city.Id,
                    CountryId = city.CountryId,
                    Name = city.Name,
                    CountryName = city.Country.Name
                });
        }

        // POST: api/City
        public IHttpActionResult Post([FromBody]City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CityRepository.Insert(city);
            db.Save();
            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // PUT: api/City/5
        public IHttpActionResult Put(int id, [FromBody]City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CityRepository.Update(city);
            try
            {
                db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.CityRepository.GetByID(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/City/5
        public IHttpActionResult Delete(int id)
        {
            City city = db.CityRepository.GetByID(id);
            if (city == null)
            {
                return NotFound();
            }

            db.CityRepository.Delete(city);
            db.Save();

            return Ok(city);
        }
    }
}
