using FluentValidation;

namespace CsIO.Business.Models.Fornecedores.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(c => c.Rua)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLenght} caracteres.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");
        }
    }
}
