using BstEnvanter.Business.Abstract;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Extensions.Abstract;
using BstEnvanter.WebUI.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class ProcessController : Controller
    {
        private IStatusService _statusService;
        private IExtensions _extensions;
        public ProcessController(IStatusService statusService, IExtensions extensions)
        {
            _statusService = statusService;
            _extensions = extensions;
        }

        public IActionResult ExportExcel(string name, int id, string exportName)
        {
            var exportList = _extensions.GetAll(name, id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ÜrünListesi_" + DateTime.Today.ToShortDateString());
                worksheet.Cell(1, 1).Value = "id";
                worksheet.Cell(1, 2).Value = "Ürün Id";
                worksheet.Cell(1, 3).Value = "Kategori";
                worksheet.Cell(1, 4).Value = "Marka";
                worksheet.Cell(1, 5).Value = "Model";
                worksheet.Cell(1, 6).Value = "İsim";
                worksheet.Cell(1, 7).Value = "Seri No";
                worksheet.Cell(1, 8).Value = "Envanter No";
                worksheet.Cell(1, 9).Value = "Cpu";
                worksheet.Cell(1, 10).Value = "Gpu";
                worksheet.Cell(1, 11).Value = "Ram";
                worksheet.Cell(1, 12).Value = "Hdd";
                worksheet.Cell(1, 13).Value = "Personel";
                worksheet.Cell(1, 14).Value = "Ortak - Departman";
                worksheet.Cell(1, 15).Value = "Ortak - Lokasyon";
                worksheet.Cell(1, 16).Value = "Yerleşke";
                int row = 2;
                foreach (var item in exportList)
                {
                    worksheet.Cell(row, 1).Value = item.id;
                    worksheet.Cell(row, 2).Value = item.productId;
                    if (item.Product.categoryId != null)
                    {
                        worksheet.Cell(row, 3).Value = item.Product.Category.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 3).Value = "-";
                    }
                    if (item.Product.brandId != null)
                    {
                        worksheet.Cell(row, 4).Value = item.Product.Brand.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 4).Value = "-";
                    }
                    if (item.Product.modelId != null)
                    {
                        worksheet.Cell(row, 5).Value = item.Product.Model.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 5).Value = "-";
                    }

                    worksheet.Cell(row, 6).Value = item.Product.name;
                    worksheet.Cell(row, 7).Value = item.Product.serialNo;
                    worksheet.Cell(row, 8).Value = item.Product.inventoryNo;
                    if (item.Product.cpuId != null)
                    {
                        worksheet.Cell(row, 9).Value = item.Product.Cpu.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 9).Value = "-";

                    }
                    if (item.Product.gpuId !=null)
                    {
                        worksheet.Cell(row, 10).Value = item.Product.Gpu.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 10).Value = "-";

                    }
                    if (item.Product.ramId != null)
                    {
                        worksheet.Cell(row, 11).Value = item.Product.Ram.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 11).Value = "-";
                    }
                    if (item.Product.hardDriveId != null)
                    {
                        worksheet.Cell(row, 12).Value = item.Product.HardDrive.name;

                    }
                    else
                    {
                        worksheet.Cell(row, 12).Value = "-";
                    }
                    if (item.personelId != null)
                    {
                        worksheet.Cell(row, 13).Value = $"{item.Personel.name} {item.Personel.surname}";
                    }
                    else
                    {
                        worksheet.Cell(row, 13).Value = "-";

                    }
                    if (item.commonId != null)
                    {
                        worksheet.Cell(row, 14).Value = item.Common.department.name;
                    }
                    else
                    {
                        worksheet.Cell(row, 14).Value = "-";

                    }
                    if (item.commonId != null)
                    {
                        worksheet.Cell(row, 15).Value = item.Common.CLocation.name;
                    }
                    else
                    {
                        worksheet.Cell(row, 15).Value = "-";
                    }
                    worksheet.Cell(row, 16).Value = item.Campus.name;
                    row++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{exportName}.xlsx");


                }
            }
        }
    }
}
