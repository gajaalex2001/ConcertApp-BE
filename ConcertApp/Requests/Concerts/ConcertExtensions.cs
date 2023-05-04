using ConcertApp.Business.Concerts.Commands;
using ConcertApp.Business.Concerts.Queries;

namespace ConcertApp.API.Requests.Concerts
{
    public static class ConcertExtensions
    {
        public static CreateConcertCommand ToCommand(this CreateConcertRequest request)
        {
            return new CreateConcertCommand
            {
                Email = request.Email,
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                Genre = request.Genre,
                Capacity = request.Capacity,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
        }

        public static AddParticipantCommand ToCommand (this AddParticipantRequest request)
        {
            return new AddParticipantCommand
            {
                Email = request.Email,
                ConcertId = request.ConcertId,
            };
        }

        public static RemoveParticipantCommand ToCommand(this RemoveParticipantRequest request)
        {
            return new RemoveParticipantCommand
            {
                Email = request.Email,
                ConcertId = request.ConcertId
            };
        }

        public static GetPageQuery ToQuery(this GetPageRequest request) 
        {
            return new GetPageQuery
            {
                PageIndex = request.PageRequest.PageIndex,
                ItemsPerPage = request.PageRequest.ItemsPerPage,
                Email = request.Filters.Email,
                MusicGenre = request.Filters.MusicGenre,
                UserStatus = request.Filters.UserStatus,
            };
        }

        public static GetConcertQuery ToQuery(this GetConcertRequest request)
        {
            return new GetConcertQuery
            {
                ConcertId = request.ConcertId
            };
        }

        public static GetUpcomingConcertsQuery ToQuery(this GetUpcomingConcertsRequest request)
        {
            return new GetUpcomingConcertsQuery
            {
                Email = request.Email,
                CurrentDate = request.CurrentDate
            };
        }

        public static GetRecommendationsQuery ToQuery(this GetRecommendationsRequest request)
        {
            return new GetRecommendationsQuery
            {
                Email = request.Email
            };
        }
    }
}
