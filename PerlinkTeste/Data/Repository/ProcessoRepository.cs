using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;

namespace PerlinkTeste.Data.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {

        IList<Processo> processos;

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

       
    }
}
