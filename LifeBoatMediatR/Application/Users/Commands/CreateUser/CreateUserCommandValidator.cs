using System;
using FluentValidation;
using FluentValidation.Validators;

namespace LifeBoatMediatR.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3);
            RuleFor(x => x.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now);
        }
    }
}
