using Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Entities;

namespace Api.Test.Unit.CCTServiceTest.Fixtures
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IGenericRepository<City> _cityRepository = new FakeCityRepository();
        private IGenericRepository<Country> _countryRepository = new FakeCountryRepository();
        private IGenericRepository<Team> _teamRepository = new FakeTeamRepository();


        public IGenericRepository<City> CityRepository => _cityRepository;

        public IGenericRepository<Country> CountryRepository => _countryRepository;

        public IGenericRepository<Match> MatchRepository => throw new NotImplementedException();

        public IGenericRepository<Rating> RatingRepository => throw new NotImplementedException();

        public IGenericRepository<RatingList> RatingListRepository => throw new NotImplementedException();

        public IGenericRepository<Stage> StageRepository => throw new NotImplementedException();

        public IGenericRepository<Team> TeamRepository => _teamRepository;

        public IGenericRepository<Tournament> TournamentRepository => throw new NotImplementedException();

        public IGenericRepository<Tour> TourRepository => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public void Save()
        {
        }
    }
}
