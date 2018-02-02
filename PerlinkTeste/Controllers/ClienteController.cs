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
        IClienteRepository clientes;

        public ClienteController(IClienteRepository clienteRepository)
        {
            clientes = clienteRepository;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return clientes.GetAllClientes();
        }

    }
}