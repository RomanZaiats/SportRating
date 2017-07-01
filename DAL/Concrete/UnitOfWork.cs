﻿using DB;
using DB.Entities;
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

        private GenericRepository<City> _cityRepository;
        private GenericRepository<Country> _countryRepository;
        private GenericRepository<Match> _matchRepository;
        private GenericRepository<Rating> _ratingRepository;
        private GenericRepository<RatingList> _ratingListRepository;
        private GenericRepository<Stage> _stageRepository;
        private GenericRepository<Team> _teamRepository;
        private GenericRepository<Tournament> _tournamentRepository;


        public GenericRepository<City> CityRepository { get => _cityRepository ?? (_cityRepository = new GenericRepository<City>(context)); }
        public GenericRepository<Country> CountryRepository { get => _countryRepository ?? (_countryRepository = new GenericRepository<Country>(context)); }
        public GenericRepository<Match> MatchRepository { get => _matchRepository ?? (_matchRepository = new GenericRepository<Match>(context)); }
        public GenericRepository<Rating> RatingRepository { get => _ratingRepository ?? (_ratingRepository = new GenericRepository<Rating>(context)); }
        public GenericRepository<RatingList> RatingListRepository { get => _ratingListRepository ?? (_ratingListRepository = new GenericRepository<RatingList>(context)); }
        public GenericRepository<Stage> StageRepository { get => _stageRepository ?? (_stageRepository = new GenericRepository<Stage>(context)); }
        public GenericRepository<Team> TeamRepository { get => _teamRepository ?? (_teamRepository = new GenericRepository<Team>(context)); }
        public GenericRepository<Tournament> TournamentRepository { get => _tournamentRepository ?? (_tournamentRepository = new GenericRepository<Tournament>(context)); }



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