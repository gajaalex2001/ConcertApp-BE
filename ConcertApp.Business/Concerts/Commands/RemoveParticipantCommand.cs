using MediatR;

namespace ConcertApp.Business.Concerts.Commands
{
    public class RemoveParticipantCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public int ConcertId { get; set; }
    }
}
