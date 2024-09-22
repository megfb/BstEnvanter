using BstEnvanter.Business.Abstract;
using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    [Authorize]
    public class ReaderController : Controller
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

        public ReaderController(IBrandService brandService, ICategoryService categoryService, IModelService modelService, IProductService productService,
           IDepartmentService departmentService, ICLocationService cLocationService, ICampusService campusService, ISexService sexService, IPersonelService personelService,
           IStatusService statusService, ICommonService commonService, ICpuService cpuService, IGpuService gpuService, IRamService ramService, IHardDriveService hardDriveService,
           IServiceService serviceService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
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
        }


        // #################################################################

        //------------------------------------------------------------------

        // ###################   BRAND PROCESSES   #########################
        public IActionResult ListOfBrand()
        {
            var model = new ListBrandViewModel()
            {
                brand = _brandService.getAll()
            };

            return View(model);
        }
        // #################################################################

        //------------------------------------------------------------------

        // ###################   Product   #################################

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
        public IActionResult DetailProduct(int id)
        {
            var model = new UpdateProductViewModel()
            {
                status = _statusService.get(id),

            };
            model.user = _userManager.Users.FirstOrDefault(x => x.Id == model.status.bstId);
            return View(model);
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
        public IActionResult ListOfDepartment()
        {
            var model = new ListOfDepartmentViewModel()
            {
                department = _departmentService.getAll()
            };
            return View(model);
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
        [HttpGet]
        public IActionResult ListOfCLocation()
        {
            var model = new ListOfCLocationViewModel()
            {
                cLocation = _clocationService.getAll()
            };
            return View(model);
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

        public IActionResult ListOfCampus()
        {
            var model = new ListOfCampusViewModel()
            {
                campus = _campusService.getAll(),
            };
            return View(model);
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
        public IActionResult ListOfPersonel()
        {
            var model = new ListOfPersonelViewModel()
            {
                personel = _personelService.getAll(),
            };
            return View(model);
        }
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

        // ###################   Cpu   #####################################
        public IActionResult ListOfCpu()
        {
            var model = new ListOfCpuModel()
            {
                cpu = _cpuService.getAll(),
            };
            return View(model);
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

        // ###################   CATEGORY PROCESSES   ######################
        public IActionResult ListOfCategory()
        {
            var model = new ListOfCategoryViewModel()
            {
                category = _categoryService.getAll()
            };

            return View(model);
        }
        // #################################################################

        //------------------------------------------------------------------

        // ###################   Model   ###################################
        public IActionResult ListOfModel()
        {
            var model = new ListOfModelViewModel()
            {
                model = _modelService.getAll()
            };
            return View(model);
        }

    }
}
