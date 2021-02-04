using Microsoft.Extensions.Caching.Memory;
using MvcCore.Data;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Repositories
{
    public class RepositoryHospital : IRepositoryHospital
    {
        HospitalContext context;
        IMemoryCache MemoryCache;

        public RepositoryHospital(HospitalContext context, IMemoryCache memorycache)
        {
            this.context = context;
            this.MemoryCache = memorycache;
        }

        #region TABLA DEPARTAMENTOS
        public List<Departamento> GetDepartamentos()
        {
            //DEVOLVEMOS DEPARTAMENTOS DE LA MEMORIA CACHÉ
            //O RECUPERAMOS DEPARTAMENTOS DE SQL SERVER
            List<Departamento> lista;
            if (this.MemoryCache.Get("departamentos") == null)
            {
                var consulta = from datos in this.context.Departamentos
                               select datos;
                lista = consulta.ToList();
                //ALMACENAMOS LA LISTA EN CACHÉ
                this.MemoryCache.Set("departamentos", lista);
            }
            else
            {
                lista = this.MemoryCache.Get("departamentos") as List<Departamento>;
            }
            //CÓDIGO ANTERIOR, SIN CACHÉ
            ////var consulta = from datos in this.context.Departamentos
            ////               select datos;
            ////return consulta.ToList();
            //return this.context.Departamentos.ToList();
            return lista;
        }

        public Departamento BuscarDepartamento(int numdepar)
        {
            return this.context.Departamentos.Where(z => z.Numero == numdepar).FirstOrDefault();
        }

        public void EliminarDepartamento(int numdepar)
        {
            Departamento depar = this.BuscarDepartamento(numdepar);
            this.context.Departamentos.Remove(depar);
            this.context.SaveChanges();
        }

        public void InsertarDepartamento(int numdepar, string nombre, string loc)
        {
            Departamento depar = new Departamento();
            depar.Numero = numdepar;
            depar.Nombre = nombre;
            depar.Localidad = loc;
            this.context.Departamentos.Add(depar);
            this.context.SaveChanges();
        }

        public void InsertarDepartamento(int deptno, string nombre, string loc, string imagen)
        {
            Departamento dept = new Departamento();
            dept.Numero = deptno;
            dept.Nombre = nombre;
            dept.Localidad = loc;
            dept.Imagen = imagen;
            this.context.Departamentos.Add(dept);
            this.context.SaveChanges();
        }

        public void ModificarDepartamento(int numdepar, string nombre, string loc)
        {
            Departamento depar = this.BuscarDepartamento(numdepar);
            depar.Nombre = nombre;
            depar.Localidad = loc;
            this.context.SaveChanges();
        }

        public void ModificarDepartamento(int numdepar, string nombre, string loc, string img)
        {
            Departamento depar = this.BuscarDepartamento(numdepar);
            depar.Nombre = nombre;
            depar.Localidad = loc;
            depar.Imagen = img;
            this.context.SaveChanges();
        }
        #endregion

        #region TABLA EMPLEADOS
        public List<Empleado> GetEmpleados()
        {
            return this.context.Empleados.ToList();
        }

        public List<Empleado> BuscarEmpleadosDepartamentos(List<int> iddepartamentos)
        {
            //select * from emp where dept_no in(10,20,30)
            var consulta = from datos in this.context.Empleados
                           where iddepartamentos.Contains(datos.Departamento)
                           select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosSession(List<int> idempleados)
        {
            var consulta = from datos in this.context.Empleados
                           where idempleados.Contains(datos.IdEmpleado)
                           select datos;
            return consulta.ToList();
        }
        #endregion
    }
}
