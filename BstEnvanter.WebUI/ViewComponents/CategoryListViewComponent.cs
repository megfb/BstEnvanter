using BstEnvanter.Business.Abstract;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BstEnvanter.WebUI.ViewComponents
{
    public class CategoryListViewComponent: ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new ListOfCategoryViewModel()
            {
                category = _categoryService.getAll()
                //currentCategory = Convert.ToInt32(HttpContext.Request.Query["Category"])
            };
            return View(model);
        }
    }
}
