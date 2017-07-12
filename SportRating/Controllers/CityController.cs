using CCTService;
using DAL;
using DB.Entities;
using DTOs.CCTService;
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
        private ICCTService _cctService;

        public CityController()
        {
            _cctService = (ICCTService)WebApiConfig.DependencyResolver.GetService(typeof(ICCTService));
        }

        // GET: api/City
        public IHttpActionResult Get()
        {
            var result = _cctService.GetAllCities();

            return Ok(result.Value);
        }

        // GET: api/City/5
        public IHttpActionResult Get(int id)
        {
            var result = _cctService.GetCity(id);

            return Ok(result.Value);
        }

        // POST: api/City
        public IHttpActionResult Post([FromBody]CityDto city)
        {
            var result = _cctService.AddCity(city);

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // PUT: api/City/5
        public IHttpActionResult Put(int id, [FromBody]CityDto city)
        {
            var result = _cctService.UpdateCity(city);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/City/5
        public IHttpActionResult Delete(int id)
        {
            var result = _cctService.RemoveCity(id);

            return Ok(result.Value);
        }
    }
}
