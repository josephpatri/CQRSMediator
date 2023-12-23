using Application.DTOs;
using Application.Interface;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomers : IRequest<PagedResponse<List<CustomerDto>>>
    {
        public int Number { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
    }

    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, PagedResponse<List<CustomerDto>>>
    {
        private readonly IAsyncRepo<Customer> _repo;
        private readonly IMapper _mapper;
        public GetAllCustomersHandler(IAsyncRepo<Customer> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            var customers = await _repo.ListAsync(new PagedCustomerSpec(request.Size, request.Number, request.Name, request.Mail));
            var customerDto = _mapper.Map<List<CustomerDto>>(customers);
            return new PagedResponse<List<CustomerDto>>(customerDto, request.Number, request.Size);
        }
    }
}
