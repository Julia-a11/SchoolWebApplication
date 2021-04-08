using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApplication.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportLogic _reportLogic;

        private readonly IWebHostEnvironment _environment;

        public ReportController(ReportLogic reportLogic, IWebHostEnvironment environment)
        {
            _reportLogic = reportLogic;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeReport([Bind("DateTo,DateFrom")]ReportBindingModel model)
        {
            model.FileName = @".\wwwroot\list\SocietiesList.pdf";
            _reportLogic.SaveSocietiesToPdfFile(model);

            var fileName = "SocietiesList.pdf";
            var filePath = _environment.WebRootPath + @"\list\" + fileName;
            return PhysicalFile(filePath, "application/pdf", fileName);
        }
    }
}
