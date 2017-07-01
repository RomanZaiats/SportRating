﻿using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IUnitOfWork: IDisposable
    {
        GenericRepository<City> CityRepository { get; }
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<Match> MatchRepository { get; }
        GenericRepository<Rating> RatingRepository { get; }
        GenericRepository<RatingList> RatingListRepository { get; }
        GenericRepository<Stage> StageRepository { get; }
        GenericRepository<Team> TeamRepository { get; }
        GenericRepository<Tournament> TournamentRepository { get; }

        void Save();
    }
}
