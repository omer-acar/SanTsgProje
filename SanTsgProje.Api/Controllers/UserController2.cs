using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Domain.Users;
using System.Threading.Tasks;

namespace SanTsgProje.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController2 : Controller
    {
        private readonly IUserService _userService;
        public UserController2(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {

            return Json(null);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

    }
}
