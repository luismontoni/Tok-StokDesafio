using FluentValidator;
using System;
using TokStok.Domain.Enums;
using TokStok.Shared.Commands;

namespace TokStok.Domain.Commands.EspecificadoresCommands.Inputs
{
    public class EspecificadoresCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string tipoDocumentoClasse { get; set; }
        public string NumeroDocumentoClasse { get; set; }

        bool ICommand.Valid()
        {
            return Valid;
        }
    }
}
