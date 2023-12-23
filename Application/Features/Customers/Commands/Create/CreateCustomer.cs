using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create
{
    public class CreateCustomer : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, Response<int>>
    {
        private readonly IAsyncRepo<Customer> _repo;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IAsyncRepo<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Customer>(request);
            var data = await _repo.AddAsync(newRecord);
            return new Response<int>(data.Id);
        }
    }
}
