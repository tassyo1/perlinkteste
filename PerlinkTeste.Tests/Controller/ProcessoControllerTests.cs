using System;
using System.Collections.Generic;
using System.Linq;
using PerlinkTeste.Controllers;
using PerlinkTeste.Data.Repository;
using PerlinkTeste.Model;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerlinkTeste.Tests.Controllers
{

    [TestClass]
    public class ProcessoControllerTests
    {
        private IProcessoRepository processoRepository;
        private Mock<IProcessoRepository> mockRepoProcesso;
        private ProcessoController controller;

        public ProcessoControllerTests()
        {
            processoRepository = new ProcessoRepository();
            mockRepoProcesso = new Mock<IProcessoRepository>();
            mockRepoProcesso.Setup(r => r.GetListaProcessos()).Returns(this.processoRepository.GetListaProcessos());
            controller = new ProcessoController(mockRepoProcesso.Object);
        }
        //1) Calcular a soma dos processos ativos. A aplicação deve retornar R$ 1.087.000,00
        [TestMethod]
        public void GetProcessosAtivos_SomaAtivos()
        {
            var result = controller.GetProcessosAtivos();

            Assert.AreEqual(1087000, result.Sum(p => p.Valor));
        }

        //2) Calcular a a média do valor dos processos no Rio de Janeiro para o Cliente "Empresa A". A aplicação deve retornar R$ 110.000,00.
        [TestMethod]
        public void GetProcessosPorEstadoPorCliente_ValorMedia()
        {
            var result = controller.GetProcessoPorEstadoPorCliente(1, 1);

            Assert.AreEqual(110000, result.Average(p => p.Valor));
        }

        //3) Calcular o Número de processos com valor acima de R$ 100.000,00. A aplicação deve retornar 2.
        [TestMethod]
        public void GetProcessoValorMaiorQue_AcimaCemMil()
        {
            var controller = new ProcessoController(mockRepoProcesso.Object);

            var result = controller.GetProcessoValorMaiorQue(100000);

            Assert.AreEqual(2, result.Count());

        }

        //4) Obter a lista2 de Processos de Setembro de 2007. 
        //A aplicação deve retornar uma lista com somente o Processo “00010TRABAM”.
        [TestMethod]
        public void GetProcessoPorData_Setembro2007()
        {
            var result = controller.GetProcessoPorMesAno(9, 2007);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("00010TRABAM", result.FirstOrDefault().Numero);

        }

        /*
            5) Obter a lista de processos no mesmo estado do cliente, para cada um dos clientes.
            A aplicação deve retornar uma lista com os processos de número “00001CIVELRJ”,
            ”00004CIVELRJ” para o Cliente "Empresa A" e “00008CIVELSP”,
            ”00009CIVELSP” para o o Cliente "Empresa B".
         */
        [TestMethod]
        public void GetProcessosPorEstadoCliente_EmpresasAB()
        {

            var result = controller.GetProcessosPorEstadoCliente(GetClientes().Where(c => c.Nome == "Empresa A").FirstOrDefault());
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Select(n => n.Numero).ToList().Contains("00004CIVELRJ"));
            Assert.IsTrue(result.Select(n => n.Numero).ToList().Contains("00001CIVELRJ"));

            var result2  = controller.GetProcessosPorEstadoCliente(GetClientes().Where(c => c.Nome == "Empresa B").FirstOrDefault());
            Assert.AreEqual(2, result2.Count());
            Assert.IsTrue(result2.Select(n => n.Numero).ToList().Contains("00008CIVELSP"));
            Assert.IsTrue(result2.Select(n => n.Numero).ToList().Contains("00009CIVELSP"));
        }

        /* 
         6) Obter a lista de processos que contenham a sigla “TRAB”.
         A aplicação deve retornar uma lista com os processos “00003TRABMG” e “00010TRABAM”
        */
        [TestMethod]
        public void GetProcessoPorNum_Trab()
        {
            var result = controller.GetProcessoPorNum("TRAB");

            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Select(n => n.Numero).ToList().Contains("00003TRABMG"));
            Assert.IsTrue(result.Select(n => n.Numero).ToList().Contains("00010TRABAM"));

        }

        private IList<Cliente> GetClientes()
        {
            return new List<Cliente>()
            {
                new Cliente {Id = 1, Nome = "Empresa A", CNPJ = "00000000001", EstadoId = 1 },
                new Cliente {Id = 2, Nome = "Empresa B", CNPJ ="00000000001" , EstadoId = 2 }
            };
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

       
    }
}
