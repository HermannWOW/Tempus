using Microsoft.AspNetCore.Mvc;
using Tempus.Models;
using Tempus.Repositorio;

namespace Tempus.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarClientes();
            return View(clientes);
        }
        [HttpPost]
        public IActionResult Index(string nomeCliente)
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarClientes();

            return View(clientes.Where(c=>c.Nome.StartsWith(nomeCliente)).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            ClienteModel cliente = _clienteRepositorio.BuscarIdCliente(id);
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            ClienteModel cliente = _clienteRepositorio.BuscarIdCliente(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            if(ModelState.IsValid)
            {
                _clienteRepositorio.Adicionar(cliente);

                return RedirectToAction("Index");
            }
            
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            _clienteRepositorio.Alterar(cliente);

            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);

            return RedirectToAction("Index");
        }
    }
}
