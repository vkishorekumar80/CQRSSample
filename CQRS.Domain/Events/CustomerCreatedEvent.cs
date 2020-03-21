using System;
using System.Collections.Generic;
using System.Text;

using MediatR;

namespace Cqrs.Domain.Events
{
    public class CustomerCreatedEvent:INotification
    {
        public Guid CustomerId { get; }

        public CustomerCreatedEvent(Guid customerId) {
            CustomerId = customerId;
        }
    }
}
