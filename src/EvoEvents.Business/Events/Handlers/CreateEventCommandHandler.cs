using EvoEvents.Business.Events.Commands;
using EvoEvents.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.Business.Events.Handlers
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, bool>
    {
        private readonly EvoEventsContext _context;

        public CreateEventCommandHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {         
            AddEvent(command);

            return await _context.SaveChangesAsync() > 0;
        }
        
        private void AddEvent(CreateEventCommand command)
        {
            _context.Events.Add(command.ToEvent());
        }
    }
}
