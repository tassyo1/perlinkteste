using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerlinkTeste.Controllers;
using PerlinkTeste.Data.Repository;
using PerlinkTeste.Model;
using Moq;

namespace PerlinkTeste.Tests.Controllers
{
    [TestClass]
    public class ProcessoControllerTests
    {

        IProcessoRepository processoRepository;
        IEstadoRepository estadoRepository;
        IClienteRepository clienteRepository;

        public ProcessoControllerTests(IProcessoRepository processoRepository, IEstadoRepository estadoRepository, IClienteRepository clienteRepository)
        {
            this.processoRepository = processoRepository;
            this.estadoRepository = estadoRepository;
            this.clienteRepository = clienteRepository;
        }

        [TestMethod]
        public void GetProcessosAtivos_SomaAtivos()
        {
            var mockRepoProcesso = new Mock<IProcessoRepository>();
            mockRepoProcesso.Setup(r => r.GetListaProcessos()).Returns(this.GetProcessos());
            var controller = new ProcessoController(mockRepoProcesso.Object);

            var result = controller.GetProcessosAtivos();

            var processosAtivos = processoRepository.GetProcessosAtivos();
            Assert.AreEqual(1087000, processosAtivos.Sum(p => p.Valor));
        }

        private IList<Estado> GetEstados()
        {
            IList<Estado> Estados = new List<Estado>
            {
                new Estado {Id = 1, Nome = "Rio de Janeiro"},
                new Estado {Id = 2, Nome = "São Paulo"},
                new Estado {Id = 3, Nome = "Minas Gerais"},
                new Estado {Id = 4, Nome = "Amazonas"}
            };

            return Estados;
        }

        private IList<Processo> GetProcessos()
        {
            IList<Processo> processos = new List<Processo>()
            {    
                //Não esquecer o Estado
            new Processo { Id = 1, Status = true, Numero = "00001CIVELRJ",
                DataInicio = new DateTime(2007,10,10), Valor = 200000 , EstadoId = 1 ,
            ClienteId = 1},

            new Processo { Id = 2, Status = true, Numero = "00002CIVELSP",
                DataInicio = new DateTime(2007,10,20), Valor = 100000,  EstadoId = 2 ,
             ClienteId = 1},

            new Processo { Id = 3, Status = false, Numero = "00003CIVELMG",
                DataInicio = new DateTime(2007,10,30), Valor = 10000 , EstadoId =3,
             ClienteId = 1},

            new Processo { Id = 4, Status = false, Numero = "00004CIVELRJ",
                DataInicio = new DateTime(2007,11,10), Valor = 20000 ,EstadoId = 1,
             ClienteId = 1},

            new Processo { Id = 5, Status = true, Numero = "00005CIVELSP",
                DataInicio = new DateTime(2007,11,15), Valor = 35000 , EstadoId = 2,
             ClienteId = 1},




            new Processo { Id = 6, Status = true, Numero = "00006CIVELRJ",
                DataInicio = new DateTime(2007,5,1), Valor = 20000, EstadoId  = 1 ,
            ClienteId = 2},

             new Processo { Id = 7, Status = true, Numero = "00007CIVELRJ",
                DataInicio = new DateTime(2007,2,6), Valor = 700000, EstadoId  =1 ,
            ClienteId = 2},

              new Processo { Id = 8, Status = false, Numero = "00008CIVELSP",
                DataInicio = new DateTime(2007,7,3), Valor = 500, EstadoId  =2,
            ClienteId = 2},

              new Processo { Id = 9 , Status = true, Numero = "00009CIVELSP",
              DataInicio = new DateTime(2007,8,4), Valor = 32000 , EstadoId  = 2,
              ClienteId = 2},

              new Processo { Id = 10 , Status = false, Numero = "00010TRABAM",
              DataInicio = new DateTime(2007,9,5), Valor = 1000 , EstadoId  = 4 ,
              ClienteId = 2},
            };


            return processos;
        }
    }
}
