using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Services;


namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {

            //get All Employees

            var userService = new UserService();
            var users = await userService.GetAll();

            return View(users);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var userService = new UserService();
            var user = await userService.GetById(id);

            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var user = Utility.GenerateFakerData();
            //return View(user); 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var userService = new UserService();
            await userService.CreateAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var userService = new UserService();
            var user = await userService.GetById(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            var userService = new UserService();
            await userService.UpdateAsync(user);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var userService = new UserService();
            var user = await userService.GetById(id);

            return View(user);
        }


        public async Task<IActionResult> DeleteUser(int id)
        {
            var userService = new UserService();
            await userService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        //public IActionResult Index()
        //{

        //    //get All Employees

        //    var userService = new UserService();
        //    var users = userService.GetAll();

        //    return View(users);
        //}

        //public IActionResult Details(int id)
        //{
        //    var userService = new UserService();
        //    var user = userService.GetById(id);

        //    return View(user);
        //}
    }
}
