using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<EditorController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, ILogger<EditorController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new ApplicationUser()
            {
                UserName = registerViewModel.Email,
                name = registerViewModel.name,
                surname = registerViewModel.surname,
                age = registerViewModel.age,
                gender = registerViewModel.gender,
                Email = registerViewModel.Email,
                department = registerViewModel.department,
                roomNo = registerViewModel.roomNo,
                title = registerViewModel.title,
            };
            var result = _userManager.CreateAsync(user, registerViewModel.password).Result;
            if (result.Succeeded)
            {

                if (!_roleManager.RoleExistsAsync(registerViewModel.role).Result)
                {
                    ApplicationRole role = new ApplicationRole()
                    {
                        Name = registerViewModel.role
                    };
                    IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                }
                _userManager.AddToRoleAsync(user, registerViewModel.role).Wait();
                _logger.LogInformation(User.Identity.Name+", bir kullanıcı oluşturdu - "+user.Email);
                TempData.Add("Success", "Başarılı işlem, kullanıcı oluşturuldu");
                return RedirectToAction("detailuser", "user", new {id = user.Id});
            }
            TempData.Add("Alert", "Başarısız giriş! Bilgileri kontrol edip tekrar deneyiniz");

            return View();
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            var user = await _userManager.FindByEmailAsync(loginViewModel.EMail);
            if (user == null)
            {
                TempData.Add("Alert", "Başarısız giriş! E-mail veya parolayı kontrol edin!");
                return View(loginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                TempData.Add("Success", $"Hoşgeldin {user.name}");
                _logger.LogInformation(User.Identity.Name + ", oturum açtı");
                return RedirectToAction("Index", "Home");
            }

            TempData.Add("Alert", "Başarısız giriş! E-mail veya parolayı kontrol edin!");
            return View(loginViewModel);
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
