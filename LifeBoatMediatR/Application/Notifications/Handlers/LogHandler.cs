using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBoatMediatR.Application.Notifications.Handlers
{
    public class LogHandler : INotificationHandler<UserActionNotification>
    {
        public Task Handle(UserActionNotification notification, CancellationToken cancellationToken)
        {
            //Save to log  
            Console.WriteLine(" ****  User save to log...  *****");
            
            return Task.CompletedTask;
        }
    }
}
