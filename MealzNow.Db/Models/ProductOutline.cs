using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MealzNow.Db.Models
{
    public class ProductOutline : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}