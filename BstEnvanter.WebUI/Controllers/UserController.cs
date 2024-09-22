using BstEnvanter.Business.Concrete;
using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<EditorController> _logger;


        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, ILogger<EditorController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            await _userManager.DeleteAsync(user);
            _logger.LogInformation(User.Identity.Name + ", bir kullanıcı sildi - " + user.Email);
            return RedirectToAction("listofusers", "user");
        }
        [Authorize(Roles = "admin")]
        public IActionResult ListOfUsers()
        {
            var currentUser = _userManager.GetUserId(User);
            var model = new ListOfUserViewModel()
            {
                users = _userManager.Users.Where(x => x.Id != currentUser && x.Email!="bst@iku.edu.tr"),
            };
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DetailUser(string id)
        {
            var getUser = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var model = new DetailUserViewModel()
            {
                user = getUser,
                role = await _userManager.GetRolesAsync(getUser)
            };
            return View(model);
        }
        public IActionResult UpdateUser(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var model = new UpdateUserViewModel()
            {
                user = user
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var getUser = await _userManager.FindByIdAsync(updateUserViewModel.user.Id);

            if (ModelState.IsValid)
            {
                getUser.UserName = updateUserViewModel.user.UserName;
                getUser.name = updateUserViewModel.user.name;
                getUser.surname = updateUserViewModel.user.surname;
                getUser.age = updateUserViewModel.user.age;
                getUser.gender = updateUserViewModel.user.gender;
                getUser.department = updateUserViewModel.user.department;
                getUser.roomNo = updateUserViewModel.user.roomNo;
                getUser.Email = updateUserViewModel.user.Email;
                await _userManager.UpdateAsync(getUser);
            }
            _logger.LogInformation(User.Identity.Name + ", bir kullanıcı güncelledi - " + getUser.Email);
            return RedirectToAction("detailuser", new { id = getUser.Id });
        }

        public async Task<IActionResult> Profile()
        {
            var model = new ProfileViewModel()
            {
                user = await _userManager.GetUserAsync(User),

            };
            model.role = await _userManager.GetRolesAsync(model.user);
            return View(model);
        }
        public async Task<IActionResult> UpdateProfile()
        {
            var model = new UpdateUserViewModel()
            {
                user = await _userManager.GetUserAsync(User),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateUserViewModel updateUserViewModel)
        {
            var getUser = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                getUser.UserName = updateUserViewModel.user.UserName;
                getUser.name = updateUserViewModel.user.name;
                getUser.surname = updateUserViewModel.user.surname;
                getUser.age = updateUserViewModel.user.age;
                getUser.gender = updateUserViewModel.user.gender;
                getUser.department = updateUserViewModel.user.department;
                getUser.roomNo = updateUserViewModel.user.roomNo;
                getUser.Email = updateUserViewModel.user.Email;
                getUser.title = updateUserViewModel.user.title;
                await _userManager.UpdateAsync(getUser);
                _logger.LogInformation(User.Identity.Name + ", bilgilerini güncelledi");
                return RedirectToAction("profile");
            }
            return View();
        }
   
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);

            await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _logger.LogInformation(User.Identity.Name + ", şifre değiştirdi");
                return RedirectToAction("profile");
            }

            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult ResetPassword(string id)
        {
            var model = new ResetUserPasswordViewModel()
            {
                id = id,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, ResetUserPasswordViewModel resetUserPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, resetUserPasswordViewModel.newPassword);
                _logger.LogInformation(User.Identity.Name + ", bir kullanıcının şifresini sıfırladı - " + user.Email);
                return RedirectToAction("listofusers");

            }
            return View();
        }

        
    }



}
