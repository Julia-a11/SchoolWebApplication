using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using SchoolBusinessLogic.ViewModel;

namespace SchoolWebApplication.Controllers
{
    public class DiagramController : Controller
    {
        private readonly SocietyLogic _societyLogic;

        private readonly DiagramLogic _diagramLogic;

        public DiagramController(SocietyLogic societyLogic, DiagramLogic diagramLogic)
        {
            _societyLogic = societyLogic;
            _diagramLogic = diagramLogic;
        }

        public IActionResult Index()
        {
            ViewBag.Societies = new SelectList(_societyLogic.Read(new SocietyBindingModel
            {
                ClientId = Program.Client.Id
            }), "Id", "SocietyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int societyId)
        {
            ViewBag.Societies = new SelectList(_societyLogic.Read(new SocietyBindingModel
            {
                ClientId = Program.Client.Id
            }), "Id", "SocietyName");
            var model = new DiagramViewModel[]{
                _diagramLogic.GetDiagramByLessonsCount(societyId),
                _diagramLogic.GetDiagramByLessonsPrice(societyId)
            };
            return View(model);
        }
    }
}
