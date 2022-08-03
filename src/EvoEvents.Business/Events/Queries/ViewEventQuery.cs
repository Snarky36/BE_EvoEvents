using EvoEvents.Business.Events.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoEvents.Business.Events.Queries
{
    public class ViewEventQuery : IRequest<EventInformation>
    {
        public int Id { get; set; }
    }
}