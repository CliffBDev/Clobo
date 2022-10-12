using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class TeamAgent : TrackableEntity
    {
        public TeamAgent()
        {

        }

        public int Id { get; set; }
        public Team Team { get; set; }
        public Agent Agent { get; set; }
        public bool IsLead { get; set; }
    }
}

