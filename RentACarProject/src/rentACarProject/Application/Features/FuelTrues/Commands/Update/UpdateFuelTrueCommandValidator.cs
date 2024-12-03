using FluentValidation;

namespace Application.Features.FuelTrues.Commands.Update;

public class UpdateFuelTrueCommandValidator : AbstractValidator<UpdateFuelTrueCommand>
{
    public UpdateFuelTrueCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}