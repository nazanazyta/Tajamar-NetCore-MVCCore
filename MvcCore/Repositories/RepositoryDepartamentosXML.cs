using MvcCore.Helpers;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCore.Repositories
{
    public class RepositoryDepartamentosXML: IRepositoryDepartamentos
    {
        PathProvider pathprovider;
        private XDocument docxml;
        private String path;

        public RepositoryDepartamentosXML(PathProvider pathprovider)
        {
            this.pathprovider = pathprovider;
            this.path = this.pathprovider.MapPath("departamentos.xml", Folders.Documents);
            this.docxml = XDocument.Load(this.path);
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.docxml.Descendants("DEPARTAMENTO")
                           select new Departamento
                           {
                               Numero = int.Parse(datos.Attribute("NUMERO").Value)
                               ,
                               Nombre = datos.Element("NOMBRE").Value
                               ,
                               Localidad = datos.Element("LOCALIDAD").Value
                           };
            return consulta.ToList();
        }

        public Departamento BuscarDepartamento(int numdepar)
        {
            var consulta = from datos in this.docxml.Descendants("DEPARTAMENTO")
                           where datos.Attribute("NUMERO").Value == numdepar.ToString()
                           select new Departamento
                           {
                               Numero = int.Parse(datos.Attribute("NUMERO").Value)
                               ,
                               Nombre = datos.Element("NOMBRE").Value
                               ,
                               Localidad = datos.Element("LOCALIDAD").Value
                           };
            return consulta.FirstOrDefault();
        }

        //MÉTODO PRIVADO PARA ELIMINAR Y MODIFICAR
        private XElement GetXElementDepartamento(int numdepar)
        {
            var consulta = from datos in this.docxml.Descendants("DEPARTAMENTO")
                           where datos.Attribute("NUMERO").Value == numdepar.ToString()
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void EliminarDepartamento(int numdepar)
        {
            //var consulta = from datos in this.docxml.Descendants("DEPARTAMENTO")
            //               where datos.Attribute("NUMERO").Value == numdepar.ToString()
            //               select datos;
            //XElement elementdepar = consulta.FirstOrDefault();
            //elementdepar.Remove();
            XElement xelem = this.GetXElementDepartamento(numdepar);
            xelem.Remove();
            this.docxml.Save(this.path);
        }

        public void ModificarDepartamento(int numdepar, String nombre, String loc)
        {
            //var consulta = from datos in this.docxml.Descendants("DEPARTAMENTO")
            //               where datos.Attribute("NUMERO").Value == numdepar.ToString()
            //               select datos;
            //XElement eldepar = consulta.FirstOrDefault();
            //eldepar.Element("NOMBRE").Value = nombre;
            //eldepar.Element("LOCALIDAD").Value = loc;
            XElement xelem = this.GetXElementDepartamento(numdepar);
            xelem.Element("NOMBRE").Value = nombre;
            xelem.Element("LOCALIDAD").Value = loc;
            this.docxml.Save(this.path);
        }

        public void InsertarDepartamento(int numdepar, String nombre, String loc)
        {
            XElement eldepar = new XElement("DEPARTAMENTO");
            eldepar.Add(new XElement("NOMBRE", nombre), new XElement("LOCALIDAD", loc));
            eldepar.Add(new XAttribute("NUMERO", numdepar));
            //eldepar.SetAttributeValue("NUMERO", numdepar);
            this.docxml.Element("DEPARTAMENTOS").Add(eldepar);
            this.docxml.Save(this.path);
        }

        public void InsertarDepartamento(int deptno, string nombre, string loc, string imagen)
        {
            throw new NotImplementedException();
        }

        public void ModificarDepartamento(int numdepar, string nombre, string loc, string img)
        {
            throw new NotImplementedException();
        }
    }
}
