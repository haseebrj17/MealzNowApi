using System;
using Newtonsoft.Json;

namespace MealzNow.Core.Dto
{
    public class CountriesDto
    {
        public List<CountryDto> Country { get; set; } = new List<CountryDto>();
    }

    public class CountryDto
    {
        public string Name { get; set; } = null!;

        public List<StateDto> States { get; set; } = new List<StateDto>();
    }

    public class StateDto
    {
        public string Name { get; set; } = null!;

        public List<CityNameDto> Cities { get; set; } = new List<CityNameDto>();
    }

    public class CityNameDto
    {
        public string Name { get; set; } = null!;
    }
}

