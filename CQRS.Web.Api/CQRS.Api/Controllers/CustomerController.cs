using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Cqrs.Domain.Commands;
using Cqrs.Domain.Dtos;
using Cqrs.Domain.Queries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator) {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(Guid id) {
            var customerQuery = new GetCustomerQuery(id);
            var result = await mediator.Send(customerQuery);

            if (result == null) {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateCustomerAsync([FromBody] NewCustomerDto newCustomer) {
            var newCustomerCommand =new CreateCustomerCommand(
                newCustomer.Name,
                newCustomer.Email,
                newCustomer.Address, 
                newCustomer.Phone,
                newCustomer.Age);
            var customer = await mediator.Send(newCustomerCommand);
            return Ok(customer);
        }
    }
}