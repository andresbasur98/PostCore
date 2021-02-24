using Microsoft.EntityFrameworkCore;
using PostCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCore.Data
{
    public class UsuariosContext: DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
