using FluentValidation;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomer>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
