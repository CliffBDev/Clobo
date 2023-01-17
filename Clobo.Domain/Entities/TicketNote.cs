using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class TicketNote : TrackableEntity
    {
        public TicketNote()
        {
        }

        public int Id { get; set; }
        public string Note { get; set; }
        public Agent Agent { get; set; }
    }
}

