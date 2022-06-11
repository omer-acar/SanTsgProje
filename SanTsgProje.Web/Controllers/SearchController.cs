using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchingService _searching;
        private readonly IPriceSearchingService _priceSearching;
        private readonly IProductInfoService _productInfoService;

        public SearchController(ISearchingService searching, IPriceSearchingService priceSearching, IProductInfoService productInfoService)
        {
            _searching = searching;
            _priceSearching = priceSearching;
            _productInfoService = productInfoService;
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

        public async Task<IActionResult> GetProductInfo(string HotelId, string OfferId) // Price Search with City Id
        {
            var hoteldetail = await _productInfoService.GetProductInfo(HotelId, OfferId);
            return View(hoteldetail);
        }
    }
}
