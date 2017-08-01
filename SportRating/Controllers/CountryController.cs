using AutoMapper;
using DTOs.Api;
using DTOs.CCTService;
using Intefaces.Services;
using SportRating.Utils;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class CountryController : ServiceApiController
    {
        private ICCTService _cctService;
        private IMapper _mapper;

        public CountryController()
        {
            _cctService = (ICCTService)WebApiConfig.DependencyResolver.GetService(typeof(ICCTService));
            _mapper = (IMapper)WebApiConfig.DependencyResolver.GetService(typeof(IMapper));
        }

        [Route("api/Country")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return MapServiceToHttpResponse(_cctService.GetAllCountries());
        }

        public IHttpActionResult Get(int id)
        {
            return MapServiceToHttpResponse(_cctService.GetCountry(id));
        }

        [Route("api/Country")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]CountryApiDto country)
        {
            return MapServiceToHttpResponse(_cctService.AddCountry(_mapper.Map<CountryApiDto, CountryDto>(country)));
        }

        public IHttpActionResult Delete(int id)
        {
            return MapServiceToHttpResponse(_cctService.RemoveCountry(id));
        }
    }
}
