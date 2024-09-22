using BstEnvanter.Business.Abstract;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Extensions.Abstract;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Extensions.Concrete
{
    public class ExportExcel : IExtensions
    {
        private IStatusService _statusService;
        public ExportExcel(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public List<Status> GetAll(string name, int id)
        {
            var exportList = _statusService.getAllWithDetails(); ;

            //PRODUCTS
            if (name == "listofproducts")
            {
                exportList = _statusService.getAllWithDetails().Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();
            }
            else if (name == "listofproductsatpersonel")
            {
                exportList = _statusService.getAllWithDetails().Where(x => x.personelId != null).ToList();
            }
            else if (name == "listofproductsatcommon")
            {
                exportList = _statusService.getAllWithDetails().Where(x => x.commonId != null).ToList();
            }
            else if (name == "listofproductsatservice")
            {
                exportList = _statusService.getAllWithDetails().Where(x => x.serviceId != null).ToList();
            }

            //CPU
            else if (name == "listofcpu")
            {
                exportList = _statusService.getAllWithDetailsByCpu(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();
            }
            else if (name == "listofcpuatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByCpu(id).Where(x => x.personelId != null).ToList();
            }
            else if (name == "listofcpuatcommon")
            {
                exportList = _statusService.getAllWithDetailsByCpu(id).Where(x => x.commonId != null).ToList();
            }

            //GPU
            else if (name == "listofgpu")
            {
                exportList = _statusService.getAllWithDetailsByGpu(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();
            }
            else if (name == "listofgpuatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByGpu(id).Where(x => x.personelId != null).ToList();
            }
            else if (name == "listofgpuatcommon")
            {
                exportList = _statusService.getAllWithDetailsByGpu(id).Where(x => x.commonId != null).ToList();
            }

            //RAM
            else if (name == "listofram")
            {
                exportList = _statusService.getAllWithDetailsByRam(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();
            }
            else if (name == "listoframatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByRam(id).Where(x => x.personelId != null).ToList();
            }
            else if (name == "listoframatcommon")
            {
                exportList = _statusService.getAllWithDetailsByRam(id).Where(x => x.commonId != null).ToList();
            }

            //HDD
            else if (name == "listofharddrive")
            {
                exportList = _statusService.getAllWithDetailsByHardDrive(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();

            }
            else if (name == "listofharddriveatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByHardDrive(id).Where(x => x.personelId != null).ToList();

            }
            else if (name == "listofharddriveatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByHardDrive(id).Where(x => x.commonId != null).ToList();

            }

            //CATEGORY
            else if (name == "listofcategory")
            {
                exportList = _statusService.getAllWithDetailsByCategory(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();
            }
            else if (name == "listofcategoryatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByCategory(id).Where(x => x.personelId != null).ToList();
            }
            else if (name == "listofcategoryatcommon")
            {
                exportList = _statusService.getAllWithDetailsByCategory(id).Where(x => x.commonId != null).ToList();
            }

            //BRAND
            else if (name == "listofbrand")
            {
                exportList = _statusService.getAllWithDetailsByBrand(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();

            }
            else if (name == "listofbrandatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByBrand(id).Where(x => x.personelId != null).ToList();
            }
            else if (name == "listofbrandatcommon")
            {
                exportList = _statusService.getAllWithDetailsByBrand(id).Where(x => x.commonId != null).ToList();

            }

            //MODEL
            else if (name == "listofmodel")
            {
                exportList = _statusService.getAllWithDetailsByModel(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();
            }
            else if (name == "listofmodelatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByModel(id).Where(x => x.personelId != null).ToList();
            }
            else if (name == "listofmodelatcommon")
            {
                exportList = _statusService.getAllWithDetailsByModel(id).Where(x => x.Common != null).ToList();
            }

            //CAMPUS
            else if (name == "listofcampus")
            {
                exportList = _statusService.getAllWithDetailsByCampus(id).Where(x => x.personelId == null).Where(x => x.commonId == null).ToList();

            }
            else if (name == "listofcampusatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByCampus(id).Where(x => x.personelId != null).ToList();

            }
            else if (name == "listofcampusatcommon")
            {
                exportList = _statusService.getAllWithDetailsByCampus(id).Where(x => x.commonId != null).ToList();

            }

            //DEPARTMENT

            else if (name == "listofdepartmentatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByDepartmentAtPersonel(id).Where(x => x.personelId != null).ToList();

            }
            else if (name == "listofdepartmentatcommon")
            {
                exportList = _statusService.getAllWithDetailsByDepartmentAtCommon(id).Where(x => x.commonId != null).ToList();

            }
            //LOCATION
            else if (name == "listofclocationatpersonel")
            {
                exportList = _statusService.getAllWithDetailsByCLocationAtPersonel(id).Where(x => x.personelId != null).ToList();

            }
            else if (name == "listofclocationatcommon")
            {
                exportList = _statusService.getAllWithDetailsByCLocationAtCommon(id).Where(x => x.commonId != null).ToList();

            }
            //PERSONEL
            else if (name == "listofpersonel")
            {
                exportList = _statusService.getAllWithDetailsByPersonel(id).ToList();
            }

            return exportList;
        }
    }
}
