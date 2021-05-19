using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;

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
        public IActionResult MakeListDoc([Bind("SelectedSocieties")]ReportBindingModel model)
        {
            model.FileName = @".\wwwroot\list\SocietiesList.doc";
            model.ClientId = Program.Client.Id;
            _reportLogic.SaveSocietiesToWordFile(model);

            var fileName = "SocietiesList.doc";
            var filePath = _environment.WebRootPath + @"\list\" + fileName;
            return PhysicalFile(filePath, "application/doc", fileName);
        }

        [HttpPost]
        public IActionResult MakeListXls([Bind("SelectedSocieties")] ReportBindingModel model)
        {
            model.FileName = @".\wwwroot\list\SocietiesList.xls";
            model.ClientId = Program.Client.Id;
            _reportLogic.SaveSocietiesToExcelFile(model);

            var fileName = "SocietiesList.xls";
            var filePath = _environment.WebRootPath + @"\list\" + fileName;
            return PhysicalFile(filePath, "application/xls", fileName);
        }
    }
}
