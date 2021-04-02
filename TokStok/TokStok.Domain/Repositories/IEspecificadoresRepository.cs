using System;
using System.Collections.Generic;
using TokStok.Domain.Entities;
using TokStok.Domain.Queries;

namespace TokStok.Domain.Repositories
{
    public interface IEspecificadoresRepository
    {
        IEnumerable<EspecificadoresQueryResult> Get();
        EspecificadoresQueryResult GetByIdentifier(Guid id, string cpf, string numeroDocumentoClasse);
        void Post(Especificadores especificadores);
        void Put(Especificadores especificadores);
        void Delete(List<Guid> id);
        bool VerificaExistenciaDoEspecificador(Guid id);
        bool VerificaCpfEspecificador(string cpf);
        bool VerificaNumeroDocumentoClasseEspecificador(string numeroDocumentoClasse);
    }
}
