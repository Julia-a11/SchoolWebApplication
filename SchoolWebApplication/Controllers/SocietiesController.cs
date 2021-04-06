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

        public SocietiesController(SocietyLogic societyLogic, LessonLogic lessonLogic)
        {
            _societyLogic = societyLogic;
            _lessonLogic = lessonLogic;
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
                society.ClientId = 1;
                _societyLogic.CreateOrUpdate(society);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new MultiSelectList(_lessonLogic.Read(null), "Id", "LessonName");
            return View(society);
        }

        //// GET: Societies/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var society = await _logic.Societies.FindAsync(id);
        //    if (society == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ClientId"] = new SelectList(_logic.Clients, "Id", "Id", society.ClientId);
        //    return View(society);
        //}

        //// POST: Societies/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,SocietyName,AgeLimit,Sum,ClientId")] Society society)
        //{
        //    if (id != society.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _logic.Update(society);
        //            await _logic.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SocietyExists(society.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ClientId"] = new SelectList(_logic.Clients, "Id", "Id", society.ClientId);
        //    return View(society);
        //}

        //// GET: Societies/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var society = await _logic.Societies
        //        .Include(s => s.Client)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (society == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(society);
        //}

        //// POST: Societies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var society = await _logic.Societies.FindAsync(id);
        //    _logic.Societies.Remove(society);
        //    await _logic.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SocietyExists(int id)
        //{
        //    return _logic.Societies.Any(e => e.Id == id);
        //}
    }
}
