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
    class FakeCountryRepository : IGenericRepository<Country>
    {
        public void Delete(object id)
        {
        }

        public void Delete(Country entityToDelete)
        {
        }

        public IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = null, string includeProperties = "")
        {
            return new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "testCountry1"
                },
                new Country
                {
                    Id = 2,
                    Name = "testCountry2"
                }
            };
        }

        public Country GetByID(object id)
        {
            if ((int)id == 1)
            {
                return new Country
                {
                    Id = 1,
                    Name = "testCountry1"
                };
            }
            else
            {
                throw new Exception("Not found!");
            }
        }

        public Country Insert(Country entity)
        {
            return entity;
        }

        public void Update(Country entityToUpdate)
        {
        }
    }
}
