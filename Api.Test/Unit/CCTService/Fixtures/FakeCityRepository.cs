using DB.Entities;
using Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Unit.CCTServiceTest.Fixtures
{
    class FakeCityRepository : IGenericRepository<City>
    {
        public void Delete(object id)
        {
        }

        public void Delete(City entityToDelete)
        {
        }

        public IEnumerable<City> Get(System.Linq.Expressions.Expression<Func<City, bool>> filter = null, Func<IQueryable<City>, IOrderedQueryable<City>> orderBy = null, string includeProperties = "")
        {
            return new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "test1",
                    CountryId = 1
                },
                new City
                {
                    Id = 2,
                    Name = "test2",
                    CountryId = 2
                },
                new City
                {
                    Id = 3,
                    Name = "test3",
                    CountryId = 2
                }
            };
        }

        public City GetByID(object id)
        {
            if ((int)id == 1)
            {
                return new City
                {
                    Id = 1,
                    Name = "testCity1",
                    CountryId = 1
                };
            }
            else
            {
                throw new Exception("Not found!");
            }
        }

        public City Insert(City entity)
        {
            return entity;
        }

        public void Update(City entityToUpdate)
        {
        }
    }
}
