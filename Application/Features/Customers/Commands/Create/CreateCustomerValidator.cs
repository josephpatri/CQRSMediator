using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Customers.Commands.Create
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomer>
    {
        public CreateCustomerValidator()
        {
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
