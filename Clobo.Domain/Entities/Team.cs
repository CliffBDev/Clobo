using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class Team : TrackableEntity
    {
        public Team()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<TeamAgent> TeamAgents { get; set; }
    }
}

