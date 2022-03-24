using FluentValidation;
using FluentValidation.Validators;
using Management.API.Application.UserApp.Commands.Models;

namespace Management.API.Application.UserApp.Commands.Validators
{
    /// <summary>
    ///     validate <see cref="CreateUserCommand" />
    /// </summary>
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        #region Constructors

        /// <summary>
        /// </summary>
        public CreateUserCommandValidator()
        {
         
            //FLUENT VALIDATOR

            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .MaximumLength(50).WithMessage("Không được nhập quá 50 ký tự")
                .MinimumLength(1).WithMessage("Nhập nhiều hơn 1 ký tự");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .MaximumLength(30).WithMessage("Không được nhập quá 30 ký tự")
                .MinimumLength(6).WithMessage("Nhập nhiều hơn 6 ký tự");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .EmailAddress(EmailValidationMode.Net4xRegex);
        }

        #endregion
    }
}
