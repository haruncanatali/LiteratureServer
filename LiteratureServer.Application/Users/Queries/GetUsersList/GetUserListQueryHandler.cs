using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Users.Queries.GetUserDetail;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LiteratureServer.Application.Users.Queries.GetUsersList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserListQueryHandler> _logger;

        public GetUserListQueryHandler(IApplicationContext context, IMapper mapper, ILogger<GetUserListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var usersQuery = _context.Users
                .Where(c => (request.FullName == null || c.FullName.ToLower().Contains(request.FullName.ToLower())));

            var totalCount = usersQuery.Count();
            List<UserDetailDto> users = await usersQuery
                .ProjectTo<UserDetailDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new UserListVm
            {
                Users = users,
                Count = users.Count
            };
            return vm;
        }
    }
}