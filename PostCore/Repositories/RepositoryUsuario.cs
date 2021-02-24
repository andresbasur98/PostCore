using PostCore.Data;
using PostCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCore.Repositories
{
    public class RepositoryUsuario
    {
        UsuariosContext context;

        public RepositoryUsuario(UsuariosContext context)
        {
            this.context = context;
        }

        public List<Usuario> GetUsuarios()
        {
            var consulta = from datos in this.context.Usuarios
                           select datos;
            return consulta.ToList();
        }

        public void CrearUsuario(string email, string password)
        {
            Usuario usuario = new Usuario();
            if (this.context.Usuarios.Count() == 0)
            {
                usuario.IdUsuario = 1;
            }
            else
            {
                usuario.IdUsuario = this.context.Usuarios.Max(a => a.IdUsuario + 1);
            }

            usuario.Email = email;
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(password);

            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }
    }
}
