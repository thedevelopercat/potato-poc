using FluentValidation;
using Potato.Application.Models.Errors;
using Potato.Application.Models.ViewModels;

namespace Potato.Application.Validation.Validators
{
    internal sealed class AddVegetableValidator : AbstractValidator<AddVegetableViewModel>
    {
        public AddVegetableValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .WithErrorCode(AddVegetableErrorCodes.NameNotEmpty);

            RuleFor(v => v.Name)
                .Must(v => v.Length <= 64)
                .WithErrorCode(AddVegetableErrorCodes.NameTooLong);
        }
    }
}
