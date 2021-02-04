using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Models
{
    //DECORACIÓN PARA byte[]
    //[Serializable]
    public class Persona
    {
        public String Nombre { get; set; }
        public int Edad { get; set; }
        public String Hora { get; set; }
    }
}
