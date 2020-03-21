using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Cqrs.Data;
using Cqrs.Domain.Commands;
using Cqrs.Domain.Dtos;
using Cqrs.Domain.Events;
using Cqrs.Domain.Models;

using MediatR;

namespace Cqrs.Services.Handlers
{
    public class CreateCustomerHandler: IRequestHandler<CreateCustomerCommand, NewCustomerDto>
    {
        private readonly CustomerContext customerContext;
        private readonly IMediator mediator;

        public CreateCustomerHandler(CustomerContext customerContext, IMediator mediator) {
            this.customerContext = customerContext;
            this.mediator = mediator;
        }

        public async Task<NewCustomerDto> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken
        ) {
            // TODO: perform model validation
            var newCustomer = new Customer(
                request.Name,
                request.Age,
                request.Email,
                request.Address,
                request.Phone);

            customerContext.Customers.Add(newCustomer);
            await customerContext.SaveChangesAsync(cancellationToken);
            
            // Publish notification to other services

            await mediator.Publish(new CustomerCreatedEvent(newCustomer.Id), cancellationToken);

   
        
        return new NewCustomerDto {
                Id=newCustomer.Id,
                Name = newCustomer.Name,
                Age = newCustomer.Age,
                Address = newCustomer.Address,
                Email =  newCustomer.Email,
                Phone = newCustomer.Email
            };


        }
    }
}
