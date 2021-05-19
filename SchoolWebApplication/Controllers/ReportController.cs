using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using SchoolBusinessLogic.HelperModel;
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
            model.ClientId = Program.Client.Id;
            _reportLogic.SaveSocietiesToPdfFile(model);
            ViewBag.CheckingReport = model.FileName;
            return View("Index");
        }

        [HttpPost]
        public IActionResult SendMail([Bind("DateTo,DateFrom")] ReportBindingModel model)
        {
            model.FileName = @".\wwwroot\list\SocietiesList.pdf";
            model.ClientId = Program.Client.Id;
            _reportLogic.SaveSocietiesToPdfFile(model);
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = Program.Client.Login,
                Subject = "Отчет",
                Text = "Отчет по кружкам",
                ReportFile = model.FileName
            });
            return RedirectToAction("Index");
        }
    }
}
