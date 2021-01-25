using MvcCore.Data;
using MvcCore.Models;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Repositories
{
    public class RepositoryDepartamentosMySql : IRepositoryDepartamentos
    {
        HospitalContext context;

        public RepositoryDepartamentosMySql(HospitalContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }

        public Departamento BuscarDepartamento(int numdepar)
        {
            return this.context.Departamentos.Where(x => x.Numero == numdepar).FirstOrDefault();
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
    }
}
