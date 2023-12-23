using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomer : IRequest<Response<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomer, Response<bool>>
    {
        private readonly IAsyncRepo<Customer> _repo;

        public DeleteCustomerHandler(IAsyncRepo<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<Response<bool>> Handle(DeleteCustomer request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetByIdAsync(request.Id);

            if(data is null)
            {
                throw new KeyNotFoundException("Customer does not exists.");
            }

            await this._repo.DeleteAsync(data);
            return new Response<bool>(true);
        }
    }
}
