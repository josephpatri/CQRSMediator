using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(p => p.Address)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(p => p.Mail)
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.Phone)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
