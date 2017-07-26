using AutoMapper;
using CCTService;
using DAL;
using DB.Entities;
using DTOs.Api;
using DTOs.CCTService;
using Intefaces.Services;
using SportRating.Models;
using SportRating.Models.City;
using SportRating.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class CityController : ServiceApiController
    {
        private ICCTService _cctService;
        private IMapper _mapper;

        public CityController()
        {
            _cctService = (ICCTService)WebApiConfig.DependencyResolver.GetService(typeof(ICCTService));
            _mapper = (IMapper)WebApiConfig.DependencyResolver.GetService(typeof(IMapper));
        }

        [Route("api/City")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return MapServiceToHttpResponse(_cctService.GetAllCities());
        }

        public IHttpActionResult Get(int id)
        {
            return MapServiceToHttpResponse(_cctService.GetCity(id));
        }

        [Route("api/City")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]CityApiDto city)
        {
            return MapServiceToHttpResponse(_cctService.AddCity(_mapper.Map<CityApiDto, CityDto>(city)));
        }

        [Route("api/City")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]CityApiDto city)
        {
            return MapServiceToHttpResponse(_cctService.UpdateCity(_mapper.Map<CityApiDto, CityDto>(city)));
        }

        public IHttpActionResult Delete(int id)
        {
            return MapServiceToHttpResponse(_cctService.RemoveCity(id));
        }
    }
}
