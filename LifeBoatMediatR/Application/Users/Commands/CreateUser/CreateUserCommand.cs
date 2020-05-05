using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LifeBoatMediatR.Infrastructure;
using LifeBoatMediatR.Domain.Entities;
using LifeBoatMediatR.Application.Notifications;

namespace LifeBoatMediatR.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Handler : IRequestHandler<CreateUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly LifeBoatMediatRDbContext _context;

        public Handler(LifeBoatMediatRDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(new Random().Next(), request.Name, request.Email, request.BirthDate);

            _context.User.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserActionNotification
            {
                Id = user.Id,
                Name = request.Name,
                Email = request.Email,
                Action = ActionNotificationEnum.Created
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
