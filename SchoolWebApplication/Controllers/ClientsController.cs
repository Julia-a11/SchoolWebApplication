using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.BusinessLogic;
using SchoolDAL;
using SchoolDAL.Models;

namespace SchoolWebApplication.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientLogic _logic;

        public ClientsController(ClientLogic logic)
        {
            _logic = logic;
        }



        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientName, ClientSurname, ClientPatronymic, DateBirth, Login, Password")] ClientBindingModel model)
        {
            if (ModelState.IsValid)
            {
                _logic.CreateOrUpdate(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Login,Password")] ClientBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Program.Client = _logic.Login(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
