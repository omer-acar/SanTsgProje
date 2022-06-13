using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Domain.Users;
using SanTsgProje.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchingService _searching;
        private readonly IApiService _authentication;

        public HomeController(ILogger<HomeController> logger, ISearchingService searching, IApiService authentication)
        {
            _logger = logger;
            _searching = searching;
            _authentication = authentication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Search(string Query)
        {
            //try
            //{
                
            //}
            //catch (Exception e)
            //{

            //    return View("~/Views/Error/ErrorSearch.cshtml", e.Message);
            //}
            // Checking Token , If token expired return true or not return false 
            var isTokenExpired = _authentication.IsTokenExpired();
            if (isTokenExpired == true)
            {
                await _authentication.Authentication();
                // Find City with Query
                var result = await _searching.SearchCities(Query);
                // Show Cities
                return View(result);

            }
            else if (isTokenExpired == false)
            {
                // Find City with Query
                var result = await _searching.SearchCities(Query);
                // Show Cities
                return View(result);
            }
            return View();
        }
    }
}
