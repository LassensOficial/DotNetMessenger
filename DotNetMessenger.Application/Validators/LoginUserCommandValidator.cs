using FluentValidation;

namespace DotNetMessenger.Application.Validators;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Укажите имя пользователя.");

        RuleFor(command => command.Password)
            .NotEmpty().WithMessage("Укажите пароль.");
    }
}
