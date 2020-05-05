using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LifeBoatMediatR.Infrastructure;
using LifeBoatMediatR.Domain.Entities;
using LifeBoatMediatR.Application.Notifications;
using LifeBoatMediatR.Application.Common.Exceptions;

namespace LifeBoatMediatR.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly LifeBoatMediatRDbContext _context;

        public Handler(LifeBoatMediatRDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FindAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _context.User.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserActionNotification
            {
                Id = user.Id,
                Action = ActionNotificationEnum.Deleted
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
