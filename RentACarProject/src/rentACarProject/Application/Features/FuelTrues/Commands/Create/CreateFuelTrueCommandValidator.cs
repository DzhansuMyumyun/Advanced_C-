using FluentValidation;

namespace Application.Features.FuelTrues.Commands.Create;

public class CreateFuelTrueCommandValidator : AbstractValidator<CreateFuelTrueCommand>
{
    public CreateFuelTrueCommandValidator()
    {
    }
}