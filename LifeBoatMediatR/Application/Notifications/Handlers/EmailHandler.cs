using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LifeBoatMediatR.Application.Notifications.Handlers
{
    public class EmailHandler : INotificationHandler<UserActionNotification>
    {
        public Task Handle(UserActionNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notification - " +
                              $"Action: {notification.Action.ToString()}" +
                              $"User Name: { notification.Name }" +
                              $"Email: { notification.Email }");

            return Task.CompletedTask;
        }
    }
}
