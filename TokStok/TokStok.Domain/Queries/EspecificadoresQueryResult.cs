using System;
using TokStok.Domain.Enums;

namespace TokStok.Domain.Queries
{
    public class EspecificadoresQueryResult
    {
        public Guid Id{ get; set; }
        public string Nome  { get; set; }
        public string CPF { get; set; }
        public string TipoDocumentoClasse { get; set; }
        public string NumeroDocumentoClasse { get; set; }
        public bool EspecificadorAtivo { get; set; }
    }
}
