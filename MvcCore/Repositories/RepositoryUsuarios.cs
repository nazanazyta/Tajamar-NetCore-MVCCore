using MvcCore.Data;
using MvcCore.Helpers;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Repositories
{
    public class RepositoryUsuarios
    {
        HospitalContext context;

        public RepositoryUsuarios(HospitalContext context)
        {
            this.context = context;
        }

        public void InsertarUSuario(int idusuario, String nombre
            , String username, String password)
        {
            Usuario user = new Usuario();
            user.IdUsuario = idusuario;
            user.Nombre = nombre;
            user.UserName = username;
            String salt = CypherService.GetSalt();
            user.Salt = salt;
            byte[] respuesta = CypherService.CifrarContenido(password, salt);
            user.Password = respuesta;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public Usuario UserLogIn(String username, String password)
        {
            //PARA VALIDAR, NOSOTROS SOLO PODEMOS BUSCAR POR USERNAME
            Usuario user = this.context.Usuarios.Where(z => z.UserName == username).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                String salt = user.Salt;
                byte[] passbbdd = user.Password;
                byte[] passtemporal = CypherService.CifrarContenido(password, salt);
                //COMPARAR ARRAY DE BYTES[]
                bool respuesta = HelperToolKit.CompararArrayBytes(passbbdd, passtemporal);
                if (respuesta == true)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
