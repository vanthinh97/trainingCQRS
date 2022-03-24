using FluentValidation;
using FluentValidation.Validators;
using Management.API.Application.UserApp.Commands.Models;

namespace Management.API.Application.UserApp.Commands.Validators
{
    /// <summary>
    /// validate <see cref="UpdateUserCommandValidator" />
    /// </summary>
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Constructors

        /// <summary>
        /// </summary>
        public UpdateUserCommandValidator()
        {

            //FLUENT VALIDATOR

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .EmailAddress(EmailValidationMode.Net4xRegex);
        }

        #endregion
    }
}
