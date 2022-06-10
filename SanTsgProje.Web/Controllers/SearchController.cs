using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchingService _searching;
        private readonly IPriceSearchingService _priceSearching;

        public SearchController(ISearchingService searching, IPriceSearchingService priceSearching)
        {
            _searching = searching;
            _priceSearching = priceSearching;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PriceSearch(string CityId) // Price Search with City Id
        {
            var hotels = await _priceSearching.PriceSearch(CityId);
            return View(hotels);
        }
    }
}
