using SanTsgProje.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Interfaces
{
    public interface IPriceSearchingService
    {
        public Task<List<HotelInfos>> PriceSearch(string CityName);
    }
}
