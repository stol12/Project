namespace NoLink.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using NoLink.Data;
    using NoLink.Services.UserService;
    using NoLink.Services.UserService.Models;

    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService services;
        private readonly Context context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(IUserService services, IMapper mapper, Context context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.services = services;
            this.mapper = mapper;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new UserLoginModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost, AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.services.GetUserByUsername(model.UserName);
                var hashedPassword = this.services.HashPasswordOnRegister(model.Password);

                if(user == null || user.UserName != model.UserName || user.Password != hashedPassword)
                {
                    throw new InvalidOperationException("Wrong Credentials fella");
                }

                var result = await this.signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {   
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid Login Attempt");
            return View(model);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            UserRegisterModel model = new UserRegisterModel();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {   
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = services.HashPasswordOnRegister(model.Password),

            };

            if (this.services.UserExists(model.UserName))
            {
                throw new InvalidOperationException("User already exists");
            }

            var result = await userManager.CreateAsync(user, user.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(model);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
