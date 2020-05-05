using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LifeBoatMediatR.Infrastructure;
using LifeBoatMediatR.Domain.Entities;
using LifeBoatMediatR.Application.Notifications;
using LifeBoatMediatR.Application.Common.Exceptions;

namespace LifeBoatMediatR.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Handler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly LifeBoatMediatRDbContext _context;

        public Handler(LifeBoatMediatRDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.Update(request.Name, request.Email, request.BirthDate);
            
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserActionNotification
            {
                Id = user.Id,
                Name = request.Name,
                Email = request.Email,
                Action = ActionNotificationEnum.Updated
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
