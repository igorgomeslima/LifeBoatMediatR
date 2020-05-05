using MediatR;

namespace LifeBoatMediatR.Application.Notifications
{
    public class UserActionNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ActionNotificationEnum Action { get; set; }
    }
}
