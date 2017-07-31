using DB.Entities;
using Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Api.Test.Unit.CCTServiceTest.Fixtures
{
    class FakeTeamRepository : IGenericRepository<Team>
    {
        public void Delete(object id)
        {
        }

        public void Delete(Team entityToDelete)
        {
        }

        public IEnumerable<Team> Get(Expression<Func<Team, bool>> filter = null, Func<IQueryable<Team>, IOrderedQueryable<Team>> orderBy = null, string includeProperties = "")
        {
            return new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "testTeam1",
                    CityId = 1
                },
                new Team
                {
                    Id = 2,
                    Name = "testTeam1",
                    CityId = 1
                },
                new Team
                {
                    Id = 3,
                    Name = "testTeam1",
                    CityId = 1
                }
            };
        }

        public Team GetByID(object id)
        {
            if ((int)id == 1)
            {
                return new Team
                {
                    Id = 1,
                    Name = "testTeam1",
                    CityId = 1
                };
            }
            else
            {
                throw new Exception("Not found!");
            }
        }

        public Team Insert(Team entity)
        {
            return entity;
        }

        public void Update(Team entityToUpdate)
        {
        }
    }
}
