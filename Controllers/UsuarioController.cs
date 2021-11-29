using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopAutos.Context;
using TopAutos.Models;
using Microsoft.AspNetCore.Http;

namespace TopAutos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TopAutosDatabaseContext _context;

        public UsuarioController(TopAutosDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: Usuario/Fallo
        
        public IActionResult Fallo()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Email,Clave,Rol")] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("userName", usuario.Nombre);
                HttpContext.Session.SetInt32("userId", usuario.Id);
                HttpContext.Session.SetInt32("userRole", usuario.Rol);
                return Redirect("/");
            }
            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<IActionResult> Login(String Email, String Clave)
        {
            
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == Email && m.Clave == Clave);

            if (usuario == null)
            {

               
                return Redirect("/Usuario/Fallo");

            }

            HttpContext.Session.SetString("userName", usuario.Nombre);
            HttpContext.Session.SetInt32("userId", usuario.Id);
            HttpContext.Session.SetInt32("userRole", usuario.Rol);

            return Redirect("/");
            
            
        }



        // POST: Usuario/Logout
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }
}
