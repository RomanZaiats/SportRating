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
using AutoMapper;
using Intefaces.Services;
using Interfaces.DAL;

namespace CCTService
{
    public class CCTService: ICCTService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CCTService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public static void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            if(!container.IsRegistered<IMapper>()){
                MapperConfig.RegisterMapping();
                container.RegisterType<IMapper, Mapper>();
            }
        }

        #region Add

        public ServiceRespone AddCity(CityDto city)
        {
            City inserted;
            try
            {
                inserted = _unitOfWork.CityRepository.Insert(_mapper.Map<CityDto, City>(city));
                _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
     
            return new ServiceRespone { ResponseCode = ResponeCode.DbRecordCreated, Value = _mapper.Map<City, CityDto>(inserted) };
        }

        public ServiceRespone AddCountry(CountryDto country)
        {
            Country inserted;
            try
            {
                inserted = _unitOfWork.CountryRepository.Insert(_mapper.Map<CountryDto, Country>(country));
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }

            return new ServiceRespone { ResponseCode = ResponeCode.DbRecordCreated, Value = _mapper.Map<Country, CountryDto>(inserted) };
        }

        public ServiceRespone AddTeam(TeamDto team)
        {
            Team inserted;
            try
            {
                inserted = _unitOfWork.TeamRepository.Insert(_mapper.Map<TeamDto, Team>(team));
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }

            return new ServiceRespone { ResponseCode = ResponeCode.DbRecordCreated, Value = _mapper.Map<Team, TeamDto>(inserted) };
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
                    Value = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(_unitOfWork.CountryRepository.Get())
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone GetAllTeams()
        {
            try
            {
                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.Success,
                    Value = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamDto>>(_unitOfWork.TeamRepository.Get())
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone GetAllCities()
        {
            try
            {
                return new ServiceRespone {
                    ResponseCode = ResponeCode.Success,
                    Value = _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(_unitOfWork.CityRepository.Get())
                };
            }
            catch(Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        #endregion

        #region Get

        public ServiceRespone GetCity(int id)
        {
            try
            {
                var city = _mapper.Map<City, CityDto>(_unitOfWork.CityRepository.GetByID(id));
                return new ServiceRespone
                {
                    ResponseCode = city == null ? ResponeCode.NotFound : ResponeCode.Success,
                    Value = city
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone GetCountry(int id)
        {
            try
            {
                var country = _mapper.Map<Country, CountryDto>(_unitOfWork.CountryRepository.GetByID(id));

                return new ServiceRespone
                {
                    ResponseCode = country == null ? ResponeCode.NotFound : ResponeCode.Success,
                    Value = country
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone GetTeam(int id)
        {
            try
            {
                var team = _mapper.Map<Team, TeamDto>(_unitOfWork.TeamRepository.GetByID(id));
                return new ServiceRespone
                {
                    ResponseCode = team == null ? ResponeCode.NotFound : ResponeCode.Success,
                    Value = team
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        #endregion

        #region Remove

        public ServiceRespone RemoveCity(int id)
        {
            try
            {
                _unitOfWork.CityRepository.Delete(id);
                _unitOfWork.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.DbRecordDeleted,
                    Value = null
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone RemoveCountry(int id)
        {
            try
            {
                _unitOfWork.CountryRepository.Delete(id);
                _unitOfWork.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.DbRecordDeleted,
                    Value = null
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone RemoveTeam(int id)
        {
            try
            {
                _unitOfWork.TeamRepository.Delete(id);
                _unitOfWork.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.DbRecordDeleted,
                    Value = null
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        #endregion

        #region Update

        public ServiceRespone UpdateCity(CityDto city)
        {
            try
            {
                var cityToUpdate = _unitOfWork.CityRepository.GetByID(city.Id);
                cityToUpdate.Name = city.Name;
                cityToUpdate.CountryId = city.CountryId;
                _unitOfWork.CityRepository.Update(cityToUpdate);
                _unitOfWork.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.DbRecordUpdated,
                    Value = city
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone UpdateCountry(CountryDto country)
        {
            try
            {
                _unitOfWork.CountryRepository.Update(_mapper.Map<CountryDto, Country>(country));
                _unitOfWork.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.DbRecordUpdated,
                    Value = country
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        public ServiceRespone UpdateTeam(TeamDto team)
        {
            try
            {
                _unitOfWork.TeamRepository.Update(_mapper.Map<TeamDto, Team>(team));
                _unitOfWork.Save();

                return new ServiceRespone
                {
                    ResponseCode = ResponeCode.DbRecordUpdated,
                    Value = team
                };
            }
            catch (Exception ex)
            {
                return new ServiceRespone { ResponseCode = ResponeCode.DbError, Value = null, ErrorMessage = ex.Message };
            }
        }

        #endregion
    }
}

