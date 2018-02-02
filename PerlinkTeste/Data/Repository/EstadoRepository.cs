using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;

namespace PerlinkTeste.Data.Repository
{
    public class EstadoRepository : IEstadoRepository
    {
        IList<Estado> Estados;

        public EstadoRepository()
        {
            Estados = new List<Estado>
            {
                new Estado {Id = 1, Nome = "Rio de Janeiro"},
                new Estado {Id = 2, Nome = "São Paulo"},
                new Estado {Id = 3, Nome = "Minas Gerais"},
                new Estado {Id = 4, Nome = "Amazonas"}
            };
        }

        public Estado GetEstadoPorNome(string nome)
        {
            return Estados.Where(e => e.Nome == nome).FirstOrDefault();
        }
    }
}
