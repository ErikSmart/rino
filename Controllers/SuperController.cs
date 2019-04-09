using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult borrar()
        {
            var id = 3;
            using (var db = new LinqContext())
            {
                db.alumnos.Select(x => x.id == id).FirstOrDefault();
            }
            using (var dba = new LinqContext())
            {
                var estudiante = new alumnos();
                estudiante.id = id;
                dba.Entry(estudiante).State = EntityState.Deleted;
                dba.SaveChanges();
            }
            return View();
        }
    }
}