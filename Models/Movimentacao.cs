using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string NumeroConteiner{ get; set; }
        public ETipoMovimentacao Tipo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }



        public enum ETipoMovimentacao : sbyte
        {
            Embarque = 1,
            Descarga,
            GateIn,
            GateOut,
            Reposicionamento,
            Pesagem,
            Scanner
        }


    }

    public class MovimentacaoValidator : AbstractValidator<Movimentacao>
    {
        Regex RegexNumeroConteiner = new Regex("^([a-z]|[A-Z]){4}[0-9]{7}$");
        public MovimentacaoValidator()
        {

            
            RuleFor(x => x.Tipo)
                    .IsInEnum()
                        .WithMessage("Necessário informar o tipo da movimentacao");

            RuleFor(x => x.DataInicio)
                .NotNull()
                .Custom((x, c) =>
                {
                    if (x > c.InstanceToValidate.DataFim)
                        c.AddFailure("Data inicial e final devem ser informadas");
                });

            RuleFor(x => x.NumeroConteiner)
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
            var result = await ValidateAsync(ValidationContext<Movimentacao>.CreateWithOptions((Movimentacao)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }

}
