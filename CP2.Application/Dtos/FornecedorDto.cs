using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no minimo 5 caracters")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} nao pode ser vazio");

            RuleFor(x => x.Cnpj)
                .Length(14).WithMessage(x => $"O campo {nameof(x.Cnpj)} deve ter 14 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Cnpj)} não pode ser vazio");

            RuleFor(x => x.Telefone)
                .Length(10).WithMessage(x => $"O campo {nameof(x.Telefone)} deve ter entre 10 dígitos")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(x => $"O campo {nameof(x.Email)} deve ser um e-mail válido")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio");

            RuleFor(x => x.CriadoEm)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser uma data futura");
        }
    }
}
