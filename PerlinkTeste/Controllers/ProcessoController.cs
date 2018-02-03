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
    [Route("api/Processos")]
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

        [HttpGet("ativos")]
        public IEnumerable<Processo> GetProcessosAtivos()
        {
            return processoRepository.GetListaProcessos().Where(p => p.Status == true).ToList();
        }

        [HttpGet("estado/{estadoId}/cliente/{clienteId}")]
        public IEnumerable<Processo> GetProcessoPorEstadoPorCliente([FromRoute]int estadoId, [FromRoute] int clienteId)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.EstadoId == estadoId && p.ClienteId == clienteId);
        }

        [HttpGet("valor-maior-que/{valor}")]
        public IEnumerable<Processo> GetProcessoValorMaiorQue( Decimal valor)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.Valor > valor);
        }

        [HttpGet("mes/{mes}/ano/{ano}")]
        public IEnumerable<Processo> GetProcessoPorMesAno(int mes, int ano)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.DataInicio.Month == mes && p.DataInicio.Year == ano);
        }

        [HttpGet("cliente-estado")]
        public IEnumerable<Processo> GetProcessosPorEstadoCliente([FromBody]Cliente cliente)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.EstadoId == cliente.EstadoId && p.ClienteId == cliente.Id);
        }

        [HttpGet("{NumeroProcesso}")]
        public IEnumerable<Processo> GetProcessoPorNum(string NumeroProcesso)
        {
            return processoRepository.GetListaProcessos()
                .Where(p => p.Numero.Contains(NumeroProcesso.ToUpper()));
        }
    }
}