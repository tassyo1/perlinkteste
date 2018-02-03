using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerlinkTeste.Model;
using PerlinkTeste.Data.Repository;

namespace PerlinkTeste.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        IClienteRepository clientesRepo;

        public ClienteController(IClienteRepository clienteRepository)
        {
            clientesRepo = clienteRepository;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return clientesRepo.GetAllClientes();
        }

        [HttpPost]
        public void PostCliente([FromBody] Cliente cliente)
        {
            clientesRepo.InsertCliente(cliente);
        }

    }
}