using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Domain.Users;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class UserController : Controller
    {       
        // User service posta icin
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // Users List
        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }

        //Create GET
        public IActionResult Create()
        {
            return View();
        }

        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
           _userService.Add(user);
           await _userService.SendPost(user);
           return RedirectToAction("Index");
        }

        //Change Status Aktif ve Pasif hale gitirebilme
        public IActionResult ChangeStatus(int? id)
        {
            _userService.ChangeStatus(id);
            return RedirectToAction("Index");
        }

        //Edit GET
        public IActionResult Edit(int? id)
        {
            if (id.GetValueOrDefault() == 0)
                return NotFound();
            var user = _userService.Get(id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // Edit POST
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Edit(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Delete GET
        public IActionResult Delete(int? id)
        {
            var user = _userService.Get(id);
            
            if (user == null)
                return NotFound();
            return View(user);
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            _userService.Remove(user);

            return RedirectToAction("Index");
        }

    }
}
