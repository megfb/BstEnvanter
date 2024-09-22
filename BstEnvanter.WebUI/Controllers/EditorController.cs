using BstEnvanter.Business.Abstract;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BstEnvanter.WebUI.Controllers
{
    [Authorize(Roles = "admin,editor")]

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
        private ICpuService _cpuService;
        private IGpuService _gpuService;
        private IRamService _ramService;
        private IHardDriveService _hardDriveService;
        private IServiceService _serviceService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<EditorController> _logger;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public EditorController(IBrandService brandService, ICategoryService categoryService, IModelService modelService, IProductService productService,
            IDepartmentService departmentService, ICLocationService cLocationService, ICampusService campusService, ISexService sexService, IPersonelService personelService,
            IStatusService statusService, ICommonService commonService, ICpuService cpuService, IGpuService gpuService, IRamService ramService, IHardDriveService hardDriveService,
            IServiceService serviceService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            ILogger<EditorController> logger)
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
            _cpuService = cpuService;
            _gpuService = gpuService;
            _ramService = ramService;
            _hardDriveService = hardDriveService;
            _serviceService = serviceService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
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
                TempData.Add("Success", $"İşlem başarılı, yeni marka eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir marka ekledi - " + brand.name);
                return RedirectToAction("addbrand");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni marka eklenemedi!");
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
                TempData.Add("Success", $"İşlem başarılı, {brand.name} güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir marka güncelleştirdi - " + brand.name);

                return RedirectToAction("ListOfBrand");
            }
            TempData.Add("Alert", $"İşlem başarısız, {brand.name} güncelleştirilemedi!");
            return RedirectToAction("updatebrand", brand.id);
        }
        public IActionResult DeleteBrand(int id)
        {
            _brandService.remove(id);
            _logger.LogInformation(User.Identity.Name + ", bir marka sildi");
            TempData.Add("Success", $"Silme işlemi başarılı");
            return RedirectToAction("listofbrand");
        }
        public IActionResult DetailBrand(int id)
        {
            var model = new DetailBrandViewModel()
            {
                status = _statusService.getAllWithDetailsByBrand(id),
                brand = _brandService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailBrandAtPersonel(int id)
        {
            var model = new DetailBrandViewModel()
            {
                status = _statusService.getAllWithDetailsByBrand(id),
                brand = _brandService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailBrandAtCommon(int id)
        {
            var model = new DetailBrandViewModel()
            {
                status = _statusService.getAllWithDetailsByBrand(id),
                brand = _brandService.get(id),
            };
            return View(model);
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
                TempData.Add("Success", $"İşlem başarılı, yeni kategori eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir kategori ekledi - " + category.name);

                return RedirectToAction("listofcategory");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni kategori eklenemedi!");
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
                TempData.Add("Success", $"İşlem başarılı, {category.name} güncelleştirildi ");
                _logger.LogInformation(User.Identity.Name + ", bir kategori güncelleştirdi - " + category.name);
                return RedirectToAction("listofcategory");
            }
            TempData.Add("Alert", $"İşlem Başarısız, {category.name} güncelleştirilemedi!");
            return RedirectToAction("updatecategory", category.id);
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.remove(id);
            _logger.LogInformation(User.Identity.Name + ", bir kategori sildi");
            TempData.Add("Success", $"Silme işlemi başarılı");
            return RedirectToAction("listofcategory");

        }
        public IActionResult DetailCategory(int id)
        {
            var model = new DetailCategoryViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.get(id),
                id = id,
            };
            return View(model);
        }
        public IActionResult DetailCategoryAtPersonel(int id)
        {
            var model = new DetailCategoryViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.get(id),
                id = id,
            };
            return View(model);
        }
        public IActionResult DetailCategoryAtCommon(int id)
        {
            var model = new DetailCategoryViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.get(id),
                id = id,
            };
            return View(model);
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
                TempData.Add("Success", $"İşlem başarılı, yeni model eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir model ekledi - " + model.name);
                return RedirectToAction("listofmodel");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni model eklenemedi!");
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
                TempData.Add("Success", $"İşlem başarılı, {model.name} başarıyla günelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir model güncelleştirdi - " + model.name);
                return RedirectToAction("listofmodel");
            }
            TempData.Add("Alert", $"İşlem başarısız, {model.name} güncelleştirilemedi!");
            return RedirectToAction("updatemodel", model.id);
        }
        public IActionResult DeleteModel(int id)
        {
            _modelService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir model sildi");
            return RedirectToAction("listofmodel");
        }
        public IActionResult DetailModel(int id)
        {
            var model = new DetailModelViewModel()
            {
                status = _statusService.getAllWithDetailsByModel(id),
                model = _modelService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailModelAtPersonel(int id)
        {
            var model = new DetailModelViewModel()
            {
                status = _statusService.getAllWithDetailsByModel(id),
                model = _modelService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailModelAtCommon(int id)
        {
            var model = new DetailModelViewModel()
            {
                status = _statusService.getAllWithDetailsByModel(id),
                model = _modelService.get(id),
            };
            return View(model);
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
                category = _categoryService.getAll().OrderBy(x => x.name).ToList(),
                brand = _brandService.getAll().OrderBy(x => x.name).ToList(),
                model = _modelService.getAll().OrderBy(x => x.name).ToList(),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),
                cpu = _cpuService.getAll().OrderBy(x => x.name).ToList(),
                gpu = _gpuService.getAll().OrderBy(x => x.name).ToList(),
                ram = _ramService.getAll().OrderBy(x => x.name).ToList(),
                hardDrive = _hardDriveService.getAll().OrderBy(x => x.name).ToList(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                if (addProductViewModel.img != null)
                {
                    addProductViewModel.status.Product.imgName = DateTime.Now.Millisecond.ToString() + "_" + addProductViewModel.img.FileName;
                    var fileName = Path.GetFileName(addProductViewModel.status.Product.imgName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        addProductViewModel.img.CopyTo(fileStream);
                    }
                }
                addProductViewModel.status.bstId = _userManager.GetUserId(User);
                _statusService.add(addProductViewModel.status);
                _logger.LogInformation(User.Identity.Name + ", bir ürün ekledi - S/N:" + addProductViewModel.status.Product.serialNo);
                TempData.Add("Success", $"İşlem başarılı, yeni ürün eklendi");
                return RedirectToAction("listofproduct");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni ürün eklenemedi!");
            return View();
        }
        public IActionResult ListOfProduct(int id)
        {
            var model = new ListOfProductViewModel()
            {
                product = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id
            };
            return View(model);
        }
        public IActionResult UpdateProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                status = _statusService.get(id),
                category = _categoryService.getAll().OrderBy(x => x.name).ToList(),
                brand = _brandService.getAll().OrderBy(x => x.name).ToList(),
                model = _modelService.getAll().OrderBy(x => x.name).ToList(),
                cpu = _cpuService.getAll().OrderBy(x => x.name).ToList(),
                gpu = _gpuService.getAll().OrderBy(x => x.name).ToList(),
                ram = _ramService.getAll().OrderBy(x => x.name).ToList(),
                hardDrive = _hardDriveService.getAll().OrderBy(x => x.name).ToList(),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Status status, IFormFile formFile)
        {
            var existPath = _hostingEnvironment.WebRootPath + "\\productImages\\" + status.Product.imgName;
            if (ModelState.IsValid)
            {
                if (formFile != null)
                {
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }

                    status.Product.imgName = DateTime.Now.Millisecond.ToString() + "_" + formFile.FileName;
                    var fileName = Path.GetFileName(status.Product.imgName);


                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }
                }
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"İşlem başarılı, {status.Product.name} güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir ürün güncelleştirdi - S/N:" + status.Product.serialNo);
                return RedirectToAction("detailproduct", new
                {
                    id = status.id
                });
            }
            TempData.Add("Alert", $"İşlem başarısız, {status.Product.name} güncelleştirilemedi!");
            return RedirectToAction("updateproduct", status.Product.id);
        }
        public IActionResult DeleteProduct(int id, int productId)
        {
            var entity = _statusService.get(id);
            var existPath = _hostingEnvironment.WebRootPath + "\\productImages\\" + entity.Product.imgName;

            if (System.IO.File.Exists(existPath))
            {
                System.IO.File.Delete(existPath);
            }
            _statusService.remove(id);
            _productService.remove(productId);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir ürün sildi - S/N:" + entity.Product.serialNo);
            return RedirectToAction("listofproduct");
        }
        public IActionResult DetailProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                status = _statusService.get(id),

            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);
            return View(model);
        }
        public IActionResult AddProductAtPersonel(int id)
        {
            var model = new AddToPersonelViewModel()
            {
                status = _statusService.get(id),
                personel = _personelService.getAll().OrderBy(x => x.name).ToList(),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProductAtPersonel(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                var entity = _productService.get(status.productId);
                TempData.Add("Success", $"İşlem başarılı, personele ürün ataması yapıldı");
                _logger.LogInformation(User.Identity.Name + ", bir ürünün personel atamasını gerçekleştirdi - S/N:" + entity.serialNo);
                return RedirectToAction("detailproduct", new { id = status.id });
            }
            TempData.Add("Alert", $"İşlem başarısız, personele ürün ataması yapılamadı!");
            return View();
        }
        public IActionResult ListofProductAtPersonel(int id)
        {
            var model = new ListOfProductAtPersonelViewModel()
            {
                product = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id

            };
            return View(model);

        }
        public IActionResult DeleteProductAtPersonel(int id)
        {


            var model = _statusService.getStatus(id);
            var entity = _productService.get(model.productId);
            model.personelId = null;
            model.bstId = _userManager.GetUserId(User);
            _statusService.update(model);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir ürünün personel atamasını sildi - S/N:" + entity.serialNo);
            return RedirectToAction("detailproduct", new { id = model.id });

        }
        [HttpGet]
        public IActionResult UpdateProductAtPersonel(int id)
        {
            var model = new UpdateProductAtPersonelViewModel()
            {
                status = _statusService.get(id),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),
                personel = _personelService.getAll().OrderBy(x => x.name).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductAtPersonel(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                var entity = _productService.get(status.productId);
                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir ürünün personel atamasını güncelleştirdi - S/N:" + entity.serialNo);
                return RedirectToAction("detailproduct", new { id = status.id });
            }
            TempData.Add("Alert", $"İşlem başarısız, güncelleştirilemedi!");
            return View();
        }
        //[HttpGet]
        //public IActionResult AddCommon(int id)
        //{
        //    var model = new AddCommonViewModel()
        //    {
        //        common = new Common(),
        //        department = _departmentService.getAll(),
        //        clocation = _clocationService.getAll(),
        //        id = id,
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult AddCommon(Common common, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _commonService.add(common);
        //    }
        //    return RedirectToAction("addproducttocommon", new { id = id, commonId = common.id });
        //}
        [HttpGet]
        public IActionResult AddProductToCommon(int id)
        {
            var model = new AddProductAtCommonViewModel()
            {
                status = _statusService.get(id),
                cLocation = _clocationService.getAll().OrderBy(x => x.name).ToList(),
                department = _departmentService.getAll().OrderBy(x => x.name).ToList(),
                common = new Common(),
                //common = _commonService.get(commonId),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),

            };
            return View(model);
        }
        public IActionResult AddProductToCommon(Status status)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.get(status.productId);
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"İşlem başarılı, ortağa ürün ataması yapıldı");
                _logger.LogInformation(User.Identity.Name + ", bir ürünün ortak atamasını gerçekleştirdi - S/N:" + entity.serialNo);
                return RedirectToAction("detailproduct", new { id = status.id });
            }
            TempData.Add("Alert", $"İşlem başarısız, ortağa ürün ataması yapılamadı!");

            return RedirectToAction("listofproduct");
        }
        public IActionResult ListOfProductAtCommon(int id)
        {
            var model = new ListOfProductAtCommon
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id
            };
            return View(model);
        }
        public IActionResult DeleteProductAtCommon(int id, int commonId)
        {


            var model = _statusService.getStatus(id);
            model.commonId = null;
            model.bstId = _userManager.GetUserId(User);
            var entity = _productService.get(model.productId);
            _statusService.update(model);
            _commonService.remove(commonId);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir ürünün ortak atamasını sildi - S/N:" + entity.serialNo);
            return RedirectToAction("detailproduct", new { id = model.id });
        }
        //[HttpGet]
        //public IActionResult UpdateCommon(int id)
        //{
        //    var model = new AddCommonViewModel()
        //    {
        //        common = new Common(),
        //        department = _departmentService.getAll(),
        //        clocation = _clocationService.getAll(),
        //        id = id,
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult UpdateCommon(Common common, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _commonService.add(common);
        //    }
        //    return RedirectToAction("updateproductatcommon", new { id = id, commonId = common.id });
        //}


        [HttpGet]
        public IActionResult MoveToPersonel(int id)
        {
            var model = new MoveToPersonelViewModel()
            {
                status = _statusService.get(id),
                personel = _personelService.getAll().OrderBy(x => x.name).ToList(),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),

            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);
            return View(model);
        }
        [HttpPost]
        public IActionResult MoveToPersonel(Status status, int id)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.get(status.productId);
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                _commonService.remove(id);
                TempData.Add("Success", $"İşlem başarılı, personele ürün taşıması yapıldı");
                _logger.LogInformation(User.Identity.Name + ", bir ürünün ortak atamasını, personele için ayarladı - S/N:" + entity.serialNo);

                return RedirectToAction("detailproduct", new { id = status.id });


            }
            TempData.Add("Alert", $"İşlem başarısız, personele ürün taşıması yapılamadı!");
            return RedirectToAction("listofproductatpersonel");
        }
        [HttpGet]
        public IActionResult UpdateProductAtCommon(int id, int commonId)
        {
            var model = new AddProductAtCommonViewModel()
            {
                status = _statusService.get(id),
                common = new Common(),
                cLocation = _clocationService.getAll().OrderBy(x => x.name).ToList(),
                department = _departmentService.getAll().OrderBy(x => x.name).ToList(),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),
                commonId = commonId,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProductAtCommon(Status status, int commonId)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                _commonService.remove(commonId);
                var entity = _productService.get(status.productId);

                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir ürünün ortak atamasını güncelleştirdi - S/N:" + entity.serialNo);

                return RedirectToAction("detailproduct", new
                {
                    id = status.id
                });
            }
            TempData.Add("Alert", $"İşlem başarısız, güncelleştirilemedi!");

            return RedirectToAction("listofproduct");
        }
        [HttpGet]
        public IActionResult MoveToCommon(int id)
        {
            var model = new MoveToCommonViewModel()
            {
                status = _statusService.get(id),
                common = new Common(),
                clocation = _clocationService.getAll().OrderBy(x => x.name).ToList(),
                department = _departmentService.getAll().OrderBy(x => x.name).ToList(),
                campus = _campusService.getAll().OrderBy(x => x.name).ToList(),
            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);

            return View(model);
        }
        [HttpPost]
        public IActionResult MoveToCommon(Status status)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.get(status.productId);
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"İşlem başarılı, ortağa ürün taşıması yapıldı");
                _logger.LogInformation(User.Identity.Name + ", bir ürünün personel atamasını, ortak için ayarladı - S/N:" + entity.serialNo);

                return RedirectToAction("detailproduct", new { id = status.id });

            }
            TempData.Add("Alert", $"İşlem başarısız, ortağa ürün taşıması yapılamadı!");
            return RedirectToAction("listofproductatcommon");
        }
        public IActionResult ListOfProductAtService(int id)
        {
            var model = new ListOfProductAtServiceViewModel()
            {
                status = _statusService.getAllWithDetailsByCategory(id),
                category = _categoryService.getAll(),
                categoryId = id
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Department   ##############################

        public IActionResult AddDepartment()
        {
            var model = new AddDepartmentViewModel()
            {
                department = new Entity.Concrete.Department()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddDepartment(Entity.Concrete.Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.add(department);
                TempData.Add("Success", $"İşlem başarılı, yeni departman eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir departman ekledi - " + department.name);

                return RedirectToAction("listofdepartment");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni departman eklenemedi!");
            return View();
        }
        [HttpGet]
        public IActionResult ListOfDepartment()
        {
            var model = new ListOfDepartmentViewModel()
            {
                department = _departmentService.getAll().OrderBy(x => x.name).ToList(),
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
        public IActionResult UpdateDepartment(Entity.Concrete.Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.update(department);
                TempData.Add("Success", $"İşlem başarılı, {department.name} güncelleştirildi.");
                _logger.LogInformation(User.Identity.Name + ", bir departman güncelleştirdi - " + department.name);
                return RedirectToAction("listofdepartment");
            }
            TempData.Add("Alert", $"İşlem başarısız, {department.name} güncelleştirilemedi!");
            return RedirectToAction("updatedepartment", department.id);
        }
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir departman sidli");
            return RedirectToAction("listofdepartment");
        }
        public IActionResult DetailDepartmentAtPersonel(int id)
        {
            var model = new DetailDepartmentModel()
            {
                status = _statusService.getAllWithDetailsByDepartmentAtPersonel(id),
                department = _departmentService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailDepartmentAtCommon(int id)
        {
            var model = new DetailDepartmentModel()
            {
                status = _statusService.getAllWithDetailsByDepartmentAtCommon(id),
                department = _departmentService.get(id),
            };
            return View(model);
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
                TempData.Add("Success", $"İşlem başarılı, yeni lokasyon eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir lokasyon ekledi - " + cLocation.name);

                return RedirectToAction("listofCLocation");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni lokasyon eklenemedi!");
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
                TempData.Add("Success", $"İşlem başarılı, {cLocation.name} güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir lokasyon güncelleştirdi - " + cLocation.name);
                return RedirectToAction("listofclocation");
            }
            TempData.Add("Alert", $"İşlem başarısız, {cLocation.name} güncelleştirilemedi!");
            return RedirectToAction("updateclocation", cLocation.id);
        }
        public IActionResult DeleteCLocation(int id)
        {
            _clocationService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir lokasyon sildi");
            return RedirectToAction("listofclocation");
        }
        public IActionResult DetailCLocationAtCommon(int id)
        {
            var model = new DetailCLocationAtCommon()
            {
                status = _statusService.getAllWithDetailsByCLocationAtCommon(id),
                cLocation = _clocationService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailClocationAtPersonel(int id)
        {
            var model = new DetailCLocationAtPersonel()
            {
                status = _statusService.getAllWithDetailsByCLocationAtPersonel(id),
                cLocation = _clocationService.get(id),
            };
            return View(model);
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
                TempData.Add("Success", $"İşlem başarılı, yeni yerleşke eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir yerleşke ekledi - " + campus.name);

                return RedirectToAction("listofcampus");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni yerleşke eklenemedi!");
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
                TempData.Add("Success", $"İşlem başarılı, {campus.name} güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir yerleşke güncelleştirdi - " + campus.name);
                return RedirectToAction("listofcampus");
            }
            TempData.Add("Alert", $"İşlem başarısız, {campus.name} güncelleştirilemedi!");
            return RedirectToAction("updateclocation", campus.id);
        }
        public IActionResult DeleteCampus(int id)
        {
            _campusService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir yerleşke sildi");

            return RedirectToAction("listofcampus");
        }
        public IActionResult DetailCampus(int id)
        {
            var model = new DetailCampusModel()
            {
                status = _statusService.getAllWithDetailsByCampus(id),
                campus = _campusService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailCampusAtPersonel(int id)
        {
            var model = new DetailCampusModel()
            {
                status = _statusService.getAllWithDetailsByCampus(id),
                campus = _campusService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailCampusAtCommon(int id)
        {
            var model = new DetailCampusModel()
            {
                status = _statusService.getAllWithDetailsByCampus(id),
                campus = _campusService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Personel   ################################

        public IActionResult AddPersonel()
        {
            var model = new AddPersonelViewModel()
            {
                personel = new Personel(),
                sex = _sexService.getAll().OrderBy(x => x.name).ToList(),
                deparment = _departmentService.getAll().OrderBy(x => x.name).ToList(),
                cLocation = _clocationService.getAll().OrderBy(x => x.name).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelService.add(personel);
                TempData.Add("Success", $"İşlem başarılı, yeni personel eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir personel ekledi- " + personel.name + " " + personel.surname);

                return RedirectToAction("listofpersonel");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni personel eklenemedi!");
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
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir personel sildi");
            return RedirectToAction("listofpersonel");
        }
        [HttpGet]
        public IActionResult UpdatePersonel(int id)
        {
            var model = new UpdatePersonelViewModel()
            {
                personel = _personelService.get(id),
                sex = _sexService.getAll().OrderBy(x => x.name).ToList(),
                department = _departmentService.getAll().OrderBy(x => x.name).ToList(),
                cLocation = _clocationService.getAll().OrderBy(x => x.name).ToList()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdatePersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                _personelService.update(personel);
                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir personel güncelleştirdi - " + personel.name + " " + personel.surname);
                return RedirectToAction("detailpersonel", new { id = personel.id });
            }
            TempData.Add("Alert", $"İşlem başarısız, güncelleştirilemedi!");
            return View();
        }
        [HttpGet]
        public IActionResult DetailPersonel(int id)
        {
            var model = new DetailPersonelViewModel()
            {
                personel = _personelService.get(id),
                status = _statusService.getAllWithDetailsByPersonel(id)

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

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Cpu   #####################################
        public IActionResult ListOfCpu()
        {
            var model = new ListOfCpuModel()
            {
                cpu = _cpuService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddCpu()
        {
            var model = new AddCpuViewModel()
            {
                cpu = new Cpu(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCpu(Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                _cpuService.add(cpu);
                TempData.Add("Success", $"İşlem başarılı, yeni işlemci eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir işlemci ekledi - " + cpu.name);
                return RedirectToAction("listofcpu");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni işlemci eklenemedi!");

            return View();
        }
        [HttpGet]
        public IActionResult UpdateCpu(int id)
        {
            var model = new UpdateCpuViewModel()
            {
                cpu = _cpuService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCpu(Cpu cpu)
        {
            if (ModelState.IsValid)
            {
                _cpuService.update(cpu);
                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir işlemci güncelleştirdi - " + cpu.name);
                return RedirectToAction("listofcpu");

            }
            TempData.Add("Alert", $"İşlem başarısız, güncelleştirilemedi!");
            return RedirectToAction("listofcpu");

        }
        public IActionResult DeleteCpu(int id)
        {
            _cpuService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir işlemci sildi");

            return RedirectToAction("listofcpu");
        }
        public IActionResult DetailCpu(int id)
        {
            var model = new DetailCpuViewModel()
            {
                status = _statusService.getAllWithDetailsByCpu(id),
                cpu = _cpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailCpuAtPersonel(int id)
        {
            var model = new DetailCpuViewModel()
            {
                status = _statusService.getAllWithDetailsByCpu(id),
                cpu = _cpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailCpuAtCommon(int id)
        {
            var model = new DetailCpuViewModel()
            {
                status = _statusService.getAllWithDetailsByCpu(id),
                cpu = _cpuService.get(id)
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Gpu   #####################################

        public IActionResult ListOfGpu()
        {
            var model = new ListOfGpuViewModel()
            {
                gpu = _gpuService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddGpu()
        {
            var model = new AddGpuViewModel()
            {
                gpu = new Gpu(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddGpu(Gpu gpu)
        {
            if (ModelState.IsValid)
            {
                TempData.Add("Success", $"İşlem başarılı, yeni ekran kartı eklendi");
                _gpuService.add(gpu);
                _logger.LogInformation(User.Identity.Name + ", bir ekran kartı ekledi - " + gpu.name);
                return RedirectToAction("listofgpu");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni ekran kartı eklenemedi!");

            return View();
        }
        [HttpGet]
        public IActionResult UpdateGpu(int id)
        {
            var model = new UpdateGpuViewModel()
            {
                gpu = _gpuService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateGpu(Gpu gpu)
        {
            if (ModelState.IsValid)
            {
                _gpuService.update(gpu);
                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir ekran kartı güncelleştirdi - " + gpu.name);
                return RedirectToAction("listofgpu");
            }
            TempData.Add("Alert", $"İşlem başarısız, güncelleştirilemedi!");

            return View();
        }
        public IActionResult DeleteGpu(int id)
        {
            _gpuService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir ekran kartı sildi");
            return RedirectToAction("listofgpu");
        }
        public IActionResult DetailGpu(int id)
        {
            var model = new DetailGpuViewModel()
            {
                status = _statusService.getAllWithDetailsByGpu(id),
                gpu = _gpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailGpuAtPersonel(int id)
        {
            var model = new DetailGpuViewModel()
            {
                status = _statusService.getAllWithDetailsByGpu(id),
                gpu = _gpuService.get(id)
            };
            return View(model);
        }
        public IActionResult DetailGpuAtCommon(int id)
        {
            var model = new DetailGpuViewModel()
            {
                status = _statusService.getAllWithDetailsByGpu(id),
                gpu = _gpuService.get(id)
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Ram   #####################################

        public IActionResult ListOfRam()
        {
            var model = new ListOfRamViewModel()
            {
                ram = _ramService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddRam()
        {
            var model = new AddRamViewModel()
            {
                ram = new Ram(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddRam(Ram ram)
        {
            if (ModelState.IsValid)
            {

                _ramService.add(ram);
                TempData.Add("Success", $"İşlem başarılı, yeni ram eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir ram ekledi - " + ram.name);
                return RedirectToAction("listofram");
            }
            TempData.Add("Alert", $"İşlem başarısız, yeni ram eklenemedi!");

            return View();
        }
        public IActionResult UpdateRam(int id)
        {
            var model = new UpdateRamViewModel()
            {
                ram = _ramService.get(id)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateRam(Ram ram)
        {
            if (ModelState.IsValid)
            {
                _ramService.update(ram);
                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir ram güncelleştirdi - " + ram.name);

                return RedirectToAction("ListOfRam");
            }
            TempData.Add("Alert", $"İşlem başarısız, güncelleştirilemedi!");

            return View();
        }
        public IActionResult DeleteRam(int id)
        {
            _ramService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir ram sildi");
            return RedirectToAction("listofram");
        }
        public IActionResult DetailRam(int id)
        {
            var model = new DetailRamViewModel()
            {
                status = _statusService.getAllWithDetailsByRam(id),
                ram = _ramService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailRamAtPersonel(int id)
        {
            var model = new DetailRamViewModel()
            {
                status = _statusService.getAllWithDetailsByRam(id),
                ram = _ramService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailRamAtCommon(int id)
        {
            var model = new DetailRamViewModel()
            {
                status = _statusService.getAllWithDetailsByRam(id),
                ram = _ramService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Hard Drive   ##############################

        public IActionResult ListOfHardDrive()
        {
            var model = new ListOfHardDriveViewModel()
            {
                hardDrive = _hardDriveService.getAll(),
            };
            return View(model);
        }
        public IActionResult AddHardDrive()
        {
            var model = new AddHardDriveViewModel()
            {
                hardDrive = new HardDrive(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddHardDrive(HardDrive hardDrive)
        {
            if (ModelState.IsValid)
            {
                _hardDriveService.add(hardDrive);
                TempData.Add("Success", $"İşlem başarılı, yeni sabit disk eklendi");
                _logger.LogInformation(User.Identity.Name + ", bir sabit disk ekledi - " + hardDrive.name);
                return RedirectToAction("listofharddrive");
            }
            TempData.Add("Alert", $"İşlem başarısız, sabit disk eklenemedi!");

            return View();
        }
        public IActionResult UpdateHardDrive(int id)
        {
            var model = new UpdateHardDriveViewModel()
            {
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateHardDrive(HardDrive hardDrive)
        {
            if (ModelState.IsValid)
            {
                _hardDriveService.update(hardDrive);
                TempData.Add("Success", $"İşlem başarılı, güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir sabit disk güncelleştirdi - " + hardDrive.name);
                return RedirectToAction("listofharddrive");
            }
            TempData.Add("Success", $"İşlem başarısız, güncelleştirilemedi!");

            return View();
        }
        public IActionResult DeleteHardDrive(int id)
        {
            _hardDriveService.remove(id);
            TempData.Add("Success", $"Silme işlemi başarılı");
            _logger.LogInformation(User.Identity.Name + ", bir sabit disk sildi");

            return RedirectToAction("listofharddrive");
        }
        public IActionResult DetailHardDrive(int id)
        {
            var model = new DetailHardDriveViewModel()
            {
                status = _statusService.getAllWithDetailsByHardDrive(id),
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailHardDriveAtPersonel(int id)
        {
            var model = new DetailHardDriveViewModel()
            {
                status = _statusService.getAllWithDetailsByHardDrive(id),
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }
        public IActionResult DetailHardDriveAtCommon(int id)
        {
            var model = new DetailHardDriveViewModel()
            {
                status = _statusService.getAllWithDetailsByHardDrive(id),
                hardDrive = _hardDriveService.get(id),
            };
            return View(model);
        }

        // #################################################################

        //------------------------------------------------------------------

        // ###################   Service   #################################

        public IActionResult AddService(int id)
        {
            var model = new AddServiceViewModel()
            {
                status = _statusService.get(id),
                service = new Service(),

            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);

            return View(model);
        }
        [HttpPost]
        public IActionResult AddService(Status status)
        {

            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                TempData.Add("Success", $"İşlem başarılı, servis kaydı oluşturuldu");
                var entity = _productService.get(status.productId);

                _logger.LogInformation(User.Identity.Name + ", bir servis kaydı oluşturdu S/N:" + entity.serialNo);

                return RedirectToAction("detailservice", new { id = status.id });

            }
            TempData.Add("Alert", $"İşlem başarısız, servis kaydı oluşturulamadı!");

            return View();
        }
        public IActionResult DeleteService(int id)
        {
            _serviceService.remove(id);
            TempData.Add("Success", $"İşlem başarılı, servis kaydı kapatıldı");
            _logger.LogInformation(User.Identity.Name + ", bir servis kaydı kapattı");
            return RedirectToAction("listofproductatservice");
        }
        public IActionResult UpdateService(int id)
        {
            var model = new UpdateServiceViewModel()
            {
                status = _statusService.get(id),
            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateService(Status status)
        {
            if (ModelState.IsValid)
            {
                status.bstId = _userManager.GetUserId(User);
                _statusService.update(status);
                var entity = _productService.get(status.productId);
                TempData.Add("Success", $"İşlem başarılı, servis kaydı güncelleştirildi");
                _logger.LogInformation(User.Identity.Name + ", bir servis kaydı güncelleştirdi S/N:" + entity.serialNo);

                return RedirectToAction("detailproduct", new
                {
                    id = status.id
                });
            }
            TempData.Add("Alert", $"İşlem başarısız, servis kaydı güncelleştirilemedi!");

            return View();
        }
        public IActionResult DetailService(int id)
        {
            var model = new DetailServiceViewModel()
            {
                status = _statusService.get(id),
            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);

            return View(model);
        }
        // #################################################################

        //------------------------------------------------------------------

        // ###################   LOGS   ####################################

        //public IActionResult LogDetail()
        //{
        //    var model = new LogDetailViewModel();


        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult LogDetail(LogDetailViewModel logDetailViewModel)
        //{
        //    StringBuilder sb = new StringBuilder(logDetailViewModel.log);

        //    string date = logDetailViewModel.log;
        //    date = date.Remove(4, 1);
        //    date = date.Remove(6, 1);
        //    string fileName = "Data" + date + ".log";
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "logs", fileName);
        //    string logs = System.IO.File.ReadAllText(filePath);
        //    return RedirectToAction("logView", new { log = logs });
        //}
        //public IActionResult LogView(string log)
        //{
        //    var model = new LogDetailViewModel()
        //    {
        //        log = log
        //    };
        //    return View(model);
        //}
    }
}
