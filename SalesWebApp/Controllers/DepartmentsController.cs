using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
using System.Collections.Generic;
using SalesWebApp.Models;

namespace SalesWebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Eletronicos" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
