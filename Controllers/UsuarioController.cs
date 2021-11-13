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

        public async Task<IActionResult> Login()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Create
        public IActionResult Create()
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

        // NO FUNCIONA
        // POST: Usuario/CheckUsuario
        [HttpPost]
        public async Task<IActionResult> CheckUsuario(String email, String clave)
        {
            var usuario = await  _context.Usuarios.FirstOrDefaultAsync(m => m.Email == email && m.Clave == clave);
            Console.WriteLine(email);
            if (usuario == null)
            {
                return Ok(StatusCode(403));
            }

            HttpContext.Session.SetString("userName", usuario.Nombre);
            HttpContext.Session.SetInt32("userId", usuario.Id);
            HttpContext.Session.SetInt32("userRole", usuario.Rol);

            return Ok(StatusCode(200));
        }

        // POST: Usuario/Logout
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }
}
