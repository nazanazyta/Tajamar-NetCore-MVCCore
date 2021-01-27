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
            //MailMessage mail = new MailMessage();
            ////String usermail = this.Configuration["usuariomail"];
            ////String passwordmail = this.Configuration["passwordmail"];
            //String usermail = this.Configuration["usumailproyecto"];
            //String passwordmail = this.Configuration["passmailproyecto"];
            //mail.From = new MailAddress(usermail);
            //mail.To.Add(new MailAddress(receptor));
            //mail.Subject = asunto;
            //mail.Body = mensaje;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.Normal;
            //if (fichero != null)
            //{
            //    String path = this.UploadService.UploadFile(fichero).Result;
            //    //String filename = fichero.FileName;
            //    //String path = this.PathProvider.MapPath(filename, Folders.Temporal);
            //    //using (var stream = new FileStream(path, FileMode.Create))
            //    //{
            //    //    await fichero.CopyToAsync(stream);
            //    //}
            //    Attachment attachment = new Attachment(path);
            //    mail.Attachments.Add(attachment);
            //}
            //String smtpserver = this.Configuration["host"];
            //int port = int.Parse(this.Configuration["port"]);
            //bool ssl = bool.Parse(this.Configuration["ssl"]);
            //bool defaultcredentials = bool.Parse(this.Configuration["defaultcredentials"]);
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = smtpserver;
            //smtpClient.Port = port;
            //smtpClient.EnableSsl = ssl;
            //smtpClient.UseDefaultCredentials = defaultcredentials;
            //NetworkCredential usercredential = new NetworkCredential(usermail, passwordmail);
            //smtpClient.Credentials = usercredential;
            //smtpClient.Send(mail);
            //ViewData["mensaje"] = "Mensaje enviado";
            //return View();
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
            //String filename = fichero.FileName;
            //String path = this.PathProvider.MapPath(filename, Folders.Images);
            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    await fichero.CopyToAsync(stream);
            //}
            //ViewData["mensaje"] = "Archivo subido: " + path;
            //return View();
        }

        public IActionResult CifradoHash()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoHash(String contenido, String resultado, String accion)
        {
            //PRIMERO EN BRUTO Y LUEGO HACEMOS INYECCIÓN DE LO NECESARIO
            //NECESITAMOS TRABAJAR A NIVEL DE byte[]
            //DEBEMOS CONVERTIR A byte[] EL CONTENIDO DE ENTRADA
            byte[] entrada;
            //EL CIFRADO SE REALIZA A NIVEL DE byte[]
            //Y DEVOLVERÁ OTRO byte[] DE SALIDA
            byte[] salida;
            //NECESITAMOS UN CONVERSOR PARA TRANSFORMAR byte[]
            //A String Y VICEVERSA
            UnicodeEncoding encoding = new UnicodeEncoding();
            //NECESITAMOS EL OBJETO QUE SE ENCARGARÁ
            //DE REALIZAR EL CIFRADO -> using System.Security.Cryptography;
            SHA1Managed sha = new SHA1Managed();
            //DEBEMOS CONVERTIR EL CONTENIDO DE ENTRADA A byte[]
            entrada = encoding.GetBytes(contenido);
            //EL OBJETO SHA1Managed TIENE UN MÉOTOD
            //PARA DEVOLVER LOS byte[] DE SALIDA REALIZANDO EL CIFRADO
            salida = sha.ComputeHash(entrada);
            String res = encoding.GetString(salida);
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
    }
}
