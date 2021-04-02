using FluentValidator;
using FluentValidator.Validation;
using System;
using TokStok.Domain.Commands.EspecificadoresCommands.Inputs;
using TokStok.Domain.Entities;
using TokStok.Domain.Enums;
using TokStok.Domain.Repositories;
using TokStok.Shared.Commands;
using TokStok.Shared.Commands.Output;

namespace TokStok.Domain.Handlers
{
    public class EspecificadoresHandler : Notifiable, ICommandHandler<EspecificadoresCommand>
    {
        private readonly IEspecificadoresRepository _especificadoresRepository;

        public EspecificadoresHandler(IEspecificadoresRepository especificadoresRepository)
            => (_especificadoresRepository) = (especificadoresRepository);


        public ICommandResult Handle(EspecificadoresCommand command)
        {
            if (command.Id == default(Guid))
            {
                //Monta entidade para novo especificador
                var entidade = new Especificadores(command.Nome, command.Cpf, command.tipoDocumentoClasse, command.NumeroDocumentoClasse);

                AddNotifications(entidade.Notifications);
                AddNotifications(new ValidationContract()
                    .IsFalse(VerificaNumeroDocumentoClasseEspecificador(entidade.NumeroDocumentoClasse), "Número do documento de classe", "O número do documento de classe informado já existe")
                    .IsFalse(VerificarCpfEspecificador(entidade.Cpf), "CPF", "O CPF informado já existe")
                    );
                if (Invalid)
                {
                    return new CommandResult(false, "Por favor, corrija os campos:", Notifications);
                }
                _especificadoresRepository.Post(entidade);
                return new CommandResult(true, "Especificador incluido com sucesso", entidade);
            }
            else
            {
                //Monta entidade para atualizar especificador
                var entidade = new Especificadores(command.Id, command.Nome, command.Cpf, command.tipoDocumentoClasse, command.NumeroDocumentoClasse);

                AddNotifications(entidade.Notifications);
                AddNotifications(new ValidationContract()
                    .IsTrue(VerificaIdEspecificador(entidade.Id), "Id", "O id informado não existe")
                    .IsTrue(VerificarCpfEspecificador(entidade.Cpf), "CPF", "O CPF informado não existe")
                    .IsTrue(VerificaNumeroDocumentoClasseEspecificador(entidade.NumeroDocumentoClasse), "Número do documento de classe", "O número do documento de classe informado não existe")
                    );

                if (Invalid)
                {
                    return new CommandResult(false, "Por favor, corrija os campos:", Notifications);
                }
                _especificadoresRepository.Put(entidade);

                return new CommandResult(true, "Especificador alterado com sucesso", entidade);
            }
        }
        private bool VerificaIdEspecificador(Guid id)
        {
            return _especificadoresRepository.VerificaExistenciaDoEspecificador(id);
        }
        private bool VerificarCpfEspecificador(string cpf)
        {
            return _especificadoresRepository.VerificaCpfEspecificador(cpf);
        }
        private bool VerificaNumeroDocumentoClasseEspecificador(string numeroDocumentoClasse)
        {
            return _especificadoresRepository.VerificaNumeroDocumentoClasseEspecificador(numeroDocumentoClasse);
        }
    }
}
