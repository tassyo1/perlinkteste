using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerlinkTeste.Model;

namespace PerlinkTeste.Data.Repository
{
    public interface IEstadoRepository
    {
        Estado GetEstadoPorNome(string nome);
    }
}
