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
        public readonly SoftwareContext _context;
        public IActionResult Index()
        {
            using (var db = new LinqContext())
            {
                var mostrar = db.software.Where(x => x.nombre == "Atom");
                foreach (var item in mostrar.ToList())
                {
                    ViewData["mostar"] = item.nombre;
                }

            }

            return View();
        }

        public IActionResult insertar()
        {

            using (var db = new LinqContext())
            {
                var sistemax = new software();
                var sistemax2 = new software();
                var sietmeax3 = new software();

                var alumno = new alumnos();
                var alumno1 = new alumnos();
                var alumno3 = new alumnos();
                var alumno2 = new alumnos();




                alumno.estudiante = "Guillermo Topete";
                alumno.fecha = new DateTime(1998, 05, 10);


                alumno1.estudiante = "Albertana Solis";
                alumno1.fecha = new DateTime(2001, 03, 02);

                alumno3.estudiante = "Justina Sanchez";
                alumno3.fecha = new DateTime(1999, 02, 21);

                alumno2.estudiante = "Celia Kali";
                alumno2.fecha = DateTime.Now;


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
                var listaAlumnos = new List<alumnos>() { alumno, alumno1, alumno2, alumno3 };

                db.software.AddRange(lista);
                db.alumnos.AddRange(listaAlumnos);
                db.SaveChanges();


            }


            return View();
        }

        public IActionResult mostrar(int? numeros)
        {

            using (var db = new LinqContext())
            {
                // Sacando todos los datos
                var mostrarTodos = db.software.OrderByDescending(x => x.nombre).ThenBy(x => x.os).ToList();

                ViewData["programa"] = mostrarTodos;
                // Sacando solo un dato
                var soloUno = db.software.Where(x => x.nombre.StartsWith("a"));

                if (soloUno != null)
                {
                    ViewData["individual"] = "No hay valor encontrado";
                    if (true)
                    {
                        foreach (var item in soloUno)
                        {
                            ViewData["individual"] = item.nombre;
                        }
                    }
                }
                // Selector de la base de datos
                numeros = 1;
                ViewData["numeros"] = numeros;

                var selecionar = db.software.Select(x => new identidades { precio = x.precio, nombre = x.nombre }).FromSql("select nombre, precio from software where id={0}", numeros).ToList();
                // Suma de una columna
                var total = db.software.Select(x => x.precio).Sum();
                foreach (var item in selecionar.ToList())
                {
                    ViewData["selecionar"] = item.nombre + item.precio;
                }

                var alumnos = db.alumnos.Where(x => x.fecha >= DateTime.Today.AddYears(-19)).ToList();

                ViewData["alumni"] = alumnos;
                /* foreach (var itemi in alumnos.ToList())
                {
                    ViewData["alumni"] = itemi.estudiante;

                } */


                ViewData["total"] = total;


            }


            return View();
        }
        class identidades
        {
            public double precio { get; set; }
            public string nombre { get; set; }
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