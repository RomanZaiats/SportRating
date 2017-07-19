using DB;
using DB.Entities;
using Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SportRatingContext context = new SportRatingContext();

        private IGenericRepository<City> _cityRepository;
        private IGenericRepository<Country> _countryRepository;
        private IGenericRepository<Match> _matchRepository;
        private IGenericRepository<Rating> _ratingRepository;
        private IGenericRepository<RatingList> _ratingListRepository;
        private IGenericRepository<Stage> _stageRepository;
        private IGenericRepository<Team> _teamRepository;
        private IGenericRepository<Tournament> _tournamentRepository;
        private IGenericRepository<Tour> _tourRepository;

        public IGenericRepository<City> CityRepository { get => _cityRepository ?? (_cityRepository = new GenericRepository<City>(context)); }
        public IGenericRepository<Country> CountryRepository { get => _countryRepository ?? (_countryRepository = new GenericRepository<Country>(context)); }
        public IGenericRepository<Match> MatchRepository { get => _matchRepository ?? (_matchRepository = new GenericRepository<Match>(context)); }
        public IGenericRepository<Rating> RatingRepository { get => _ratingRepository ?? (_ratingRepository = new GenericRepository<Rating>(context)); }
        public IGenericRepository<RatingList> RatingListRepository { get => _ratingListRepository ?? (_ratingListRepository = new GenericRepository<RatingList>(context)); }
        public IGenericRepository<Stage> StageRepository { get => _stageRepository ?? (_stageRepository = new GenericRepository<Stage>(context)); }
        public IGenericRepository<Team> TeamRepository { get => _teamRepository ?? (_teamRepository = new GenericRepository<Team>(context)); }
        public IGenericRepository<Tournament> TournamentRepository { get => _tournamentRepository ?? (_tournamentRepository = new GenericRepository<Tournament>(context)); }
        public IGenericRepository<Tour> TourRepository { get => _tourRepository ?? (_tourRepository = new GenericRepository<Tour>(context)); }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
