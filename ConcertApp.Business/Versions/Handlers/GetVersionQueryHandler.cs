using ConcertApp.Business.Versions.Models;
using ConcertApp.Business.Versions.Queries;
using ConcertApp.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConcertApp.Business.Versions.Handlers
{
    public class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, VersionCode>
    {
        private readonly ConcertAppContext _context;

        public GetVersionQueryHandler(ConcertAppContext context)
        {
            _context = context;
        }

        public async Task<VersionCode> Handle(GetVersionQuery request, CancellationToken cancellationToken)
        {
            return await _context.AppVersions
                .Where(v => v.Name == request.Name)
                .ToVersionCode()
                .FirstOrDefaultAsync();
        }
    }
}
