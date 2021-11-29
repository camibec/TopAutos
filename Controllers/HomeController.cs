using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TopAutos.Context;
using TopAutos.Models;

namespace TopAutos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TopAutosDatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, TopAutosDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Le traigo los autos mas votados
        public async Task<IActionResult> Index()
        {

            /*List<Vehiculo> vehiculosConMasVotos = new List<Vehiculo>();
            var vehiculoTopfive = _context.Vehiculos.OrderByDescending(p => p.Voto).Take(5);

            foreach (Vehiculo element in vehiculoTopfive)
            {
                vehiculosConMasVotos.Add(element);
            }

            ViewBag.vehiculosConMasVotos = vehiculosConMasVotos;
            return View();*/

            var vehiculos = await _context.Vehiculos.Where(v => v.Voto > 0).OrderByDescending(v => v.Voto).Take(4).ToListAsync();

            return View(vehiculos);

        }

        public IActionResult Privacy()
        {
            return View();
        }

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
