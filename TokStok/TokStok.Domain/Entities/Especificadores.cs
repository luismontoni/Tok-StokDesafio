
using FluentValidator;
using FluentValidator.Validation;
using System;
using TokStok.Domain.Repositories;

namespace TokStok.Domain.Entities
{
    public class Especificadores : Notifiable
    {

        public Especificadores(Guid id, string nome, string cpf, string tipoDocumentoClasse, string numeroDocumentoClasse)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf.Trim().Replace(".","").Replace("-","");
            TipoDocumentoClasse = tipoDocumentoClasse;
            NumeroDocumentoClasse = numeroDocumentoClasse.Trim().Replace(".", "").Replace("-", ""); 
            EspecificadorAtivo = true;

            AddNotifications(new ValidationContract()
               .HasMinLen(nome, 3, "Nome", "O nome deve conter ao menos 3 caracteres")
               .IsTrue(IsCpf(cpf), "CPF", "Por favor, digite um cpf válido")
               .HasMinLen(tipoDocumentoClasse, 2, "Tipo do documento de classe", "O tipo do documento de classe deve conter ao menos dois caracteres")
               );


        }
        public Especificadores(string nome, string cpf, string tipoDocumentoClasse, string numeroDocumentoClasse)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            TipoDocumentoClasse = tipoDocumentoClasse;
            NumeroDocumentoClasse = numeroDocumentoClasse.Trim().Replace(".", "").Replace("-", "");
            EspecificadorAtivo = true;

            AddNotifications(new ValidationContract()
                .HasMinLen(nome, 3, "Nome", "O nome deve conter ao menos 3 caracteres")
                .IsTrue(IsCpf(cpf), "CPF", "Por favor, digite um cpf válido")
              );

        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string TipoDocumentoClasse { get; private set; }
        public string NumeroDocumentoClasse { get; set; }
        public bool EspecificadorAtivo { get; set; }



        private bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
