using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MealzNow.Db.Models
{
    public class CountriesWrapper
    {
        [JsonProperty("country")]
        public List<Country> Countries { get; set; } = new List<Country>();
    }

    public class Country : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("states")]
        public List<State> States { get; set; } = new List<State>();
    }

    public class State : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cities")]
        public List<CityName> Cities { get; set; } = new List<CityName>();
    }

    public class CityName : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
