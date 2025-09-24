using DesafioAPI.Aplicacao.DTOs;
using FluentValidation;

namespace DesafioAPI.Aplicacao.Usuarios.AtualizarUsuario
{
    public class AtualizarUsuarioDtoValidator : AbstractValidator<AtualizarUsuarioDto>
    {
        public AtualizarUsuarioDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("E-mail inválido.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Telefone)
                .Matches(@"^\(\d{3}\)-\d{3}-\d{4}$")
                .WithMessage("Telefone deve estar no formato (XXX)-XXX-XXXX.")
                .When(x => !string.IsNullOrWhiteSpace(x.Telefone));

            RuleFor(x => x.Celular)
                .Matches(@"^\(\d{3}\)-\d{3}-\d{4}$")
                .WithMessage("Celular deve estar no formato (XXX)-XXX-XXXX.")
                .When(x => !string.IsNullOrWhiteSpace(x.Celular));

            RuleFor(x => x.FotoUrl)
                .MaximumLength(200).WithMessage("FotoUrl deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Nacionalidade)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("Nacionalidade deve ser um código de país com 2 letras maiúsculas (ex: BR, US, TR).")
                .When(x => !string.IsNullOrWhiteSpace(x.Nacionalidade));
        }
    }
}