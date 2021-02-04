using Microsoft.AspNetCore.Mvc;
using MvcCore.Extensions;
using MvcCore.Models;
using MvcCore.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class EmpleadosSessionController : Controller
    {
        IRepositoryHospital Repo;

        public EmpleadosSessionController(IRepositoryHospital repo)
        {
            this.Repo = repo;
        }

        public IActionResult AlmacenarEmpleados(int? idemp)
        {
            //NECESITAMOS PREGUNTAR SI HEMOS RECUBIDO DATOS
            if (idemp != null)
            {
                List<int> empsession;
                //SI EXISTE LA SESIÓN, RECUPERAMOS LA LISTA
                //SI NO EXISTE, CREAMOS LA LISTA
                if (HttpContext.Session.GetObject<List<int>>("empleados") == null)
                {
                    empsession = new List<int>();
                }
                else
                {
                    empsession = HttpContext.Session.GetObject<List<int>>("empleados");
                }
                if (empsession.Contains(idemp.Value) == false)
                {
                    empsession.Add(idemp.GetValueOrDefault());
                    //ALMACENAMOS LOS NUEVOS DATOS EN SESSION
                    HttpContext.Session.SetObject("empleados", empsession);
                }
                
                ViewData["mensaje"] = "Datos almacenados: " + empsession.Count;
            }
            List<Empleado> empleados = this.Repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult MostrarEmpleados(int? eliminar)
        {
            List<int> empsession = HttpContext.Session.GetObject<List<int>>("empleados");
            if (empsession == null)
            {
                return View();
            }
            else
            {
                if (eliminar != null)
                {
                    empsession.Remove(eliminar.Value);
                    HttpContext.Session.SetObject("empleados", empsession);
                }
                List<Empleado> empleados = this.Repo.GetEmpleadosSession(empsession);
                return View(empleados);
            }
        }

        [HttpPost]
        public IActionResult MostrarEmpleados(List<int> cantidades)
        {
            //NECESITAMOS SABER SI VIENEN A LA PAR
            //SANCHA 7369 DEBE ESTAR EN POSICIÓN 0, 5
            //ARROYO 7499 DEBE ESTAR EN POSICIÓN 1, 1
            List<int> empsession = HttpContext.Session.GetObject<List<int>>("empleados");
            List<Empleado> empleados = this.Repo.GetEmpleadosSession(empsession);
            TempData["empleados"] = JsonConvert.SerializeObject(empleados);
            TempData["cantidades"] = JsonConvert.SerializeObject(cantidades);
            return RedirectToAction("Pedidos");
        }

        public IActionResult Pedidos()
        {
            //return View();
            ViewData["cantidades"] = JsonConvert.DeserializeObject<List<int>>((string)TempData["cantidades"]);
            return View(JsonConvert.DeserializeObject<List<Empleado>>((string)TempData["empleados"]));
        }

        //[HttpPost]
        //public IActionResult Pedidos(List<int> cantidades)
        //{
        //    //NECESITAMOS SABER SI VIENEN A LA PAR
        //    //SANCHA 7369 DEBE ESTAR EN POSICIÓN 0, 5
        //    //ARROYO 7499 DEBE ESTAR EN POSICIÓN 1, 1
        //    ViewData["cantidades"] = cantidades;
        //    List<int> empsession = HttpContext.Session.GetObject<List<int>>("empleados");
        //    List<Empleado> empleados = this.Repo.GetEmpleadosSession(empsession);
        //    //TempData["empleados"] = empleados;
        //    //TempData["cantidades"] = cantidades;
        //    //return RedirectToAction("Pedidos");
        //    return View(empleados);
        //}
    }
}
