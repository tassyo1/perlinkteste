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
    [Route("api/Processo")]
    public class ProcessoController : Controller
    {
        IProcessoRepository processoRepository;

        public ProcessoController(IProcessoRepository processoRepository)
        {
            this.processoRepository = processoRepository;
        }

        [HttpPost]
        public void PostProcesso([FromBody]Processo processo)
        {
            processoRepository.InsertProcesso(processo);
        }

        [HttpGet]
        public IEnumerable<Processo> GetProcessosAtivos()
        {
            return processoRepository.GetListaProcessos().Where(p => p.Status == true).ToList();
        }

        [HttpGet]
        public IEnumerable<Processo> GetProcessoPorEstadoPorCliente(int estadoId, int clienteId)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.EstadoId == estadoId && p.ClienteId == clienteId);
        }

        [HttpGet]
        public IEnumerable<Processo> GetProcessoValorMaiorQue(Decimal valor)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.Valor > valor);
        }

        [HttpGet]
        public IEnumerable<Processo> GetProcessoPorMesAno(int mes, int ano)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.DataInicio.Month == mes && p.DataInicio.Year == ano);
        }

        [HttpGet]
        public IEnumerable<Processo> GetProcessosPorEstadoCliente(Cliente cliente)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.EstadoId == cliente.EstadoId && p.ClienteId == cliente.Id);
        }

        public IEnumerable<Processo> GetProcessoPorNum(string NumeroProcesso)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.Numero.Contains(NumeroProcesso));
        }
    }
}