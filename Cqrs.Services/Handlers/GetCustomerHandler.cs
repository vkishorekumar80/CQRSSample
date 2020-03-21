using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Cqrs.Data;
using Cqrs.Domain.Dtos;
using Cqrs.Domain.Queries;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cqrs.Services.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery,CustomerDto>
    {
        private readonly ILogger<GetCustomerHandler> logger;
        private readonly CustomerContext customerContext;

        public GetCustomerHandler(ILogger<GetCustomerHandler> logger, CustomerContext customerContext) {
            this.logger = logger;
            this.customerContext = customerContext;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken) {
            var customer =await customerContext.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);
            if (customer != null) {
                return new CustomerDto {
                    Id   = customer.Id,
                    Age = customer.Age,
                    Name = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone
                };
            }

            return null;
        }
    }
}
