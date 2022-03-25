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
            RuleFor(command => command.FirstName)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .MaximumLength(50).WithMessage("Không được nhập quá 50 ký tự")
                .MinimumLength(1).WithMessage("Nhập nhiều hơn 1 ký tự");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .MaximumLength(30).WithMessage("Không được nhập quá 30 ký tự")
                .MinimumLength(6).WithMessage("Nhập nhiều hơn 6 ký tự")
                .Matches(@"[A-Z]+").WithMessage("Password phải có ít nhất 1 kí tự viết hoa")
                .Matches(@"[a-z]+").WithMessage("Password phải có ít nhất 1 kí tự viết thường")
                .Matches(@"[0-9]+").WithMessage("Password phải có ít nhất 1 kí tự số");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Không được bỏ trống")
                .EmailAddress(EmailValidationMode.Net4xRegex);
        }

        #endregion
    }
}
