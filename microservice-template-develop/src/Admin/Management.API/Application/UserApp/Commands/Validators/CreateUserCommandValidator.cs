using FluentValidation;
using Management.API.Application.UserApp.Commands.Models;

namespace Management.API.Application.UserApp.Commands.Validators
{
    /// <summary>
    ///     validate <see cref="CreateUserCommand" />
    ///     File này chưa hoàn thiện, đang update
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
                .NotEmpty().WithMessage("KO DC BO TRON")
                .MaximumLength(50).WithMessage("MSC ")
                .MinimumLength(1).WithMessage("KO DC BO DSDSDSDS");
        
        }

        #endregion
    }
}
