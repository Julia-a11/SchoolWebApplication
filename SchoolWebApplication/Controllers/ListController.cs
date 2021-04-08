using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApplication.Controllers
{
    public class ListController : Controller
    {
        private readonly SocietyLogic _societyLogic;

        private readonly ReportLogic _reportLogic;

        private readonly IWebHostEnvironment _environment;

        public ListController(SocietyLogic societyLogic, ReportLogic reportLogic, IWebHostEnvironment environment)
        {
            _societyLogic = societyLogic;
            _reportLogic = reportLogic;
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewData["SocietyId"] = new MultiSelectList(_societyLogic.Read(null), "Id", "SocietyName");
            return View();
        }

        [HttpPost]
        public IActionResult MakeListDoc([Bind("SocietyId")]ReportBindingModel model)
        {
            model.FileName = @".\wwwroot\list\SocietiesList.doc";
            _reportLogic.SaveSocietiesToWordFile(model);

            var fileName = "SocietiesList.doc";
            var filePath = _environment.WebRootPath + @"\list\" + fileName;
            return PhysicalFile(filePath, "application/doc", fileName);
        }

        [HttpPost]
        public IActionResult MakeListXls([Bind("SocietyId")] ReportBindingModel model)
        {
            model.FileName = @".\wwwroot\list\SocietiesList.xls";
            _reportLogic.SaveSocietiesToExcelFile(model);

            var fileName = "SocietiesList.xls";
            var filePath = _environment.WebRootPath + @"\list\" + fileName;
            return PhysicalFile(filePath, "application/xls", fileName);
        }
    }
}
