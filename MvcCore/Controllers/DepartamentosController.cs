using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using MvcCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryHospital repo;

        public DepartamentosController(IRepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int numdepar)
        {
            Departamento depar = this.repo.BuscarDepartamento(numdepar);
            return View(depar);
        }

        public IActionResult Delete(int numdepar)
        {
            this.repo.EliminarDepartamento(numdepar);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int numdepar)
        {
            Departamento depar = this.repo.BuscarDepartamento(numdepar);
            return View(depar);
        }

        [HttpPost]
        public IActionResult Edit(Departamento depar)
        {
            this.repo.ModificarDepartamento(depar.Numero, depar.Nombre, depar.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departamento depar)
        {
            this.repo.InsertarDepartamento(depar.Numero, depar.Nombre, depar.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult SeleccionMultiple()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            List<Empleado> empleados = this.repo.GetEmpleados();
            ViewData["departamentos"] = departamentos;
            return View(empleados);
        }

        [HttpPost]
        public IActionResult SeleccionMultiple(List<int> iddepartamentos)
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            List<Empleado> empleados = this.repo.BuscarEmpleadosDepartamentos(iddepartamentos);
            ViewData["departamentos"] = departamentos;
            return View(empleados);
        }
    }
}
