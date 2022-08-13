using BstEnvanter.Business.Abstract;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class EditorController : Controller
    {

        private IBrandService _brandService;
        private ICategoryService _categoryService;
        private IModelService _modelService;
        private IProductService _productService;
        private IDepartmentService _departmentService;
        private ICLocationService _clocationService;
        private ICampusService _campusService;
        private ISexService _sexService;
        private IPersonelService _personelService;
        private IStatusService _statusService;
        private ICommonService _commonService;

        public EditorController(IBrandService brandService, ICategoryService categoryService, IModelService modelService, IProductService productService,
            IDepartmentService departmentService, ICLocationService cLocationService, ICampusService campusService, ISexService sexService, IPersonelService personelService,
            IStatusService statusService, ICommonService commonService)
        {
            _brandService = brandService;
            _categoryService = categoryService;
            _modelService = modelService;
            _productService = productService;
            _departmentService = departmentService;
            _clocationService = cLocationService;
            _campusService = campusService;
            _sexService = sexService;
            _personelService = personelService;
            _statusService = statusService;
            _commonService = commonService;
        }
        public IActionResult Index()
        {
            return View();
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   BRAND PROCESSES   #########################

        public IActionResult AddBrand()
        {
            var model = new AddBrandViewModel()
            {
                brand = new Brand()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.add(brand);
                TempData.Add("Success", $"New brand succesfully added");
                return RedirectToAction("addbrand");
            }
            TempData.Add("Alert", $"New brand could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfBrand()
        {
            var model = new ListBrandViewModel()
            {
                brand = _brandService.getAll()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var model = new UpdateBrandViewModel()
            {
                Brand = _brandService.get(id)
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.update(brand);
                TempData.Add("Success", $"{brand.name} succesfully updated");
                return RedirectToAction("ListOfBrand");
            }
            TempData.Add("Alert", $"{brand.name} could not be updated");
            return RedirectToAction("updatebrand", brand.id);
        }
        public IActionResult DeleteBrand(int id)
        {
            _brandService.remove(id);
            TempData.Add("Success", $"A brand succesfully deleted");
            return RedirectToAction("listofbrand");
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   CATEGORY PROCESSES   ######################

        public IActionResult AddCategory()
        {
            var model = new AddCategoryViewModel()
            {
                category = new Category()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.add(category);
                TempData.Add("Success", $"New category succesfully added");
                return RedirectToAction("listofcategory");
            }
            TempData.Add("Alert", $"New category could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfCategory()
        {
            var model = new ListOfCategoryViewModel()
            {
                category = _categoryService.getAll()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var model = new UpdateCategoryViewModel()
            {
                category = _categoryService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.update(category);
                TempData.Add("Success", $"{category.name} succesfully updated");
                return RedirectToAction("listofcategory");
            }
            TempData.Add("Alert", $"{category.name} could not be updated");
            return RedirectToAction("updatecategory", category.id);
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.remove(id);
            TempData.Add("Success", $"A category succesfully deleted");
            return RedirectToAction("listofcategory");

        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Model   ###################################

        public IActionResult AddModel()
        {
            var model = new AddModelViewModel()
            {
                model = new Model()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelService.add(model);
                TempData.Add("Success", $"New model succesfully added");
                return RedirectToAction("listofmodel");
            }
            TempData.Add("Alert", $"New model could not be added");
            return View();
        }
        public IActionResult ListOfModel()
        {
            var model = new ListOfModelViewModel()
            {
                model = _modelService.getAll()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateModel(int id)
        {
            var model = new UpdateModelViewModel()
            {
                model = _modelService.get(id)
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelService.update(model);
                TempData.Add("Success", $"{model.name} succesfully updated");
                return RedirectToAction("listofmodel");
            }
            TempData.Add("Alert", $"{model.name} could not be updated");
            return RedirectToAction("updatemodel", model.id);
        }
        public IActionResult DeleteModel(int id)
        {
            _modelService.remove(id);
            TempData.Add("Success", $"A model succesfully deleted");
            return RedirectToAction("listofmodel");
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Product   #################################

        public IActionResult AddProduct()
        {
            var model = new AddProductViewModel()
            {
                status = new Status(),
                product = new Product(),
                category = _categoryService.getAll(),
                brand = _brandService.getAll(),
                model = _modelService.getAll(),
                campus = _campusService.getAll(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.add(status);
                TempData.Add("Success", $"New product succesfully added");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"New product could not be added");
            return View();
        }
        public IActionResult ListOfProduct()
        {
            var model = new ListOfProductViewModel()
            {
                product = _statusService.getAllWithDetails()
            };

            return View(model);
        }
        public IActionResult UpdateProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                product = _productService.get(id),
                category = _categoryService.getAll(),
                brand = _brandService.getAll(),
                model = _modelService.getAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.update(product);
                TempData.Add("Success", $"{product.name} succesfully updated");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"{product.name} could not be updated");
            return RedirectToAction("updateproduct", product.id);
        }
        public IActionResult DeleteProduct(int id,int productId)
        {
            _statusService.remove(id);
            _productService.remove(productId);
            TempData.Add("Success", $"A product succesfully deleted");
            return RedirectToAction("listofproduct");
        }
        public IActionResult DetailProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                status = _statusService.get(id),
            };
            return View(model);
        }
        public IActionResult AddProductAtPersonel(int id)
        {
            var model = new AddToPersonelViewModel()
            {
                status = _statusService.get(id),
                personel = _personelService.getAll(),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProductAtPersonel(Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.update(status);
                TempData.Add("Success", $"The product succesfully added to personel");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"The product could not be added to personel");
            return View();
        }
        public IActionResult ListofProductAtPersonel()
        {
            var model = new ListOfProductAtPersonelViewModel()
            {
                product = _statusService.getAllWithDetails()

            };
            return View(model);

        }
        public IActionResult DeleteProductAtPersonel(int id)
        {
            var model = _statusService.getStatus(id);
            model.personelId = null;
            _statusService.update(model);
            TempData.Add("Success", $"The product succesfully deleted from personel");
            return RedirectToAction("listofproductatpersonel");
        }
        [HttpGet]
        public IActionResult UpdateProductAtPersonel(int id)
        {
            var model = new UpdateProductAtPersonelViewModel()
            {
                status = _statusService.get(id),
                campus = _campusService.getAll(),
                personel = _personelService.getAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductAtPersonel(Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.update(status);
                int id = status.id;
                TempData.Add("Success", $"The product succesfully updated");
                return RedirectToAction("listofproductatpersonel");
            }
            TempData.Add("Alert", $"The product could not be updated");
            return View();
        }
        [HttpGet]
        public IActionResult AddCommon(int id)
        {
            var model = new AddCommonViewModel()
            {
                common = new Common(),
                department = _departmentService.getAll(),
                clocation = _clocationService.getAll(),
                id = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCommon(Common common,int id)
        {
            if (ModelState.IsValid)
            {
                _commonService.add(common);
            }
            return RedirectToAction("addproducttocommon", new {id = id,commonId=common.id});
        }
        [HttpGet]
        public IActionResult AddProductToCommon(int id, int commonId)
        {
            var model = new AddProductAtCommonViewModel()
            {
                status = _statusService.get(id),
                common = _commonService.get(commonId),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        public IActionResult AddProductToCommon(Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.update(status);
               
                return RedirectToAction("listofproduct");
            }
            return RedirectToAction("listofproduct");
        }
        public IActionResult ListOfProductAtCommon()
        {
            var model = new ListOfProductAtCommon
            {
                status = _statusService.getAllWithDetails(),
            };
            return View(model);
        }
        public IActionResult DeleteProductAtCommon(int id,int commonId)
        {
            var model = _statusService.getStatus(id);
            model.commonId = null;
            _statusService.update(model);
            _commonService.remove(commonId);
            return RedirectToAction("listofproductatcommon");
        }
        [HttpGet]
        public IActionResult UpdateCommon(int id)
        {
            var model = new AddCommonViewModel()
            {
                common = new Common(),
                department = _departmentService.getAll(),
                clocation = _clocationService.getAll(),
                id = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCommon(Common common, int id)
        {
            if (ModelState.IsValid)
            {
                _commonService.add(common);
            }
            return RedirectToAction("updateproductatcommon", new { id = id, commonId = common.id });
        }
        [HttpGet]
        public IActionResult UpdateProductAtCommon(int id, int commonId)
        {
            var model = new AddProductAtCommonViewModel()
            {
                status = _statusService.get(id),
                common = _commonService.get(commonId),
                campus = _campusService.getAll(),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductAtCommon(Status status, int commonId)
        {
            if (ModelState.IsValid)
            {
                _statusService.update(status);
                _commonService.remove(commonId);
                return RedirectToAction("listofproduct");
            }
            return RedirectToAction("listofproduct");
        }
        // #################################################################

        //------------------------------------------------------------------

        // ###################   Department   ##############################

        public IActionResult AddDepartment()
        {
            var model = new AddDepartmentViewModel()
            {
                department = new Department()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.add(department);
                TempData.Add("Success", $"New department succesfully added");
                return RedirectToAction("listofdepartment");
            }
            TempData.Add("Alert", $"New department could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfDepartment()
        {
            var model = new ListOfDepartmentViewModel()
            {
                department = _departmentService.getAll()
            };
            return View(model);
        }
        public IActionResult UpdateDepartment(int id)
        {
            var model = new UpdateDepartmentViewModel()
            {
                department = _departmentService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.update(department);
                TempData.Add("Success", $"{department.name} succesfully updated");
                return RedirectToAction("listofdepartment");
            }
            TempData.Add("Alert", $"{department.name} could not be updated");
            return RedirectToAction("updatedepartment", department.id);
        }
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.remove(id);
            TempData.Add("Success", $"A department succesfully deleted");
            return RedirectToAction("listofdepartment");
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   CLocation   ###############################

        public IActionResult AddCLocation()
        {
            var model = new AddCLocationViewModel()
            {
                cLocation = new CLocation()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddCLocation(CLocation cLocation)
        {
            if (ModelState.IsValid)
            {
                _clocationService.add(cLocation);
                TempData.Add("Success", $"New CLocation succesfully added");
                return RedirectToAction("listofCLocation");
            }
            TempData.Add("Alert", $"New CLocation could not be added");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfCLocation()
        {
            var model = new ListOfCLocationViewModel()
            {
                cLocation = _clocationService.getAll()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateCLocation(int id)
        {
            var model = new UpdateCLocationViewModel()
            {
                cLocation = _clocationService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCLocation(CLocation cLocation)
        {
            if (ModelState.IsValid)
            {
                _clocationService.update(cLocation);
                TempData.Add("Success", $"{cLocation.name} succesfully updated");
                return RedirectToAction("listofclocation");
            }
            TempData.Add("Alert", $"{cLocation.name} could not be updated");
            return RedirectToAction("updateclocation", cLocation.id);
        }
        public IActionResult DeleteCLocation(int id)
        {
            _clocationService.remove(id);
            TempData.Add("Success", $"A clocation succesfully deleted");
            return RedirectToAction("listofclocation");
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Campus   ##################################

        public IActionResult AddCampus()
        {
            var model = new AddCampusViewModel()
            {
                campus = new Campus()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCampus(Campus campus)
        {
            if (ModelState.IsValid)
            {
                _campusService.add(campus);
                TempData.Add("Success", $"New campus succesfully added");
                return RedirectToAction("listofcampus");
            }
            TempData.Add("Alert", $"New campus could not be added");
            return View();
        }
        public IActionResult ListOfCampus()
        {
            var model = new ListOfCampusViewModel()
            {
                campus = _campusService.getAll(),
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateCampus(int id)
        {
            var model = new UpdateCampusViewModel()
            {
                campus = _campusService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCampus(Campus campus)
        {
            if (ModelState.IsValid)
            {
                _campusService.update(campus);
                TempData.Add("Success", $"{campus.name} succesfully updated");
                return RedirectToAction("listofcampus");
            }
            TempData.Add("Alert", $"{campus.name} could not be updated");
            return RedirectToAction("updateclocation", campus.id);
        }

        public IActionResult DeleteCampus(int id)
        {
            _campusService.remove(id);
            TempData.Add("Success", $"A campus succesfully deleted");
            return RedirectToAction("listofcampus");
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Personel   ################################

        public IActionResult AddPersonel()
        {
            var model = new AddPersonelViewModel()
            {
                personel = new Personel(),
                sex = _sexService.getAll(),
                deparment = _departmentService.getAll(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelService.add(personel);
                TempData.Add("Success", $"New personel succesfully added");
                return RedirectToAction("listofpersonel");
            }
            TempData.Add("Alert", $"New personel could not be added");
            return View();
        }
        public IActionResult ListOfPersonel()
        {
            var model = new ListOfPersonelViewModel()
            {
                personel = _personelService.getAll(),
            };
            return View(model);
        }
        public IActionResult DeletePersonel(int id)
        {
            _personelService.remove(id);
            TempData.Add("Success", $"The Personel succesfully deleted");
            return RedirectToAction("listofpersonel");
        }
        [HttpGet]
        public IActionResult UpdatePersonel(int id)
        {
            var model = new UpdatePersonelViewModel()
            {
                personel = _personelService.get(id),
                sex = _sexService.getAll(),
                department = _departmentService.getAll(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdatePersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelService.update(personel);
                TempData.Add("Success", $"The personel succesfully updated");
                return RedirectToAction("listofpersonel");
            }
            TempData.Add("Alert", $"The personel could not be updated");
            return View();
        }
        [HttpGet]
        public IActionResult DetailPersonel(int id)
        {
            var model = new DetailPersonelViewModel()
            {
                personel = _personelService.get(id),
            };
            return View(model);

        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Status   ##################################

        public IActionResult AddStatus(int id)
        {
            var model = new AddStatusViewModel()
            {
                status = new Status(),
                product = _productService.get(id),
                personel = _personelService.getAll(),
                campus = _campusService.getAll(),

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.add(status);
                RedirectToAction("listofproduct");
            }
            return View();
        }
    }
}
