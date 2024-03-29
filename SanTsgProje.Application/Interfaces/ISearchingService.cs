﻿using SanTsgProje.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface ISearchingService
    {
        Task<List<CityInfos>> SearchCities(string query);
    }
}
