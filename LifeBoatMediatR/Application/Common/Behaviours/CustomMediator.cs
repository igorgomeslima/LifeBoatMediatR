using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System;

namespace LifeBoatMediatR.Application.Common.Behaviours
{
    public class CustomMediator : Mediator
    {
        public CustomMediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        protected override async Task PublishCore(
            IEnumerable<Func<INotification, CancellationToken, Task>> allHandlers, 
            INotification notification,
            CancellationToken cancellationToken)
        {
            foreach (var handler in allHandlers)
            {
                await handler(notification, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
