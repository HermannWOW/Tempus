using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tempus.Models;
using Tempus.Repositorio;

namespace Tempus.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public HomeController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public IActionResult Index()
        {

            List<ClienteModel> clientes = _clienteRepositorio.BuscarClientes();
            return View(clientes);
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