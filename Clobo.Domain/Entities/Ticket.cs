using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class Ticket : TrackableEntity
    {
        public Ticket()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Agent? Agent { get; set; }
        public Team? Team { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public IList<TicketNote> TicketNotes { get; set; }
    }
}

