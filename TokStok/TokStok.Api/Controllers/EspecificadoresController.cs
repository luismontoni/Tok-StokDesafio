using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TokStok.Domain.Commands.EspecificadoresCommands.Inputs;
using TokStok.Domain.Handlers;
using TokStok.Domain.Queries;
using TokStok.Domain.Repositories;
using TokStok.Shared.Commands;
using TokStok.Shared.Commands.Output;

namespace TokStok.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecificadoresController : ControllerBase
    {
        private readonly IEspecificadoresRepository _especificadoresRepository;
        private readonly EspecificadoresHandler _handler;
        public EspecificadoresController(IEspecificadoresRepository especificadoresRepository, EspecificadoresHandler handler)
            => (_especificadoresRepository, _handler) = (especificadoresRepository, handler);

        [HttpGet]
        public IEnumerable<EspecificadoresQueryResult> Get()
        {
            return _especificadoresRepository.Get();
        }

        [HttpGet("{id:Guid}/{cpf}/{numeroDocumentoClasse}")]
        public EspecificadoresQueryResult GetByIdentifier(Guid id, string cpf, string numeroDocumentoClasse)
        {
            return _especificadoresRepository.GetByIdentifier(id, cpf, numeroDocumentoClasse);
        }

        [HttpPost]
        public ICommandResult Post([FromBody] EspecificadoresCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut("{id:Guid}")]
        public ICommandResult Put([FromBody] EspecificadoresCommand command, Guid id)
        {
            return _handler.Handle(command);
        }
        

        [HttpDelete]
        public ICommandResult Delete(List<Guid> id)
        {
            _especificadoresRepository.Delete(id);
            return new CommandResult(true, "Especificadores inativados com sucesso", null);
        }
    }
}
