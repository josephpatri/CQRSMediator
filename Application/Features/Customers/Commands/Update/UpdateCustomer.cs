using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomer : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
    }

    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomer, Response<int>>
    {
        private readonly IAsyncRepo<Customer> _repo;

        public UpdateCustomerHandler(IAsyncRepo<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;

        public async Task<Response<int>> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _repo.GetByIdAsync(request.Id);

            if (customer is null)
            {
                throw new KeyNotFoundException();
            }

            var updatedCustomer = _mapper.Map(request, customer);

            await _repo.UpdateAsync(updatedCustomer);

            return new Response<int>(request.Id);
        }
    }
}
