using Company.Route.DAL.Models;
using Company.Route.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager) 
        {
			_userManager = userManager;
		}

		public UserManager<ApplicationUser> UserManager { get; }

		//[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
            //code to registration
            if (ModelState.IsValid) // server side validation
            {
               var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(model.Email);

                    if (user == null)
                    {
                        user = new ApplicationUser()
                        {
                            UserName = model.UserName,
                            Email = model.Email,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            IsAgree = model.IsAgree
                        };
                        var result = await _userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("SignIn");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
					ModelState.AddModelError(string.Empty, "Email is already exists");
					return View(model);
				}
               
                ModelState.AddModelError(string.Empty, "username is already exists");
            }
			return View(model);
		}
	}
}
