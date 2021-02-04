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
using MvcCore.Extensions;
using MvcCore.Helpers;
using MvcCore.Models;

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

        public IActionResult EjemploSession(String accion)
        {
            if(accion == "almacenar")
            {
                Persona person = new Persona();
                person.Nombre = "Alumno";
                person.Edad = 27;
                person.Hora = DateTime.Now.ToLongTimeString();
                //byte[] data = HelperToolKit.ObjectToByteArray(person);
                //HttpContext.Session.Set("persona", data);
                String data = HelperToolKit.SerializeJsonObject(person);
                HttpContext.Session.SetString("persona", data);
                //HttpContext.Session.SetString("autor", "Programeitor");
                //HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                ViewData["mensaje"] = "Datos almacenados en Session " + DateTime.Now.ToLongTimeString();
            }else if(accion == "mostrar")
            {
                //byte[] data = HttpContext.Session.Get("persona");
                //Persona person = HelperToolKit.ByteArrayToObject(data) as Persona;
                String data = HttpContext.Session.GetString("persona");
                //Persona person = HelperToolKit.DeserializeJsonObject(data, typeof(Persona)) as Persona;
                Persona person = HelperToolKit.DeserializeJsonObject<Persona>(data);
                ViewData["autor"] = person.Nombre + ", Edad: " + person.Edad;
                ViewData["hora"] = person.Hora;
                ViewData["mensaje"] = "Mostrando datos";
            }
            return View();
        }

        public IActionResult AlmacenarMultipleSession(String accion)
        {
            if (accion == "almacenar")
            {
                List<Persona> personas = new List<Persona>();
                Persona p = new Persona {
                    Nombre = "Naza",
                    Edad = 27,
                    Hora = DateTime.Now.ToLongTimeString()
                };
                personas.Add(p);
                p = new Persona
                {
                    Nombre = "Rober",
                    Edad = 30,
                    Hora = DateTime.Now.ToLongTimeString()
                };
                personas.Add(p);
                //byte[] data = HelperToolKit.ObjectToByteArray(personas);
                //HttpContext.Session.Set("personas", data);
                //String data = HelperToolKit.SerializeJsonObject(personas);
                //HttpContext.Session.SetString("personas", data);
                HttpContext.Session.SetObject("personas", personas);
                ViewData["mensaje"] = "Almacenado " + DateTime.Now.ToLongTimeString();
            }
            else if (accion == "mostrar")
            {
                //byte[] data = HttpContext.Session.Get("personas");
                //List<Persona> personas = HelperToolKit.ByteArrayToObject(data) as List<Persona>;
                String data = HttpContext.Session.GetString("personas");
                //List<Persona> personas = HelperToolKit.DeserializeJsonObject(data, typeof(List<Persona>)) as List<Persona>;
                //List<Persona> personas = HelperToolKit.DeserializeJsonObject<List<Persona>>(data);
                List<Persona> personas = HttpContext.Session.GetObject<List<Persona>>(data);
                ViewData["mensaje"] = "Recuperando de Session";
                return View(personas);
            }
            return View();
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
