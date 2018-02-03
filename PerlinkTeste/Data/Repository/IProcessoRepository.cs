using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;

namespace PerlinkTeste.Data.Repository
{
    public interface IProcessoRepository
    {
        IList<Processo> GetProcessoPorClienteId(int id);
        void InsertProcesso(Processo processo);
        IList<Processo> GetProcessosAtivos();
        IList<Processo> GetListaProcessos();
    }
}
