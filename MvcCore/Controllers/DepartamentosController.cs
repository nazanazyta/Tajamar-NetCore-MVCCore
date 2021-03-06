﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Helpers;
using MvcCore.Models;
using MvcCore.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryHospital repo;
        PathProvider pathprovider;

        public DepartamentosController(IRepositoryHospital repo, PathProvider pathprovider)
        {
            this.repo = repo;
            this.pathprovider = pathprovider;
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
        public async Task<IActionResult> Edit(Departamento depar, IFormFile ficheroimagen)
        {
            if(ficheroimagen != null)
            {
                String filename = ficheroimagen.FileName;
                String path = this.pathprovider.MapPath(filename, Folders.Images);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ficheroimagen.CopyToAsync(stream);
                }
                this.repo.ModificarDepartamento(depar.Numero, depar.Nombre, depar.Localidad, filename);
                return RedirectToAction("Index");
            }
            else
            {
                this.repo.ModificarDepartamento(depar.Numero, depar.Nombre, depar.Localidad);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento depar, IFormFile ficheroimagen)
        {
            if(ficheroimagen != null)
            {
                String filename = ficheroimagen.FileName;
                String path = this.pathprovider.MapPath(filename, Folders.Images);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ficheroimagen.CopyToAsync(stream);
                }
                this.repo.InsertarDepartamento(depar.Numero, depar.Nombre, depar.Localidad, filename);
                return RedirectToAction("Index");
            }
            else
            {
                this.repo.InsertarDepartamento(depar.Numero, depar.Nombre, depar.Localidad);
                return RedirectToAction("Index");
            }
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
