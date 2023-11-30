using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MealzNow.Db.Repositories
{
    public interface ICityRepository
    {
        public Task<Guid?> GetCityIdByName(string cityName, string stateName, string countryName);
        public Task<Guid> AddCity(string cityName, string stateName, string countryName);
        Task<CityName?> GetCityById(Guid cityId);

    }

    public class CityRepository : ICityRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;

        public CityRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<Guid> AddCity(string cityName, string stateName, string countryName)
        {
            var countriesData = await _mealzNowDataBaseContext.Country
                   .Include(c => c.Country)
                       .ThenInclude(country => country.States)
                           .ThenInclude(state => state.Cities)
                   .FirstOrDefaultAsync();

            if (countriesData == null)
            {
                countriesData = new Countries { Country = new List<Country> { new Country { Name = countryName } } };
                await _mealzNowDataBaseContext.Country.AddAsync(countriesData);
            }

            var state = countriesData.Country.SelectMany(c => c.States).FirstOrDefault(s => s.Name.ToLower() == stateName.ToLower());
            if (state == null)
            {
                state = new State { Name = stateName };
                countriesData.Country.FirstOrDefault()?.States.Add(state);
            }

            var city = state.Cities.FirstOrDefault(c => c.Name.ToLower() == cityName.ToLower());
            if (city == null)
            {
                city = new CityName { Name = cityName };
                state.Cities.Add(city);
            }

            await _mealzNowDataBaseContext.SaveChangesAsync();
            return city.Id;
        }

        public async Task<Guid?> GetCityIdByName(string cityName, string stateName, string countryName)
        {
            var countriesData = await _mealzNowDataBaseContext.Country
                .Include(c => c.Country)
                    .ThenInclude(country => country.States)
                        .ThenInclude(state => state.Cities)
                .FirstOrDefaultAsync();

            var country = countriesData?.Country.FirstOrDefault(c => c.Name.ToLower() == countryName.ToLower());
            var state = country?.States.FirstOrDefault(s => s.Name.ToLower() == stateName.ToLower());
            var city = state?.Cities.FirstOrDefault(c => c.Name.ToLower() == cityName.ToLower());

            return city?.Id;
        }

        public async Task<CityName?> GetCityById(Guid cityId)
        {
            var city = await _mealzNowDataBaseContext.Country
                        .Include(c => c.Country)
                            .ThenInclude(country => country.States)
                                .ThenInclude(state => state.Cities)
                        .SelectMany(c => c.Country)
                            .SelectMany(country => country.States)
                                .SelectMany(state => state.Cities)
                        .FirstOrDefaultAsync(city => city.Id == cityId);

            return city;
        }
    }
}