using System;
using System.Collections.Generic;
using System.Text;

using Cqrs.Domain.Dtos;

using MediatR;

namespace Cqrs.Domain.Queries
{
    public class GetCustomerQuery : IRequest<CustomerDto> {
        public Guid CustomerId { get; }

        public GetCustomerQuery(Guid id) {
            CustomerId = id;
        }
    }
}
