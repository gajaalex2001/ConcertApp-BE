using ConcertApp.Business.Concerts.Commands;
using ConcertApp.Data.Models.Concerts;
using Utility.Extensions;
using BusinessModels = ConcertApp.Business.Concerts.Models;

namespace ConcertApp.Business.Concerts
{
    public static class ConcertExtensions
    {
        public static Concert ToConcert(this CreateConcertCommand command)
        {
            return new Concert
            {
                Name = command.Name,
                Description = command.Description,
                Genre = command.Genre,
                Location = command.Location,
                Capacity = command.Capacity,
                StartDate = command.StartDate.ToUniversalTime(),
                EndDate = command.EndDate.ToUniversalTime()
            };
        }

        public static IQueryable<BusinessModels.Concert> ToConcertCard(this IQueryable<Concert> query)
        {
            return query.Select(c => new BusinessModels.Concert
            {
                Capacity = c.Capacity,
                NoParticipants = c.UserConcerts.Count - 1,
                Description = c.Description.Truncate(100),
                Genre = c.Genre,
                Location = c.Location,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Id = c.Id,
                Name = c.Name,
            });
        }

        public static IQueryable<BusinessModels.ConcertDetails> ToConcertDetails(this IQueryable<Concert> query)
        {
            return query.Select(c => new BusinessModels.ConcertDetails
            {
                Capacity = c.Capacity,
                NoParticipants = c.UserConcerts.Count - 1,
                Description = c.Description,
                Genre = c.Genre,
                Location = c.Location,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Id = c.Id,
                Name = c.Name,
            });
        }
    }
}
