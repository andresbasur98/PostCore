using Microsoft.AspNetCore.Mvc;
using PostCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCore.Controllers
{
    public class UsuarioController: Controller
    {
        RepositoryUsuario repo;

        public UsuarioController(RepositoryUsuario repo)
        {
            this.repo = repo;
        }

        public IActionResult CrearUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(String email, String password)
        {
            this.repo.CrearUsuario(email, password);
            return RedirectToAction("VerificarUsuario");
        }

        public IActionResult VerificarUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VerificarUsuario(String email, String password)
        {
            var usuario = this.repo.GetUsuarios().FirstOrDefault(x => x.Email == email);
            if (usuario != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, usuario.Password);
                if (isValidPassword)
                {
                    ViewData["MENSAJE"] = "La contraseña es correcta";
                }
                else
                {
                    ViewData["MENSAJE"] = "La contraseña es incorrecta";
                }
            }
            return View();
        }
    }
}
