using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Helpers;

namespace MvcCore.Controllers
{
    public class HomeController : Controller
    {
        PathProvider PathProvider;

        public HomeController(PathProvider pathprovider)
        {
            this.PathProvider = pathprovider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFichero(IFormFile fichero)
        {
            String filename = fichero.FileName;
            String path = this.PathProvider.MapPath(filename, Folders.Images);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            ViewData["mensaje"] = "Archivo subido: " + path;
            return View();
        }
    }
}
