using AutoMapper;
using DTOs.Api;
using DTOs.CCTService;
using Intefaces.Services;
using SportRating.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class TeamController : ServiceApiController
    {
        private ICCTService _cctService;
        private IMapper _mapper;

        public TeamController()
        {
            _cctService = (ICCTService)WebApiConfig.DependencyResolver.GetService(typeof(ICCTService));
            _mapper = (IMapper)WebApiConfig.DependencyResolver.GetService(typeof(IMapper));
        }

        [Route("api/Team")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return MapServiceToHttpResponse(_cctService.GetAllTeams());
        }

        public IHttpActionResult Get(int id)
        {
            return MapServiceToHttpResponse(_cctService.GetTeam(id));
        }

        [Route("api/Team")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]TeamApiDto team)
        {
            return MapServiceToHttpResponse(_cctService.AddTeam(_mapper.Map<TeamApiDto, TeamDto>(team)));
        }

        [Route("api/Team")]
        [HttpPut]
        public IHttpActionResult Put([FromBody]TeamApiDto team)
        {
            return MapServiceToHttpResponse(_cctService.UpdateTeam(_mapper.Map<TeamApiDto, TeamDto>(team)));
        }

        public IHttpActionResult Delete(int id)
        {
            return MapServiceToHttpResponse(_cctService.RemoveTeam(id));
        }
    }
}
