using ConcertApp.Business.Versions.Models;
using ConcertApp.Data.Models.Versions;

namespace ConcertApp.Business.Versions
{
    public static class VersionExtensions
    {
        public static IQueryable<VersionCode> ToVersionCode(this IQueryable<AppVersion> query)
        {
            return query.Select(q => new VersionCode
            {
                Version = q.Version,
            });
        }
    }
}
