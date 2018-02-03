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

        public IEnumerable<Processo> GetProcessosAtivos()
        {
            return processoRepository.GetProcessosAtivos();
        }

        
    }
}