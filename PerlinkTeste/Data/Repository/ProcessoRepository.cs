using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;

namespace PerlinkTeste.Data.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {

        IList<Processo> processos = new List<Processo>();

        public IList<Processo> GetListaProcessos()
        {
            return processos;
        }

        public IList<Processo> GetProcessoPorClienteId(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertProcesso(Processo processo)
        {
            processos.Add(processo);
        }

        public IList<Processo> GetProcessosAtivos()
        {
            return processos.Where(p => p.Status == true).ToList();
        }
    }
}
