using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class CachingController : Controller
    {
        #region Para Cache Personalizada

        private IMemoryCache MemoryCache;

        public CachingController(IMemoryCache memorycache)
        {
            this.MemoryCache = memorycache;
        }

        public IActionResult HoraSistema(int? tiempo)
        {
            if (tiempo == null)
            {
                tiempo = 5;
            }
            String fecha = DateTime.Now.ToShortDateString() + ", "
                + DateTime.Now.ToLongTimeString();
            //PREGUNTAMOS SI EXISTE ALGO EN CACHÉ
            if (this.MemoryCache.Get("fecha") == null)
            {
                //NO EXISTE, LO CREAMOS
                this.MemoryCache.Set("fecha", fecha
                    , new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration
                    (TimeSpan.FromSeconds(tiempo.GetValueOrDefault())));
                ViewData["fecha"] = this.MemoryCache.Get("fecha");
                ViewData["mensaje"] = "Almacenando en Caché. "
                    + tiempo.Value + " segundos.";
            }
            else
            {
                //RECUPERAMOS LA FECHA DEL CACHÉ
                fecha = this.MemoryCache.Get("fecha").ToString();
                ViewData["mensaje"] = "Recuperando de Caché";
                ViewData["fecha"] = fecha;
            }
            return View();
        }
        #endregion

        #region Para Cache Distribuida

        //[ResponseCache(Duration = 15, VaryByQueryKeys = new String[] { "dato" })]
        //[ResponseCache(Duration = 15, VaryByQueryKeys = new String[] { "dato1", "dato2" })]
        [ResponseCache(Duration = 15, VaryByQueryKeys = new String[] { "*" })]
        public IActionResult HoraSistemaDistribuida(String dato)
        {
            String fecha = DateTime.Now.ToShortDateString() + ", "
                + DateTime.Now.ToLongTimeString();
            ViewData["fecha"] = fecha;
            return View();
        }
        #endregion
    }
}
