using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;

namespace SchoolWebApplication.Controllers
{
    public class SocietiesController : Controller
    {
        private readonly SocietyLogic _societyLogic;

        private readonly LessonLogic _lessonLogic;

        private readonly ClientLogic _clientLogic;

        public SocietiesController(SocietyLogic societyLogic, LessonLogic lessonLogic, ClientLogic clientLogic)
        {
            _societyLogic = societyLogic;
            _lessonLogic = lessonLogic;
            _clientLogic = clientLogic;
        }



        // GET: Societies
        public async Task<IActionResult> Index()
        {
            var societies = _societyLogic.Read(null);
            return View(societies);
        }

        // GET: Societies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var society = _societyLogic.Read(new SocietyBindingModel
            {
                Id = id
            }).FirstOrDefault();
            if (society == null)
            {
                return NotFound();
            }

            return View(society);
        }

        //GET: Societies/Create
        public IActionResult Create()
        {
            ViewData["LessonId"] = new MultiSelectList(_lessonLogic.Read(null), "Id", "LessonName");
            return View();
        }

        // POST: Societies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocietyName,AgeLimit,Sum,Lessons")] SocietyBindingModel society)
        {
            if (ModelState.IsValid)
            {
                society.ClientId = Program.Client.Id;
                _societyLogic.CreateOrUpdate(society);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new MultiSelectList(_lessonLogic.Read(null), "Id", "LessonName");
            return View(society);
        }

        // GET: Societies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var society =  _societyLogic.Read(new SocietyBindingModel { Id = id}).FirstOrDefault();
            if (society == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new MultiSelectList(_lessonLogic.Read(null), "Id", "LessonName");
            return View(new SocietyBindingModel { 
            Id = society.Id,
            SocietyName = society.SocietyName,
            AgeLimit = society.AgeLimit,
            Sum = society.Sum,
            Lessons = society.Lessons.Select(rec => rec.Id).ToList()});
        }

        // POST: Societies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SocietyName,AgeLimit,Sum,Lessons")] SocietyBindingModel society)
        {
            if (id != society.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    society.ClientId = Program.Client.Id;
                    _societyLogic.CreateOrUpdate(society);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocietyExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new MultiSelectList(_lessonLogic.Read(null), "Id", "LessonName");
            return View(society);
        }

        // GET: Societies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var society = _societyLogic.Read(new SocietyBindingModel { Id = id }).FirstOrDefault();
            if (society == null)
            {
                return NotFound();
            }

            return View(society);
        }

        // POST: Societies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _societyLogic.Delete(new SocietyBindingModel { Id = id });
            return RedirectToAction(nameof(Index));
        }

        private bool SocietyExists(int id)
        {
            return _societyLogic.Read(null).Any(e => e.Id == id);
        }
    }
}
