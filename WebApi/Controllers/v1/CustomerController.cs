using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries.GetAll;
using Application.Features.Customers.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomersParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllCustomers
            {
                Number = filter.Number,
                Size = filter.Size,
                Mail = filter.Mail,
                Name = filter.Name
            }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await Mediator.Send(new GetCustomerById { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomer command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomer command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await Mediator.Send(new DeleteCustomer { Id = Id }));
        }
    }
}
