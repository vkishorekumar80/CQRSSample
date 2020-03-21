using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Cqrs.Domain.Events;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Cqrs.Services.Handlers.NotificationHandler
{
    public class CustomerCreatedHandler:INotificationHandler<CustomerCreatedEvent>
    {
        private readonly ILogger<CustomerCreatedHandler> logger;

        public CustomerCreatedHandler(ILogger<CustomerCreatedHandler> logger) {
            this.logger = logger;
        }

        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken) {
            // Do something with the created customer like Create Event bus request, send email etc
            await Task.FromResult("Message Sent...");
        }
    }
}
