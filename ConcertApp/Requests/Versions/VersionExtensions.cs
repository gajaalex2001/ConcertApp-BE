using ConcertApp.Business.Versions.Queries;

namespace ConcertApp.API.Requests.Versions
{
    public static class VersionExtensions
    {
        public static GetVersionQuery ToQuery(this GetVersionQuery request)
        {
            return new GetVersionQuery
            {
                Name = request.Name,
            };
        }
    }
}
