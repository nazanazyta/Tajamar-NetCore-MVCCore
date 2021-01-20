using MvcCore.Helpers;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCore.Repositories
{
    public class RepositoryAlumnos
    {
        PathProvider pathprovider;
        private XDocument docxml;
        private String path;

        public RepositoryAlumnos(PathProvider pathprovider)
        {
            this.pathprovider = pathprovider;
            this.path = this.pathprovider.MapPath("alumnos.xml", Folders.Documents);
            this.docxml = XDocument.Load(this.path);
        }

        public List<Alumno> GetAlumnos()
        {
            var consulta = from datos in this.docxml.Descendants("alumno")
                           select new Alumno
                           {
                               IdAlumno = int.Parse(datos.Element("idalumno").Value)
                               ,
                               Nombre = datos.Element("nombre").Value
                               ,
                               Apellidos = datos.Element("apellidos").Value
                               ,
                               Nota = int.Parse(datos.Element("nota").Value)
                           };
            return consulta.ToList();
        }

        public Alumno BuscarAlumno(int idalumno)
        {
            var consulta = from datos in this.docxml.Descendants("alumno")
                           where datos.Element("idalumno").Value == idalumno.ToString()
                           select new Alumno
                           {
                               IdAlumno = int.Parse(datos.Element("idalumno").Value)
                               ,
                               Nombre = datos.Element("nombre").Value
                               ,
                               Apellidos = datos.Element("apellidos").Value
                               ,
                               Nota = int.Parse(datos.Element("nota").Value)
                           };
            //EL VALOR POR DEFECTO DE UN OBJETO SERÍA UN NULL
            return consulta.FirstOrDefault();
        }

        public void EliminarAlumno(int idalumno)
        {
            //CUANDO HABLAMOS DE CONSULTAS DE ACCIÓN SOBRE XML
            //TENEMOS QUE PENSAR QUE DEBEMOS ACCEDER A ETIQUETAS,
            //NO A OBJETOS Alumno
            var consulta = from datos in this.docxml.Descendants("alumno")
                           where datos.Element("idalumno").Value == idalumno.ToString()
                           select datos;
            XElement elementalumno = consulta.FirstOrDefault();
            elementalumno.Remove();
            this.docxml.Save(this.path);
        }

        public void InsertarAlumno(int idalumno, String nombre, String apellidos, int nota)
        {
            /*
            <alumno>
              <idalumno>1</idalumno>
              <nombre>Nacho</nombre>
              <apellidos>Shum Llanos</apellidos>
              <nota>8</nota>
            </alumno>
            */
            XElement elementalumno = new XElement("alumno");
            XElement elementidalumno = new XElement("idalumno", idalumno);
            XElement elementnombre = new XElement("nombre", nombre);
            XElement elementapellidos = new XElement("apellidos", apellidos);
            XElement elementnota = new XElement("nota", nota);
            elementalumno.Add(elementidalumno);
            elementalumno.Add(elementnombre);
            elementalumno.Add(elementapellidos);
            elementalumno.Add(elementnota);
            //EL XMLELEMENT DEBEMOS AGREGARLO AL DOCUMENTO
            //Y EN LA ETIQUERA QUE CORRESPONDA
            this.docxml.Root.Add(elementalumno);
            //this.docxml.Element("alumnos").Add(elementalumno);
            this.docxml.Save(this.path);
        }

        public void ModificarAlumno(int idalumno, String nombre, String apellidos, int nota)
        {
            //NECESITAMOS ENCONTRAR EL XElement QUE CORRESPONDA CON EL ID
            var consulta = from datos in this.docxml.Descendants("alumno")
                           where datos.Element("idalumno").Value == idalumno.ToString()
                           select datos;
            XElement element = consulta.FirstOrDefault();
            element.Element("nombre").Value = nombre;
            element.Element("apellidos").Value = apellidos;
            element.Element("nota").Value = nota.ToString();
            this.docxml.Save(this.path);
        }
    }
}
