using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;

namespace PerlinkTeste.Data.Repository
{
    public class EstadoRepository : IEstadoRepository
    {
        IList<Estado> Estados = new List<Estado>();

        public IList<Estado> GetListaEstados()
        {
            return Estados;
        }

        public Estado GetEstadoPorNome(string nome)
        {
            return Estados.Where(e => e.Nome == nome).FirstOrDefault();
        }
    }
}
