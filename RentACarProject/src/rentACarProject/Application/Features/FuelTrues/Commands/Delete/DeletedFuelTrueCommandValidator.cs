using FluentValidation;

namespace Application.Features.FuelTrues.Commands.Delete;

public class DeleteFuelTrueCommandValidator : AbstractValidator<DeleteFuelTrueCommand>
{
    public DeleteFuelTrueCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}