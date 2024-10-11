using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no mínimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(x => $"O campo {nameof(x.Email)} deve ser um e-mail válido")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio");

            RuleFor(x => x.Telefone)
                .Length(10).WithMessage(x => $"O campo {nameof(x.Telefone)} deve ter entre 10 dígitos")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio");

            RuleFor(x => x.DataNascimento)
                .LessThan(DateTime.Now).WithMessage(x => $"O campo {nameof(x.DataNascimento)} deve ser uma data passada")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataNascimento)} não pode ser vazio");

            RuleFor(x => x.Endereco)
                .MinimumLength(10).WithMessage(x => $"O campo {nameof(x.Endereco)} deve ter no mínimo 10 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser vazio");

            RuleFor(x => x.DataContratacao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(x => $"O campo {nameof(x.DataContratacao)} não pode ser uma data futura")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataContratacao)} não pode ser vazio");

            RuleFor(x => x.ComissaoPercentual)
                .GreaterThan(0).WithMessage(x => $"O campo {nameof(x.ComissaoPercentual)} deve ser maior que zero");

            RuleFor(x => x.MetaMensal)
                .GreaterThanOrEqualTo(0).WithMessage(x => $"O campo {nameof(x.MetaMensal)} deve ser um valor positivo");

            RuleFor(x => x.CriadoEm)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser uma data futura");
        }
    }
}