using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerlinkTeste.Model
{
    public class Processo
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataInicio { get; set; }
        public Decimal Valor { get; set; }
        public bool Status { get; set; }
        public int EstadoId { get; set; }
    }
}
