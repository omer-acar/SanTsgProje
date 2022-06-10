using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models
{
    public class CityInfos
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public CityInfos(string id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;  
        }
    }
}
