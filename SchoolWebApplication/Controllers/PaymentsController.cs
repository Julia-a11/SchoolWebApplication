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
    public class PaymentsController : Controller
    {
        private readonly PaymentLogic _paymentLogic;

        private readonly LessonLogic _lessonLogic;

        public PaymentsController(PaymentLogic paymentLogic, LessonLogic lessonLogic)
        {
            _paymentLogic = paymentLogic;
            _lessonLogic = lessonLogic;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var payments = _paymentLogic.Read(null);
            return View(payments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentLogic.Read(new PaymentBindingModel
            {
                Id = id
            }).FirstOrDefault();
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["LessonId"] = new SelectList(_lessonLogic.Read(null), "Id", "LessonName");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sum,LessonId")] PaymentBindingModel payment)
        {
            if (ModelState.IsValid)
            {
                _paymentLogic.CreateOrUpdate(payment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new SelectList(_lessonLogic.Read(null), "Id", "LessonName", payment.LessonId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentLogic.Read(new PaymentBindingModel { Id = id }).FirstOrDefault();
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new SelectList(_lessonLogic.Read(null), "Id", "LessonName", payment.LessonId);
            return View(new PaymentBindingModel
            {
               Id = payment.Id,
               Sum = payment.Sum
            });
        }


        //// POST: Payments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sum,LessonId")] PaymentBindingModel payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paymentLogic.CreateOrUpdate(payment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(id))
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
            ViewData["LessonId"] = new SelectList(_lessonLogic.Read(null), "Id", "LessonName", payment.LessonId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentLogic.Read(new PaymentBindingModel { Id = id }).FirstOrDefault();
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _paymentLogic.Delete(new PaymentBindingModel { Id = id });
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _paymentLogic.Read(null).Any(e => e.Id == id);
        }
    }
}
