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
            Clientes = new List<Cliente>()
            {
                new Cliente {Id = 1, Nome = "Empresa A", CNPJ = "00000000001", EstadoId = this.estadoRepo.GetEstadoPorNome("Rio de Janeiro").Id },
                new Cliente {Id = 2, Nome = "Empresa B", CNPJ ="00000000001" , EstadoId = this.estadoRepo.GetEstadoPorNome("São Paulo").Id }
            };
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
    }
}
