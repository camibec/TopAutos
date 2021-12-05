using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopAutos.Context;
using TopAutos.Models;

namespace TopAutos.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly TopAutosDatabaseContext _context;
        private int LoggedId;
        private int LoggedRole;
        public VehiculosController(TopAutosDatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            if (httpContextAccessor.HttpContext.Session.GetInt32("userId") != null)
            {
                LoggedId = (int)httpContextAccessor.HttpContext.Session.GetInt32("userId");
            }
            if (httpContextAccessor.HttpContext.Session.GetInt32("userRole") != null)
            {
                LoggedRole = (int)httpContextAccessor.HttpContext.Session.GetInt32("userRole");
            }
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            if (LoggedRole != 1)
            {
                return Redirect("/");
            }
            
            return View(await _context.Vehiculos.ToListAsync());
        }

        // GET: Vehiculos/Calificador
        public async Task<IActionResult> Calificador()
        {
            if (LoggedId == 0)
            {
                return Redirect("/Usuario/Login");
            }
            return View(await _context.Vehiculos.ToListAsync());
        }

        // GET: Vehiculos/Ranking
        public async Task<IActionResult> Ranking()
        {
            var vehiculos = await _context.Vehiculos.Where(v => v.Voto > 0).OrderByDescending(v => v.Voto).ToListAsync(); 

            return View(vehiculos);
        }


        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/InfoVehiculo/5
        public async Task<IActionResult> InfoVehiculo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Ano,CantPuertas,Precio,VieneAutomatico,Tipo,Voto,Imagen")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Marca,Ano,CantPuertas,Precio,VieneAutomatico,Tipo,Voto,Imagen")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }

        
        // GET: Vehiculos/Buscador/
        public async Task<IActionResult> Buscador(String modelo, String marca, int ano, int tipo)
        {
            if (LoggedId == 0)
            {
                return Redirect("/Usuario/Login");
            }

            // De esta forma voy acumulando los parametros en la query
            IQueryable<Vehiculo> query = _context.Vehiculos;

            //Para que cuando nadie busca nada, me muestre todo el listado
            if (modelo == null && marca == null && ano == 0) 
            {
                query = _context.Vehiculos;
            }

            if (modelo != null)
            {
                query = query.Where(p => p.Modelo.Contains(modelo));
            }

            if (marca != null)
            {
                query = query.Where(p => p.Marca.Contains(marca));
            }

            if (ano != 0)
            {
                query = query.Where(p => p.Ano == ano);
            }

            //if (tipoVehiculo != 0){
            Console.WriteLine(tipo);
            switch (tipo)
            {
                case 1:
                    query = query.Where(p => p.Tipo == TipoVehiculo.Auto);
                    break;
                case 2:
                    query = query.Where(p => p.Tipo == TipoVehiculo.PickUp);
                    break;
                case 3:
                    query = query.Where(p => p.Tipo == TipoVehiculo.SUV);
                    break;
                case 4:
                    query = query.Where(p => p.Tipo == TipoVehiculo.Deportivo);
                    break;
            }
            //}

            //Contenido de la query en una lista: 
            List<Vehiculo> vehiculos = query.ToList();

            return View(vehiculos);
        }

        //GET: Vehiculos/VehiculosFav
        public async Task<IActionResult> VehiculosFav()
        {
            if (LoggedId == 0)
            {
                return Redirect("/Usuario/Login");
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == LoggedId);
            if (usuario == null)
            {
                return StatusCode(400);
            }

            // En la vista de vehiculos favs se van a guardar los vehiculos que el usuario califico con cuatro o mas.
            var vehiculosUsuario = _context.VotosUsuario.Where(u => u.Usuario == usuario && u.Voto >= 4)
                .Select(v => v.Vehiculo).OrderByDescending(v => v.Voto).ToList();



            

            return View(vehiculosUsuario);
        }

        // POST: Vehiculos/Calificacion
        [HttpPost]
        public async Task<IActionResult> Calificacion(int vehiculoId, int voto)
        {
            //Despues evaluar si esta logueado
            if (LoggedId == 0)
            {
                return Redirect("/Usuario/Login");
            }

            Console.WriteLine("VEHICULO ID: " + vehiculoId);
            Console.WriteLine("VOTO: " + voto);

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == LoggedId); // Evaluar si tengo varios, con if al principio
            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(m => m.Id == vehiculoId);
            var votosUsuario = await _context.VotosUsuario.FirstOrDefaultAsync(m => m.Usuario == usuario && m.Vehiculo == vehiculo);

            if (votosUsuario != null)
            {
                votosUsuario.Voto = voto;
                _context.VotosUsuario.Update(votosUsuario);
            }
            else
            {
                VotosUsuario votoUsuario = new VotosUsuario { Usuario = usuario, Vehiculo = vehiculo, Voto = voto };
                _context.VotosUsuario.Add(votoUsuario);
            }

            await _context.SaveChangesAsync();

            var sumaDeVotosPorAuto = _context.VotosUsuario.Where(u => u.Vehiculo == vehiculo).Sum(i => i.Voto);
            var cantidadDevotosDelAuto = _context.VotosUsuario.Where(u => u.Vehiculo == vehiculo).Count();
            Console.WriteLine("sumaDeVotosPorAuto: " + sumaDeVotosPorAuto);
            Console.WriteLine("cantidadDevotosDelAuto: " + cantidadDevotosDelAuto);

            var promedio = 0;

            

            //Check que no sea cero
            if (cantidadDevotosDelAuto > 0)
            {
                promedio = sumaDeVotosPorAuto / cantidadDevotosDelAuto;
            }
            
            Console.WriteLine("PROMEDIO: " + promedio);

            //Redondear
            vehiculo.Voto = (int)promedio;

            _context.Vehiculos.Update(vehiculo);

            await _context.SaveChangesAsync();




            return StatusCode(200);
        }

        // POST: Vehiculos/Porcalificacion
        [HttpPost]
        public async Task<IActionResult> Porcalificacion()
        {
            
            var v = await _context.Vehiculos.ToListAsync();

            
            return Ok(v);
        }
    }
}
