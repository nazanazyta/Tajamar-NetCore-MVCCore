using MvcCore.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Repositories
{
    public class RepositoryDepartamentosOracle : IRepositoryDepartamentos
    {
        OracleDataAdapter adapdept;
        DataTable tabledept;
        OracleCommandBuilder builder;

        public RepositoryDepartamentosOracle(String cadenaoracle)
        {
            this.adapdept = new OracleDataAdapter("select * from dept", cadenaoracle);
            this.builder = new OracleCommandBuilder(this.adapdept);
            this.tabledept = new DataTable();
            this.adapdept.Fill(this.tabledept);
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.tabledept.AsEnumerable()
                           select new Departamento
                           {
                               Numero = datos.Field<int>("dept_no")
                               ,
                               Nombre = datos.Field<String>("dnombre")
                               ,
                               Localidad = datos.Field<String>("loc")
                           };
            return consulta.ToList();
        }

        public Departamento BuscarDepartamento(int numdepar)
        {
            var consulta = from datos in this.tabledept.AsEnumerable()
                           where datos.Field<int>("dept_no") == numdepar
                           select new Departamento
                           {
                               Numero = datos.Field<int>("dept_no")
                               ,
                               Nombre = datos.Field<String>("dnombre")
                               ,
                               Localidad = datos.Field<String>("loc")
                           };
            return consulta.FirstOrDefault();
        }

        //MÉTODO PRIVADO PARA ELIMINAR Y MODIFICAR
        private DataRow GetDataRowId(int numdepar)
        {
            DataRow fila = this.tabledept.AsEnumerable()
                .Where(z => z.Field<int>("dept_no") == numdepar).FirstOrDefault();
            return fila;
        }

        public void EliminarDepartamento(int numdepar)
        {
            //PARA ELIMINAR, DEBEMOS HACERLO SOBRE EL OBJETO DataTable
            //DEBEMOS BUSCAR LA FILA (DataRow) QUE CORRESPONDA CON EL ID
            //LA FILA TIENE UN MÉTODO DELETE QUE MARCARÁ EN LA TABLA
            //EL VALOR PARA ELIMINAR
            //POSTERIORMENTE, EL ADAPTADOR, AL IGUAL QUE TIENE UN MÉTODO
            //PARA TRAER LOS DATOS (Fill), TENEMOS UN MÉTODO PARA
            //AUTOMATIZAR LOS CAMBIOS (Update)
            DataRow row = this.GetDataRowId(numdepar);
            row.Delete();
            this.adapdept.Update(this.tabledept);
            this.tabledept.AcceptChanges();
        }

        public void InsertarDepartamento(int numdepar, string nombre, string loc)
        {
            DataRow row = this.tabledept.NewRow();
            row["dept_no"] = numdepar;
            row["dnombre"] = nombre;
            row["loc"] = loc;
            this.tabledept.Rows.Add(row);
            this.adapdept.Update(this.tabledept);
            this.tabledept.AcceptChanges();
        }

        public void ModificarDepartamento(int numdepar, string nombre, string loc)
        {
            DataRow row = this.GetDataRowId(numdepar);
            row["dnombre"] = nombre;
            row["loc"] = loc;
            this.adapdept.Update(this.tabledept);
            this.tabledept.AcceptChanges();
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
