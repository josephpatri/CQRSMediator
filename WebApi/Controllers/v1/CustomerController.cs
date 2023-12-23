using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseController
    {
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id) 
        {
            return Ok(await Mediator.Send(new DeleteCustomer { Id = Id }));
        }        
    }
}
