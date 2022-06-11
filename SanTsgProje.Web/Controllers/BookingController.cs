using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBeginTransactionService _beginTransactionservice;

        public BookingController(IBeginTransactionService beginTransactionservice)
        {
            _beginTransactionservice = beginTransactionservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Boking(string FirstName , string LastName , string Email , string OfferId)
        {
            await _beginTransactionservice.BeginTransaction();

            return View();
        }
    }

}
