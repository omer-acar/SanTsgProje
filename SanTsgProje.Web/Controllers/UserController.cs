using Microsoft.AspNetCore.Mvc;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Data;
using SanTsgProje.Domain.Users;
using System.Linq;
using System.Threading.Tasks;

namespace SanTsgProje.Web.Controllers
{
    public class UserController : Controller
    {
        // User service posta icin
        private readonly IUserService _userService;
        // Database
        private readonly ProjeDbContext _context;
        public UserController(ProjeDbContext context , IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        // Users List
        public IActionResult Index()
        {
            var kullanicilar = _context.Users.ToList();
            return View(kullanicilar);
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
            
                _context.Users.Add(user);
                _context.SaveChanges();
            await _userService.CreateUser(user);
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> Create(User user)
        //{
        //    await _userService.CreateUser(user);
        //    return Ok();
        //}
        //Change Status Aktif ve Pasif hale gitirebilme
        public IActionResult ChangeStatus(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else if (user.IsActive == false)
            {
                user.IsActive = true;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit GET
        public IActionResult Edit(int? id)
        {
            if (id.GetValueOrDefault() == 0)
                return NotFound();

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

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
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        // Delete GET
        public IActionResult Delete(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            
            if (user == null)
                return NotFound();
            return View(user);
        }
        // Delete POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
