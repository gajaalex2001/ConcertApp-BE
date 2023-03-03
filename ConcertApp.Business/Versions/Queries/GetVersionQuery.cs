using ConcertApp.Business.Versions.Models;
using MediatR;

namespace ConcertApp.Business.Versions.Queries
{
    public class GetVersionQuery : IRequest<VersionCode>
    {
        public string? Name { get; set; }
    }
}
