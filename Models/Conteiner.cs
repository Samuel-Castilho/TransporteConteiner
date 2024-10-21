using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class Conteiner
    {

        public string Numero { get; set; }
        public string Cliente{ get; set; }

        public ETipoConteiner Tipo { get; set; }

        public EStatus Status { get; set; }

        public ECategoria Categoria{ get; set; }

        public enum ETipoConteiner : sbyte
        {
            Tipo20 = 1,
            Tipo40
        }

        public enum EStatus : sbyte
        {
            Cheio = 1,
            Vazio
        }

        public enum ECategoria : sbyte
        {
            Importacao = 1,
            Exportacao
        }

    }


    public class ConteinerValidator : AbstractValidator<Conteiner>
    {
        Regex RegexNumeroConteiner = new Regex("^([a-z]|[A-Z]){4}[0-9]{7}$");
        public ConteinerValidator()
        {
            RuleFor(x => x.Cliente)
                .NotEmpty()
                    .WithMessage("Cliente deve ser informado");

            RuleFor(x => x.Status)
                .IsInEnum()
                    .WithMessage("Necessário informar o status do conteiner");

            RuleFor(x => x.Tipo)
                    .IsInEnum()
                        .WithMessage("Necessário informar o tipo do conteiner");

            RuleFor(x => x.Categoria)
                .IsInEnum()
                    .WithMessage("Necessário informar categoria do conteiner");

            RuleFor(x => x.Numero)
                .Must(ValidaNumero)
                    .WithMessage("Número do conteiner (4 letras e 7 números. Ex: TEST1234567)");


        }

        private bool ValidaNumero(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                return false;

            bool numeroValido = RegexNumeroConteiner.IsMatch(numero);

            return numeroValido;
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Conteiner>.CreateWithOptions((Conteiner)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
