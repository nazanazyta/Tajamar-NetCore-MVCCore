using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Repositories
{
    public interface IRepositoryDepartamentos
    {
        List<Departamento> GetDepartamentos();

        Departamento BuscarDepartamento(int numdepar);

        void EliminarDepartamento(int numdepar);

        void ModificarDepartamento(int numdepar, String nombre, String loc);

        void InsertarDepartamento(int numdepar, String nombre, String loc);
    }
}
