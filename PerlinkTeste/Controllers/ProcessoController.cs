using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerlinkTeste.Model;


namespace PerlinkTeste.Controllers
{
    [Produces("application/json")]
    [Route("api/Processo")]
    public class ProcessoController : Controller
    {
       

        [HttpPost]
        public void PostProcesso([FromBody]Processo processo)
        {
            processos.Add(processo);
        }

        public IEnumerable<Processo> GetProcessosAtivos()
        {
            return processos;
        }

        
    }
}