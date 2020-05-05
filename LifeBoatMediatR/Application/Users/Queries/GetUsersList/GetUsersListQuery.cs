using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using LifeBoatMediatR.Infrastructure;

namespace LifeBoatMediatR.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<IEnumerable<UserLookupDto>>
    {
    }

    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<UserLookupDto>>
    {
        private readonly IMapper _mapper;
        private readonly LifeBoatMediatRDbContext _context;
        
        public GetUsersListQueryHandler(LifeBoatMediatRDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserLookupDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.User
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return users;
        }
    }
}
