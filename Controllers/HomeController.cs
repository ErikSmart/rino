using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rino.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;

namespace Rino.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult insertar()
        {

            using (var db = new LinqContext())
            {
                var sistemax = new software();
                var sistemax2 = new software();
                var sietmeax3 = new software();

                sistemax.os = "Linux";
                sistemax.nombre = "Atom";
                sistemax.precio = 30;

                sistemax2.os = "Windos";
                sistemax2.nombre = "Visual";
                sistemax2.precio = 0;

                sietmeax3.os = "Os X";
                sietmeax3.nombre = "Sublime text";
                sietmeax3.precio = 100;

                var lista = new List<software>() { sistemax, sistemax2, sietmeax3 };

                db.software.AddRange(lista);
                db.SaveChanges();


            }


            return View();
        }

        public IActionResult mostrar()
        {
            using (var db = new LinqContext())
            {
                var mostrar = db.software.OrderByDescending(x => x.nombre).ThenBy(x => x.os).ToList();
                ViewData["programa"] = mostrar;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}