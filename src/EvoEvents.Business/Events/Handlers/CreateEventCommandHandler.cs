﻿using EvoEvents.Business.Events.Commands;
using EvoEvents.Data;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using Infrastructure.Utilities.Errors.ErrorMessages;
using MediatR;
using System.Linq;
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
            ValidateEvent(command);
            AddEvent(command);

            return await _context.SaveChangesAsync() > 0;
        }
        private void ValidateEvent(CreateEventCommand command)
        {
            var eventAlreadyExisting = _context.Events
                .Any(e => e.Address.CityCountriesId == command.CityCountriesId &&
                    e.Address.Location == command.Location &&
                    e.FromDate == command.FromDate &&
                    e.ToDate == command.ToDate &&
                    e.Name == command.Name);
                
            if(eventAlreadyExisting)
            {
                throw new CustomException(ErrorCode.Event_AlreadyCreated, EventErrorMessage.EventAlreadyCreated);
            }

            if (!ValidateAddress(command))
            {
                throw new CustomException(ErrorCode.City_Country_InvalidMapping, AddressErrorMessage.InvalidCityCountryId);
            }
        }

        private bool ValidateAddress(CreateEventCommand command)
        {   return _context.CityCountries
                .Any(e => e.Id == command.CityCountriesId);
        }

        private void AddEvent(CreateEventCommand command)
        {   
            _context.Events.Add(command.ToEvent());
        }
    }
}