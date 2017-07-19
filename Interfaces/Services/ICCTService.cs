using DTOs.CCTService;
using ServicesHelper;

namespace Intefaces.Services
{
    public interface ICCTService
    {
        ServiceRespone GetAllCities();

        ServiceRespone GetCity(int id);

        ServiceRespone AddCity(CityDto city);

        ServiceRespone RemoveCity(int id);

        ServiceRespone UpdateCity(CityDto city);

        ServiceRespone GetAllCountries();

        ServiceRespone GetCountry(int id);

        ServiceRespone AddCountry(CountryDto city);

        ServiceRespone RemoveCountry(int id);

        ServiceRespone UpdateCountry(CountryDto city);

        ServiceRespone GetAllTeams();

        ServiceRespone GetTeam(int id);

        ServiceRespone AddTeam(TeamDto city);

        ServiceRespone RemoveTeam(int id);

        ServiceRespone UpdateTeam(TeamDto city);
    }
}