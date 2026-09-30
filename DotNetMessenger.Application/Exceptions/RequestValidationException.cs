namespace DotNetMessenger.Application.Exceptions;

public sealed class RequestValidationException(IDictionary<string, string[]> errors) : Exception("Ошибка валидации.")
{
    public IDictionary<string, string[]> Errors { get; } = errors;
}
