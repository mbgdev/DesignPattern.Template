using DesignPattern.Template.DAL.Entities;
using DesignPattern.Template.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Template.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(AppUserViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Name = viewModel.Name,
                    Surname = viewModel.Surname,
                 

                };


                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                   return RedirectToAction("Login","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }

            return View(viewModel);
        }
    }
}
