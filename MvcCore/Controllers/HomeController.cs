using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcCore.Helpers;

namespace MvcCore.Controllers
{
    public class HomeController : Controller
    {
        UploadService UploadService;
        MailService MailService;

        public HomeController(UploadService uploadservice
            , MailService mailservice)
        {
            this.UploadService = uploadservice;
            this.MailService = mailservice;
        }

        public IActionResult EjemploMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EjemploMail(String receptor, String asunto
            , String mensaje, IFormFile fichero)
        {
            if (fichero != null)
            {
                String path = await this.UploadService.UploadFileAsync(fichero, Folders.Temporal);
                this.MailService.SendEmail(receptor, asunto, mensaje, path);
            }
            else
            {
                this.MailService.SendEmail(receptor, asunto, mensaje);
            }
            ViewData["mensaje"] = "Mensaje enviado";
            return View();
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
            await this.UploadService.UploadFileAsync(fichero, Folders.Images);
            ViewData["mensaje"] = "Archivo subido";
            return View();
        }

        public IActionResult CifradoHash()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoHash(String contenido, String resultado, String accion)
        {
            String res = CypherService.EncriptarTextoBasico(contenido);
            //SOLAMENTE SI ESCRIBIMOS EL MISMO CONTENIDO
            //TENDRÍAMOS LA MISMA SECUENCIA DE SALIDA
            if (accion.ToLower() == "cifrar")
            {
                ViewData["resultado"] = res;
            }
            else if (accion.ToLower() == "comparar")
            {
                //COMPARAMOS LA CAJA DE TEXTO resultado
                //CON EL DATO YA CIFRADO DE NUEVO res
                if (resultado != res)
                {
                    ViewData["mensaje"] = "<h1 style='color: red'>No son iguales</h1>";
                }
                else
                {
                    ViewData["mensaje"] = "<h1 style='color: blue'>Iguales</h1>";
                }
            }
            return View();
        }

        public IActionResult CifradoHashEficiente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoHashEficiente(String contenido, int iteraciones
            , String salt, String resultado,  String accion)
        {
            String cifrado = CypherService.CifrarContenido(contenido, iteraciones, salt);
            if (accion.ToLower() == "cifrar")
            {
                ViewData["resultado"] = cifrado;
            }else if (accion.ToLower() == "comparar")
            {
                if (resultado == cifrado)
                {
                    ViewData["mensaje"] = "<h1 style='color: blue'>Son iguales!!</h1>";
                }
                else
                {
                    ViewData["mensaje"] = "<h1 style='color: red'>Diferentes</h1>";
                }
            }
            return View();
        }
    }
}
