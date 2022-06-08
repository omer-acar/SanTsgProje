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
        private readonly IAuthenticationService _authentication;

        public HomeController(ILogger<HomeController> logger, ISearchingService searching, IAuthenticationService authentication)
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
            var isTokenExpired = _authentication.IsTokenExpired();
            if (isTokenExpired == true)
            {
                await _authentication.Authentication();
                var result = await _searching.Search(Query);
                return View(result);

            }
            else if (isTokenExpired == false)
            {
                var result = await _searching.Search(Query);
                return View(result);
            }
            return View();
        }
    }
}
