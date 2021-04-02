using Dapper;
using TokStok.Domain.Queries;
using TokStok.Domain.Repositories;
using TokStok.Infra.DataContext;

using System.Collections.Generic;
using TokStok.Domain.Entities;
using System.Data;
using System;

namespace TokStok.Infra.Repositories
{
    public class EspecificadoresRepository : IEspecificadoresRepository
    {
        private readonly TokStokDataContext _context;
        public EspecificadoresRepository(TokStokDataContext context)
            => (_context) = (context);

       

        public IEnumerable<EspecificadoresQueryResult> Get()
        {
            var sql = @"SELECT Id
                            ,Nome
                            ,CPF
                            ,TipoDocumentoClasse
                            ,NumeroDocumentoClasse
                            ,EspecificadorAtivo
                        FROM 
                            Especificadores";
            return _context.Connection.Query<EspecificadoresQueryResult>(sql);
        }

        public EspecificadoresQueryResult GetByIdentifier(Guid id, string cpf, string numeroDocumentoClasse)
        {
            var sql = @"SELECT Id
                            ,Nome
                            ,CPF
                            ,TipoDocumentoClasse
                            ,NumeroDocumentoClasse
                            ,EspecificadorAtivo
                        FROM 
                            Especificadores
                        WHERE
                            Id = @id AND
                            CPF = @cpf AND
                            numeroDocumentoClasse = @numeroDocumentoClasse";
            return _context.Connection.QueryFirstOrDefault<EspecificadoresQueryResult>(sql, new { id, cpf, numeroDocumentoClasse});
        }

        public void Post(Especificadores especificadores)
        {
            _context
                 .Connection
                     .Execute("spCriaEspecificador",
                        new
                        {
                            Id = especificadores.Id,
                            Nome = especificadores.Nome,
                            CPF = especificadores.Cpf,
                            TipoDocumentoClasse = especificadores.TipoDocumentoClasse,
                            NumeroDocumentoClasse = especificadores.NumeroDocumentoClasse,
                            EspecificadorAtivo = especificadores.EspecificadorAtivo
                        }
                        , commandType: CommandType.StoredProcedure);

        }

        public void Put(Especificadores especificadores)
        {
            _context
                .Connection
                    .Execute("spAtualizaEspecificador",
                    new
                    {
                        Id = especificadores.Id,
                        Nome = especificadores.Nome
                    }
                    , commandType: CommandType.StoredProcedure
                );
        }
        public void Delete(List<Guid> id)
        {
            foreach (var item in id)
            {
                _context
                  .Connection
                      .QueryFirstOrDefault<bool>("spInativaEspecificador", new
                      {
                          Id = item
                      }
                , commandType: CommandType.StoredProcedure);
            }
               
        }

        public bool VerificaCpfEspecificador(string cpf)
        {
            return
                 _context
                    .Connection
                        .QueryFirstOrDefault<bool>("spVerificaCpf", new
                        {
                            Cpf = cpf
                        }
                  , commandType: CommandType.StoredProcedure);
        }

        public bool VerificaExistenciaDoEspecificador(Guid id)
        {
            return
                 _context
                    .Connection
                        .QueryFirstOrDefault<bool>("spVerificaId", new
                        {
                            Id = id
                        }
                  , commandType: CommandType.StoredProcedure);
        }

        public bool VerificaNumeroDocumentoClasseEspecificador(string numeroDocumentoClasse)
        {
           var retorno =
                 _context
                    .Connection
                        .QueryFirstOrDefault<bool>("spVerificaDocumentoClasse", new
                        {
                            NumeroDocumentoClasse = numeroDocumentoClasse
                        }
                  , commandType: CommandType.StoredProcedure);
            return retorno;
        }
    }
}
