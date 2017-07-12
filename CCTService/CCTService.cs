using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.CCTService;
using ServicesHelper;
using Microsoft.Practices.Unity;
using DB.Entities;

namespace CCTService
{
    public class CCTService: ICCTService
    {
        private IUnitOfWork db;
        public IUnityContainer DependencyResolver { get; private set; }
        public CCTService()
        {
            DependencyResolver = new UnityContainer();
            DependencyResolver.RegisterType<IUnitOfWork, UnitOfWork>();
            db = DependencyResolver.Resolve<IUnitOfWork>();
        }

        //public CCTService(IUnityContainer container)
        //{
        //    _container = container;
        //    if (!_container.IsRegistered(typeof(IUnitOfWork)))
        //    {
        //        throw new ArgumentException("Granted container does not have register the required dependencies");
        //    }
        //    db = _container.Resolve<IUnitOfWork>();
        //}

        public void SetDependencyResolver(IUnityContainer container)
        {
            DependencyResolver.Dispose();
            DependencyResolver = container;
            DependencyResolver.RegisterType<IUnitOfWork, UnitOfWork>();
            db = DependencyResolver.Resolve<IUnitOfWork>();
        }

        #region Add

        public ServiceRespone AddCity(CityDto city)
        {
            try
            {
                db.CityRepository.Insert((City)city);
                db.Save();
            }
            catch(Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex };
            }
     
            return new ServiceRespone { ResponseCode = ResponeCode.Success, Value = city };
        }

        public ServiceRespone AddCountry(CountryDto country)
        {
            try
            {
                db.CountryRepository.Insert((Country)country);
                db.Save();
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex };
            }

            return new ServiceRespone { ResponseCode = ResponeCode.Success, Value = country };
        }

        public ServiceRespone AddTeam(TeamDto team)
        {
            try
            {
                db.TeamRepository.Insert((Team)team);
                db.Save();
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex };
            }

            return new ServiceRespone { ResponseCode = ResponeCode.Success, Value = team };
        }

        #endregion

        #region GetAll

        public ServiceRespone GetAllCountries()
        {
            try
            {
                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = db.CountryRepository.Get().Select(i => (CountryDto)i).ToList()
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone GetAllTeams()
        {
            try
            {
                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = db.TeamRepository.Get().Select(i => (TeamDto)i).ToList()
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone GetAllCities()
        {
            try
            {
                return new ServiceRespone {
                    ResponseCode = ResponeCode.Success,
                    Value = db.CityRepository.Get().Select(i => (CityDto)i).ToList()
                };
            }
            catch(Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        #endregion

        #region Get

        public ServiceRespone GetCity(int id)
        {
            try
            {
                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = (CityDto)db.CityRepository.GetByID(id)
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone GetCountry(int id)
        {
            try
            {
                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = (CountryDto)db.CountryRepository.GetByID(id)
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone GetTeam(int id)
        {
            try
            {
                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = (TeamDto)db.TeamRepository.GetByID(id)
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        #endregion

        #region Remove

        public ServiceRespone RemoveCity(int id)
        {
            try
            {
                db.CityRepository.Delete(id);
                db.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = null
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone RemoveCountry(int id)
        {
            try
            {
                db.CountryRepository.Delete(id);
                db.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = null
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone RemoveTeam(int id)
        {
            try
            {
                db.TeamRepository.Delete(id);
                db.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = null
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        #endregion

        #region Update

        public ServiceRespone UpdateCity(CityDto city)
        {
            try
            {
                db.CityRepository.Update((City)city);
                db.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = city
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone UpdateCountry(CountryDto country)
        {
            try
            {
                db.CountryRepository.Update((Country)country);
                db.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = country
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        public ServiceRespone UpdateTeam(TeamDto team)
        {
            try
            {
                db.TeamRepository.Update((Team)team);
                db.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = team
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = ex.Message };
            }
        }

        #endregion
    }
}

