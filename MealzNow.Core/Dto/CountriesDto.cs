using System;
using Newtonsoft.Json;

namespace MealzNow.Core.Dto
{
    public class CountriesDto
    {
        [JsonProperty("country")]
        public List<Country> Country { get; set; } = new List<Country>();
    }

    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("states")]
        public List<State> States { get; set; } = new List<State>();
    }

    public class State
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("cities")]
        public List<CityName> Cities { get; set; } = new List<CityName>();
    }

    public class CityName
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}

