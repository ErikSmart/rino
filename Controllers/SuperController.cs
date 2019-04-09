using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rino.Models;

namespace Rino.Controllers
{
    public class SuperController : Controller
    {
        public IActionResult index()
        {
            using (var db = new LinqContext())
            {
                ViewData["a"] = "Estoy en super";
            }
            return View();
        }

        public IActionResult actualizar()
        {
            using (var db = new LinqContext())
            {
                /*  var alumno = new alumnos(); */
                var buscar = db.alumnos.First(x => x.estudiante.StartsWith("Celia"));
                buscar.estudiante += " Abascal";
                db.SaveChanges();

            }
            return View();
        }
    }
}