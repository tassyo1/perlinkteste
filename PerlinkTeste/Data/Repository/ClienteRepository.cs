using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;
namespace PerlinkTeste.Data.Repository
{
    public class ClienteRepository :IClienteRepository
    {
        IList<Cliente> Clientes;
        IEstadoRepository estadoRepo;

        public ClienteRepository(IEstadoRepository estadoRepo)
        {
            this.estadoRepo = estadoRepo;
            Clientes = new List<Cliente>();         
        }

        public IList<Cliente> GetAllClientes()
        {
            return Clientes;
        }

        public Cliente GetClientePorId(int clienteId)
        {
            return Clientes.Where(c => c.Id == clienteId).FirstOrDefault();
        }

        public Cliente GetClientePorNome(string nome)
        {
            return Clientes.Where(c => c.Nome == nome).FirstOrDefault();
        }

        public void InsertCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }
    }
}
