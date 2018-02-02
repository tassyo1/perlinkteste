using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinkTeste.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int EstadoId { get; set; }
        public List<Processo>Processos {get;set;}
    }
}
