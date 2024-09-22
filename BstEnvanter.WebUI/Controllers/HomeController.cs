using BstEnvanter.Business.Abstract;
using BstEnvanter.Business.Concrete;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BstEnvanter.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IStatusService _statusService;
        private ICategoryService _categoryService;
        private IProductService _productService;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICampusService _campusService;
        public HomeController(ICategoryService categoryService, IStatusService statusService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, ICampusService campusService)
        {
            _categoryService = categoryService;
            _statusService = statusService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _campusService = campusService;
        }


        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                status = _statusService.getAllWithDetails(),
                categories = _categoryService.getAll(),
                campus = _campusService.getAll(),
            };
            return View(model);
        }


        //public async Task<IActionResult>index()
        //{
        //    var user = await _userManager.GetUserAsync(User);

        //    HttpContext.Session.SetString("fullName", $"{user.name} {user.surname}");
        //    return View();
        //}






        //public IActionResult Index()
        //{
        //    var lstModel = new List<IndexViewModel>();
        //    var categories = _categoryService.getAll();
        //    foreach (var item in categories)
        //    {
        //        var status = _statusService.getAllWithDetailsByCategory(item.id);

        //        lstModel.Add(new IndexViewModel
        //        {
        //            DimensionOne = item.name,
        //            Quantity = status.Count
        //        });
        //    }
        //    return View(lstModel);
        //}
    }
}
