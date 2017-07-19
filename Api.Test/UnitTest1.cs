using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using System.Web.Http;
using Microsoft.Practices.Unity;
using ServicesHelper;
using AutoMapper;
using Intefaces.Services;
using SportRating.Resolver;
using DTOs.CCTService;
using System.Collections.Generic;
using SportRating;
using Interfaces.DAL;

public partial class MiscUnitTests
{
    [TestClass]
    public class HttpClientIntegrationTests : MiscUnitTests
    {

        [TestMethod]
        public async Task HttpClient_Should_Get_OKStatus_From_Products_Using_InMemory_Hosting()
        {

            var config = new HttpConfiguration();

            var container = new UnityContainer();

            MapperConfig.RegisterMapping();
            container.RegisterInstance<IMapper>(Mapper.Instance);

            container.RegisterType<ICCTService, CCTServiceMock>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, FakeUnitOfWork>();

            config.DependencyResolver = new UnityResolver(container);
            //configure web api
            //config.MapHttpAttributeRoutes();
            WebApiConfig.Register(config);

            using (var server = new HttpServer(config))
            {

                var client = new HttpClient(server);

                string url = "http://localhost/api/City/";

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

               // request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.SendAsync(request))
                {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
            }
        }
    }

    public class FakeUnitOfWork : IUnitOfWork
    {
        public IGenericRepository<global::DB.Entities.City> CityRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Country> CountryRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Match> MatchRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Rating> RatingRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.RatingList> RatingListRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Stage> StageRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Team> TeamRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Tournament> TournamentRepository => throw new NotImplementedException();

        public IGenericRepository<global::DB.Entities.Tour> TourRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    public class CCTServiceMock : ICCTService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CCTServiceMock(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }
        public ServiceRespone AddCity(CityDto city)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone AddCountry(CountryDto city)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone AddTeam(TeamDto city)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone GetAllCities()
        {
            return new ServiceRespone
            {
                Value = new List<CityDto>()
                {
                    new CityDto{Id=1, Name="Gorodok", CountryId=1}
                },
                ResponseCode = ResponeCode.Success
            };

        }

        public ServiceRespone GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public ServiceRespone GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public ServiceRespone GetCity(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone GetCountry(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone GetTeam(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone RemoveCity(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone RemoveCountry(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone RemoveTeam(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone UpdateCity(CityDto city)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone UpdateCountry(CountryDto city)
        {
            throw new NotImplementedException();
        }

        public ServiceRespone UpdateTeam(TeamDto city)
        {
            throw new NotImplementedException();
        }
    }
}
