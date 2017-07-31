using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Interfaces.DAL;
using Api.Test.Unit.CCTServiceTest.Fixtures;
using Intefaces.Services;
using CCTService;
using AutoMapper;
using ServicesHelper;
using System.Collections.Generic;
using DB.Entities;
using DTOs.CCTService;
using System.Linq;

namespace Api.Test.Unit.CCTServiceTest
{
    [TestClass]
    public class CCTServiceTest
    {
        UnityContainer container;
        ICCTService cctService;

        [TestInitialize]
        public void TestInitialize()
        {
            container = new UnityContainer();
            container.RegisterType<IUnitOfWork, FakeUnitOfWork>();
            container.RegisterType<ICCTService, CCTService.CCTService>();

            MapperConfig.RegisterMapping();
            container.RegisterInstance<IMapper>(Mapper.Instance);

            cctService = container.Resolve<ICCTService>();
        }

        #region GetAll

        [TestMethod]
        public void GetCities()
        {
            var res = cctService.GetAllCities();

            Assert.AreEqual(ResponeCode.Success, res.ResponseCode);
            Assert.AreEqual(3, ((IEnumerable<CityDto>)res.Value).Count());
        }

        [TestMethod]
        public void GetCountries()
        {
            var res = cctService.GetAllCountries();

            Assert.AreEqual(ResponeCode.Success, res.ResponseCode);
            Assert.AreEqual(2, ((IEnumerable<CountryDto>)res.Value).Count());
        }

        [TestMethod]
        public void GetTeams()
        {
            var res = cctService.GetAllTeams();

            Assert.AreEqual(ResponeCode.Success, res.ResponseCode);
            Assert.AreEqual(3, ((IEnumerable<TeamDto>)res.Value).Count());
        }

        #endregion

        #region GetById

        [TestMethod]
        public void GetCityById()
        {
            var res = cctService.GetCity(1);

            var expectedCityDto = new CityDto
            {
                Id = 1,
                Name = "testCity1",
                CountryId = 1
            };
            var responseCityDto = (CityDto)res.Value;
            Assert.AreEqual(ResponeCode.Success, res.ResponseCode);
            Assert.AreEqual(expectedCityDto.Id, responseCityDto.Id);
            Assert.AreEqual(expectedCityDto.Name, responseCityDto.Name);
            Assert.AreEqual(expectedCityDto.CountryId, responseCityDto.CountryId);
        }

        [TestMethod]
        public void GetCountryById()
        {
            var res = cctService.GetCountry(1);

            var expectedCountryDto = new CountryDto
            {
                Id = 1,
                Name = "testCountry1"
            };
            var responseCountryDto = (CountryDto)res.Value;
            Assert.AreEqual(ResponeCode.Success, res.ResponseCode);
            Assert.AreEqual(expectedCountryDto.Id, responseCountryDto.Id);
            Assert.AreEqual(expectedCountryDto.Name, responseCountryDto.Name);
        }

        [TestMethod]
        public void GetTeamById()
        {
            var res = cctService.GetTeam(1);

            var expectedTeamDto = new TeamDto
            {
                Id = 1,
                Name = "testTeam1",
                CityId = 1
            };
            var responseTeamDto = (TeamDto)res.Value;
            Assert.AreEqual(ResponeCode.Success, res.ResponseCode);
            Assert.AreEqual(expectedTeamDto.Id, responseTeamDto.Id);
            Assert.AreEqual(expectedTeamDto.Name, responseTeamDto.Name);
            Assert.AreEqual(expectedTeamDto.CityId, responseTeamDto.CityId);
        }

        #endregion

        #region Insert

        [TestMethod]
        public void InsertCity()
        {
            var expectedCityDto = new CityDto
            {
                Id = 1,
                Name = "testCity1",
                CountryId = 1
            };

            var res = cctService.AddCity(expectedCityDto);

            var responseCityDto = (CityDto)res.Value;
            Assert.AreEqual(ResponeCode.DbRecordCreated, res.ResponseCode);
            Assert.AreEqual(expectedCityDto.Id, responseCityDto.Id);
            Assert.AreEqual(expectedCityDto.Name, responseCityDto.Name);
            Assert.AreEqual(expectedCityDto.CountryId, responseCityDto.CountryId);
        }

        [TestMethod]
        public void InsertCountry()
        {
            var expectedCountryDto = new CountryDto
            {
                Id = 1,
                Name = "testCountry1"
            };

            var res = cctService.AddCountry(expectedCountryDto);

            var responseCountryDto = (CountryDto)res.Value;
            Assert.AreEqual(ResponeCode.DbRecordCreated, res.ResponseCode);
            Assert.AreEqual(expectedCountryDto.Id, responseCountryDto.Id);
            Assert.AreEqual(expectedCountryDto.Name, responseCountryDto.Name);
        }

        [TestMethod]
        public void InsertTeam()
        {
            var expectedTeamDto = new TeamDto
            {
                Id = 1,
                Name = "testTeam1",
                CityId = 1
            };

            var res = cctService.AddTeam(expectedTeamDto);

            var responseTeamDto = (TeamDto)res.Value;
            Assert.AreEqual(ResponeCode.DbRecordCreated, res.ResponseCode);
            Assert.AreEqual(expectedTeamDto.Id, responseTeamDto.Id);
            Assert.AreEqual(expectedTeamDto.Name, responseTeamDto.Name);
            Assert.AreEqual(expectedTeamDto.CityId, responseTeamDto.CityId);
        }

        #endregion

        #region Delete

        [TestMethod]
        public void DeleteCity()
        {

        }

        [TestMethod]
        public void DeleteCountry()
        {

        }

        [TestMethod]
        public void DeleteTeam()
        {

        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateCity()
        {

        }

        [TestMethod]
        public void UpdateCountry()
        {

        }

        [TestMethod]
        public void UpdateTeam()
        {

        }

        #endregion
    }
}
