using Application.DTOs;
using Application.Interface;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetById
{
    public class GetCustomerById : IRequest<Response<CustomerDto>>
    {
        public int Id { get; set; }
    }

    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, Response<CustomerDto>>
    {
        private readonly IAsyncRepo<Customer> _repo;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IAsyncRepo<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            var customer = await _repo.GetByIdAsync(request.Id);
            if(customer is null)
            {
                throw new KeyNotFoundException("Customer doesn't exists.");
            }
            return new Response<CustomerDto>(_mapper.Map<CustomerDto>(customer));
        }
    }
}
