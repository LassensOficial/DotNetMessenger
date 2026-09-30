using DotNetMessenger.Application.Commands;
using FluentValidation;

namespace DotNetMessenger.Application.Validators;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Укажите имя пользователя.")
            .Must(name => name == name.Trim()).WithMessage("Имя пользователя не должно начинаться или заканчиваться пробелом.")
            .MinimumLength(3).WithMessage("Имя пользователя должно содержать минимум 3 символа.")
            .MaximumLength(32).WithMessage("Имя пользователя должно содержать не больше 32 символов.");

        RuleFor(command => command.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Укажите пароль.")
            .MinimumLength(8).WithMessage("Пароль должен содержать минимум 8 символов.")
            .MaximumLength(128).WithMessage("Пароль должен содержать не больше 128 символов.");
    }
}
