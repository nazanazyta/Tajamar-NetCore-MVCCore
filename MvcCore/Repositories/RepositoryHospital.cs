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

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        #region TABLA DEPARTAMENTOS
        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
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

        public void ModificarDepartamento(int numdepar, string nombre, string loc)
        {
            Departamento depar = this.BuscarDepartamento(numdepar);
            depar.Nombre = nombre;
            depar.Localidad = loc;
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
            var consulta = from datos in this.context.Empleados
                           where iddepartamentos.Contains(datos.Departamento)
                           select datos;
            return consulta.ToList();
        }
        #endregion
    }
}
